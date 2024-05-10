using Controlador.Catalogo;
using Controlador.Validaciones;
using Poco;
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
    public partial class FrmProveedor : Form
    {
        private Controles Servicios;
        private FrmCatalogModel FrmCatalogModel;
        public bool flag;
        public FrmProveedor(FrmCatalogModel frmCatalogModel, Controles servicios, bool v)
        {
            InitializeComponent();
            Servicios = servicios;
            FrmCatalogModel = frmCatalogModel;
            flag = v;

            Cargar_DatosActualizar();
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarTextBox(string nombre, string ruc, string telefono, string correo, double credito)
        {
            if (nombre == "" || ruc ==  "" || telefono == "" || correo == "")
            {
                MessageBox.Show("Existen campos vacíos","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            if (ruc.Length != 14)
            {
                MessageBox.Show("EL ruc debe tener 14 caracteres","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            if (correo.Contains("@") == false)
            {
                MessageBox.Show("Correo inválido","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtEmpresa.Text;
            string ruc = txtRUC.Text;
            string telefono = txtTelefono.Text.Replace("-","");
            string correo = txtCorreo.Text;
            double credito = 0;

            if (!double.TryParse(txtCredito.Text,out credito))
            {
                credito = 0;
            }

            if (ValidarTextBox(nombre,ruc,telefono,correo,credito) == false)
            {
                return;
            }

            Proveedor p = new Proveedor()
            {
                NombreCompañia = nombre,
                RUC = ruc,
                Telefono = telefono,
                Correo = correo,
                Credito = credito
            };

            if (flag == true)
            {
                Agregar(p);
            }
            else
            {
                int id = Convert.ToInt32(FrmCatalogModel.dgvDatos.SelectedRows[0].Cells[0].Value);
                Actualizar(id,p);
            }
            FrmCatalogModel.RefrescarTabla();

        }

        private void Agregar(Proveedor p)
        {
            Servicios.cProveedor.Agregar(p);
            MessageBox.Show("Se registro un nuevo proveedor", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Actualizar(int id, Proveedor p)
        {
            Servicios.cProveedor.Actualizar(id,p);
            MessageBox.Show("Se actualizó el proveedor", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Cargar_DatosActualizar()
        {
            
            DataGridViewRow fila = FrmCatalogModel.dgvDatos.SelectedRows[0];

            if (flag == false)
            {
                txtEmpresa.Text = fila.Cells[1].Value.ToString();
                txtRUC.Text = fila.Cells[2].Value.ToString();
                txtTelefono.Text = fila.Cells[3].Value.ToString();
                txtCorreo.Text = fila.Cells[4].Value.ToString();
                txtCredito.Text = FormatoString.QuitarFormatoNic(fila.Cells[5].Value.ToString()).ToString();
            }
        }

        private void txtEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionTexTBox.SoloLetras(sender, e);

        }

        private void txtCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionTexTBox.SoloNumeros(sender, e);

        }
    }
}
