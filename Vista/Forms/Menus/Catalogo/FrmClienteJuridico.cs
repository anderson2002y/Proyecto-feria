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
    public partial class FrmClienteJuridico : Form
    {
        public Controles Servicios;
        public ClienteJuridico Cj;
        public bool Flag;
        public FrmCatalogModel CatalogModel;

        public FrmClienteJuridico(Controlador.Catalogo.Controles servicios)
        {
            Servicios = servicios;
            InitializeComponent();
        }

        public FrmClienteJuridico(Controlador.Catalogo.Controles servicios,ClienteJuridico cj)
        {
            InitializeComponent();
            Servicios = servicios;
            Cj = cj;
            CargarDatosActualizar();
        }

        public void CargarDatosActualizar()
        {
            if (Flag == false)
            {
                txtEmpresa.Text = Cj.NombreCompañia;
                txtRUC.Text = Cj.NoRuc;
                txtPrimerNombre.Text = Cj.PrimerNombre;
                txtSegundoNombre.Text = Cj.SegundoNombre;
                txtPrimerApellido.Text = Cj.PrimerApellido;
                txtSegunApellido.Text = Cj.SegundoApellido;
                txtTelefono.Text = Cj.Telefono;
                txtCorreo.Text = Cj.Correo;
                txtDireccion.Text = Cj.Direccion;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtEmpresa.Text;
            string ruc = txtRUC.Text;
            string pNombre = txtPrimerNombre.Text;
            string sNombre = txtSegundoNombre.Text;
            string pApellido = txtPrimerApellido.Text;
            string sApellido = txtSegunApellido.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text.Replace("-","");
            string correo = txtCorreo.Text;

            if (nombre == "" || pNombre == "" || pApellido == "" || direccion == "" || telefono.Length !=8 || correo == "") 
            {
                MessageBox.Show("Existen campos vacíos","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (ruc.Length != 14)
            {
                MessageBox.Show("El ruc debe tener 14 caracteres","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (telefono.Length != 8)
            {
                MessageBox.Show("El teléfono debe tener 8 caracteres","Mensaje de aviso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if ((correo.Contains("@gmail.com") || correo.Contains("@hotmail.com") || correo.Contains("@yahoo.com")) == false)
            {
                MessageBox.Show("Correo inválido","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            ClienteJuridico cj = new ClienteJuridico()
            {
                NombreCompañia = nombre,
                NoRuc = ruc,
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
                Agregar(cj);
            }
            else
            {
                Actualizar(Cj.Id,cj);
            }

            CatalogModel.RefrescarTabla();
        }
        
        private void Agregar(ClienteJuridico cj)
        {
            Servicios.cCliente.AgregarCJ(cj);

            MessageBox.Show("Se agrego un nuevo cliente", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Actualizar(int id,ClienteJuridico cj)
        {
            Servicios.cCliente.ActualizarCJ(id,cj);
            MessageBox.Show("Se actualizó el cliente","Mensaje de confirmación",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

        private void txtEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionTexTBox.SoloLetras(sender, e);

        }
    }
}
