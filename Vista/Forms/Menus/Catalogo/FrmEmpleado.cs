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
    public partial class FrmEmpleado : Form
    {
        private Controles Servicios;
        private FrmCatalogModel FrmCatalogModel;
        public bool flag;

        public FrmEmpleado(FrmCatalogModel frmCatalogModel, Controles servicios, bool v)
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

        private bool MensajeInformacion(string pNombre, string pApellido, string telefono, string correo, string direccion, string cargo, decimal salario)
        {
            if (pNombre == "" || pApellido == "" || telefono == "" || correo == "" || direccion == "" || cargo == "")
            {
                MessageBox.Show("Existen campos vacíos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (telefono.Length != 8)
            {
                MessageBox.Show("Teléfono inválido", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if ((correo.Contains("@gmail.com")|| correo.Contains("@hotmail.com") || correo.Contains("yahoo.com")) == false)
            {
                MessageBox.Show("Correo inválido", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cargo == "Seleccione una opción")
            {
                MessageBox.Show("Seleccione un cargo", "Mensaje de aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (salario <= 0)
            {
                MessageBox.Show("El salario debe ser mayor a 0", "Mensaje de aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string pNombre = txtPrimerNombre.Text;
            string sNombre = txtSegundoNombre.Text;
            string pApellido = txtPrimerApellido.Text;
            string sApellido = txtSegunApellido.Text;
            string telefono = txtTelefono.Text.Replace("-","");
            string correo = txtCorreo.Text;
            string direccion = txtDireccion.Text;
            string cargo = txtCargo.Text;
            decimal salario = 0;

            if (!decimal.TryParse(txtSalario.Text,out salario))
            {
                salario = 0;
            }

            if (MensajeInformacion(pNombre, pApellido, telefono, correo, direccion, cargo, salario) == false){
                return;
            }

            Empleado empleado = new Empleado()
            {
                PrimerNombre = pNombre,
                SegundoNombre = sNombre,
                PrimerApellido = pApellido,
                SegundoApellido = sApellido,
                Telefono = telefono,
                Correo = correo,
                Direccion = direccion,
                Cargo = cargo,
                Salario = salario,
                
            };

            if (flag == true)
            {
                Agregar(empleado);
            }
            else
            {
                int id = Convert.ToInt32(FrmCatalogModel.dgvDatos.SelectedRows[0].Cells[0].Value);
                Actualizar(id, empleado);
            }
            
            FrmCatalogModel.RefrescarTabla();
        }

        private void Agregar(Empleado e)
        {
            Servicios.cEmpleado.Agregar(e);
            MessageBox.Show("Se registro un nuevo empleado", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Actualizar(int id,Empleado e)
        {
            Servicios.cEmpleado.Actualizar(id,e);
            MessageBox.Show("Se actualizó el empleado", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Cargar_DatosActualizar()
        {
            DataGridViewRow fila = FrmCatalogModel.dgvDatos.SelectedRows[0];

            if (flag == false)
            {
                string[] nombres = (fila.Cells[1].Value.ToString()).Split(' ');

                txtPrimerNombre.Text = nombres[0];
                txtSegundoNombre.Text = nombres[1];
                txtPrimerApellido.Text = nombres[2];
                txtSegunApellido.Text = nombres[3];

                txtCargo.Text = fila.Cells[2].Value.ToString();
                txtSalario.Text = FormatoString.QuitarFormatoNic(fila.Cells[3].Value.ToString()).ToString();
                txtTelefono.Text = fila.Cells[4].Value.ToString();
                txtCorreo.Text = fila.Cells[5].Value.ToString();
                txtDireccion.Text = fila.Cells[6].Value.ToString();
            }
        }

        private void txtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionTexTBox.SoloLetras(sender ,e);
        }    

        private void txtSegundoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionTexTBox.SoloLetras(sender, e);

        }

        private void txtPrimerApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionTexTBox.SoloLetras(sender, e);

        }

        private void txtSegunApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionTexTBox.SoloLetras(sender, e);

        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionTexTBox.SoloNumeros(sender, e);


        }
    }

}
