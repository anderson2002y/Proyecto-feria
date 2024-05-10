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
    public partial class FrmClienteNatural : Form
    {
        private Controles Servicios;
        public bool Flag;
        public ClienteNatural Cn;
        public FrmCatalogModel CatalogModel;
        public FrmClienteNatural(Controlador.Catalogo.Controles servicios)
        {
            Servicios = servicios;
            InitializeComponent();
        }

        public FrmClienteNatural(Controlador.Catalogo.Controles servicios,ClienteNatural cn)
        {
            Servicios = servicios;
            InitializeComponent();
            Cn = cn;
            CargarDatosActualizar();
        }

        private void CargarDatosActualizar()
        {
            if (Flag == false)
            {
                txtPrimerNombre.Text = Cn.PrimerNombre;
                txtSegundoNombre.Text = Cn.SegundoNombre;
                txtPrimerApellido.Text = Cn.PrimerApellido;
                txtSegunApellido.Text = Cn.SegundoApellido;
                txtTelefono.Text = Cn.Telefono;
                txtCorreo.Text = Cn.Correo;
                txtDireccion.Text = Cn.Direccion;
            }
        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string pNombre = txtPrimerNombre.Text;
            string sNombre = txtSegundoNombre.Text;
            string pApellido = txtPrimerApellido.Text;
            string sApellido = txtSegunApellido.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text.Replace("-", "");
            string correo = txtCorreo.Text;

            if (pNombre == "" || pApellido == "" || direccion == "" || telefono == "" || correo == "")
            {
                MessageBox.Show("Existen campos vacíos","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (telefono.Length != 8)
            {
                MessageBox.Show("El teléfono debe tener 8 digitos","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if ((correo.Contains("@gmail.com") || correo.Contains("@hotmail.com") || correo.Contains("@yahoo.com")) == false)
            {
                MessageBox.Show("Correo inválido","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            ClienteNatural cn = new ClienteNatural()
            {
                PrimerNombre = pNombre,
                SegundoNombre = sNombre,
                PrimerApellido = pApellido,
                SegundoApellido = sApellido,
                Direccion = direccion,
                Telefono = telefono,
                Correo = correo
            };

            if (Flag == true)
            {
                Agregar(cn);
            }
            else
            {
                Actualizar(cn);
            }

            CatalogModel.RefrescarTabla();
        }

        private void Agregar(ClienteNatural cn)
        {
            Servicios.cCliente.AgregarCN(cn);
            MessageBox.Show("Se registro un nuevo cliente", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Actualizar(ClienteNatural cn)
        {
            Servicios.cCliente.ActualizarCN(Cn.Id,cn);
            MessageBox.Show("Se actualizó el cliente", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionTexTBox.SoloLetras(sender, e);

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
    }
}
