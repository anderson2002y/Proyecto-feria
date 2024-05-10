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

namespace SistemaFerretero.Forms.Menus.Seguridad
{
    public partial class FrmCambioContraseña : Form
    {
        public Usuario User { private get; set; }
        public FrmCambioContraseña(Usuario u)
        {
            User= u;
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string contraseña = txtContraseñaActual.Text;
            string nContraseña = txtNuevaContraseña.Text;
            string nRContraseña = txtNuevaContraseñaR.Text;
            

            DialogResult mensaje;

            if (contraseña =="" || nContraseña == "" || nRContraseña == "")
            {
                mensaje = MessageBox.Show("No pueden haber campos vacios", "Mensaje de Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }else if(nContraseña !=nRContraseña)
            {
                txtNuevaContraseñaR.BackColor = Color.FromArgb(250, 184, 184);
                txtNuevaContraseña.BackColor = Color.FromArgb(250, 184, 184);
                mensaje = MessageBox.Show("Las contraseñas no coinciden, Revise los campos e intentalo otra vez", "Mensaje de Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                int resultado = CUsuario.Actualizar_Contraseña(User.Id, User.Username, contraseña, nContraseña);

                if (resultado == 1)
                {
                    MessageBox.Show("Revise sus credenciales", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (resultado == 2)
                {
                    MessageBox.Show("La nueva contraseña y la anterior son las mismas", "No debe poner la misma contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mensaje= MessageBox.Show("Contraseña Actualizada Correctamente", "Mensaje de Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                this.Close();
            }
            
                
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
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

        private void txtNuevaContraseña_TextChanged(object sender, EventArgs e)
        {
            this.txtNuevaContraseña.BackColor = Color.White;
            this.txtNuevaContraseñaR.BackColor = Color.White;

        }

        private void txtNuevaContraseñaR_TextChanged(object sender, EventArgs e)
        {
            this.txtNuevaContraseña.BackColor = Color.White;

            this.txtNuevaContraseñaR.BackColor = Color.White;

        }
    }
}
