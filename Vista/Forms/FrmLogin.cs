using Controlador;
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

namespace SistemaFerretero.Forms
{
    public partial class FrmLogin : Form
    {
        private FrmPrincipal Principal;
        public FrmLogin()
        {
            InitializeComponent();
            lblAdvertenciaUser.Visible = false;
            lblAdvertenciaContra.Visible = false;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            if (usuario == "")
            {
                lblAdvertenciaUser.Visible = true;
            }

            if (contraseña == "")
            {
                lblAdvertenciaContra.Visible = true;
            }

            if (usuario == "" || contraseña == "")
            {
                return;
            }

            int acceso = CUsuario.Validar_Acceso(usuario, contraseña);

            if (acceso == 1)
            {
                MessageBox.Show("Revise sus credenciales","Acceso denegado",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (acceso == 2)
            {
                MessageBox.Show("El usuario ya no se encuentra activo","Acceso revocado",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            
            DataRow resultado = CUsuario.Obtener_Usuario(usuario,contraseña).Rows[0];

            Usuario user = new Usuario()
            {
                Id = Convert.ToInt32(resultado.ItemArray[5].ToString()),
                Nombre = resultado.ItemArray[1].ToString(),
                Username = resultado.ItemArray[2].ToString(),
                Rol = resultado.ItemArray[3].ToString()
            };

            Principal = new FrmPrincipal(user,this);
            Principal.Show();
            this.Close();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length != 0)
            {
                lblAdvertenciaUser.Visible = false;
            }
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            if (txtContraseña.TextLength != 0)
            {
                lblAdvertenciaContra.Visible = false;
            }
        }
    }
}
