using Controlador.Catalogo;
using Controlador.Validaciones;
using Poco;
using SistemaFerretero.MenusEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFerretero.Forms.Menus.Catalogo
{
    public partial class FrmProducto : Form
    {
        private Controles Servicios;
        private FrmCatalogModel FrmCatalogModel;
        public bool flag;
        public FrmProducto(FrmCatalogModel frmCatalogModel, Controles servicios, bool v)
        {
            InitializeComponent();

            FrmCatalogModel = frmCatalogModel;
            Servicios = servicios;
            flag = v;
            CargarComboBox();

            if (flag == false)
            {
                Cargar_DatosActualizar();
            }
            
        }

        private void CargarComboBox()
        {
            List<string> contenidos = new List<string>();

            foreach (var valor in Enum.GetValues(typeof(ContenidoEnum)).Cast<object>().ToList())
            {
                contenidos.Add(valor.ToString().Replace("_"," "));
            }

            cmbContenido.Items.AddRange(contenidos.ToArray());
            cmbContenido.SelectedIndex = 0;
        }

        private void pnlBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private bool ValidarTextBox(string nombre, string marca, string modelo, int peso, string contenido, double precio, int unidades)
        {
            if (nombre == "" || marca == ""  || contenido == "")
            {
                MessageBox.Show("Existen campos vacíos","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            if (contenido ==  "Seleccione una opción ")
            {
                MessageBox.Show("Seleccione la unidad de medida del producto");
                return false;
            }

            if (precio == 0 || unidades == 0)
            {
                MessageBox.Show("Los valores deben ser diferentes de 0","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string marca = txtMarca.Text;
            string modelo = txtModelo.Text;
            int peso = 0;
            string contenido = cmbContenido.SelectedItem.ToString();
            double precio = 0;
            int unidades = 0;

            if (!int.TryParse(txtPeso.Text,out peso)){
                peso = 0;
            }

            if (!double.TryParse(txtPrecio.Text, out precio))
            {
                precio = 0;
            }

            if (!int.TryParse(txtUnidades.Text, out unidades))
            {
                unidades = 0;
            }

            if (ValidarTextBox(nombre,marca,modelo,peso,contenido,precio,unidades) == false)
            {
                return;
            }

            Producto p = new Producto()
            {
                Nombre = nombre,
                Marca = marca,
                Modelo = modelo,
                Peso = peso,
                Contenido = contenido,
                Precio =  precio,
                UnidadesRequeridas = unidades,
                UnidadesDisponibles = 0,
                UnidadesOrdenadas = 0
            };

            if (flag == true)
            {
                Agregar(p);
            }
            else
            {
                int id = Convert.ToInt32(FrmCatalogModel.dgvDatos.SelectedRows[0].Cells[0].Value);
                Actualizar(id, p);
            }
            FrmCatalogModel.RefrescarTabla();
        }

        public void Agregar(Producto p)
        {
            Servicios.cProducto.Agregar(p);
            MessageBox.Show("Se registro un nuevo producto", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Actualizar(int id, Producto p)
        {
            Servicios.cProducto.Actualizar(id,p);
            MessageBox.Show("Se actualizó el producto", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Cargar_DatosActualizar()
        {
            if (FrmCatalogModel.dgvDatos.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione una fila para actualizar","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                return;
            }

            DataGridViewRow fila = FrmCatalogModel.dgvDatos.SelectedRows[0];
            
                txtNombre.Text = fila.Cells[1].Value.ToString();
                txtMarca.Text = fila.Cells[2].Value.ToString();
                txtModelo.Text = fila.Cells[3].Value.ToString();
                txtPeso.Text = fila.Cells[4].Value.ToString();
                cmbContenido.SelectedIndex =  cmbContenido.Items.IndexOf(fila.Cells[5].Value);
                txtPrecio.Text = FormatoString.QuitarFormatoNic(fila.Cells[6].Value.ToString()).ToString();
                txtUnidades.Text = fila.Cells[8].Value.ToString();
            
        }


        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionTexTBox.SoloLetras(sender, e);

        }

        private void txtModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtContenido_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionTexTBox.SoloLetras(sender, e);

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionTexTBox.SoloNumeros(sender,e);
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionTexTBox.SoloNumeros(sender, e);
        }

        private void txtUnidades_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }
    }
}
