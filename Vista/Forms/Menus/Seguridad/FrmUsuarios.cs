using Controlador;
using Controlador.Catalogo;
using Controlador.Seguridad;
using Poco;
using SistemaFerretero.Forms.Menus.Catalogo;
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

namespace SistemaFerretero.Forms.Menus.Seguridad
{
    public partial class FrmUsuarios : Form
    {
        private FrmCatalogModel ModalTemp;
        private FrmCatalogModel FrmCatalogModel;
        private Usuario User;
        private Dictionary<int, string> Roles = new Dictionary<int, string>();
        public bool flag;
        private int IdRol;
        private int IdEmpleado;

        public FrmUsuarios(FrmCatalogModel frmCatalogModel, bool v,Usuario u)
        {
            flag = v;
            FrmCatalogModel = frmCatalogModel;
            User = u;
            InitializeComponent();
            Cargar_Rol();
            Cargar_DatosActualizar();
        }

       
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            DialogResult mensaje;
            if (flag == true)
            {
                Agregar();
                
            }
            else
            {
                int id = Convert.ToInt32(FrmCatalogModel.dgvDatos.SelectedRows[0].Cells[0].Value);
                Actualizar(id, txtRol.Text);
                mensaje = MessageBox.Show("El Usuario "+
                   " Fue Actualizado Correctamente ", "Mensaje de Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }

            FrmCatalogModel.RefrescarTabla();
            this.Close();
        }

        private void Cargar_Rol()
        {
            DataTable dt = CSeguridad.Mostrar_Roles();

            foreach (DataRow fila in dt.Rows)
            {
                Roles.Add(fila.Field<int>("IdRol"), fila.Field<string>("Rol"));
            }

            lbxRoles.Items.AddRange(Roles.Values.ToArray());
            
        }
        private void Cargar_DatosActualizar()
        {
            if (FrmCatalogModel.dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow fila = FrmCatalogModel.dgvDatos.SelectedRows[0];

            if (flag == false)
            {
                lblNombreEmpleado.Text = Convert.ToString(FrmCatalogModel.dgvDatos.SelectedRows[0].Cells[1].Value);
            }
        }

        private void SiActualiza()
        {
            if(flag == false)
            {
                this.txtContraseña.Visible = false;
                label1.Visible = false;
                label2.Location = new Point(24, 107);
                txtRol.Location = new Point(138, 106);
                lblCmb.Location = new Point(130,115);
                lblContra.Visible = false;
                this.Size= new System.Drawing.Size (629, 242);
            }
        }

        private void Agregar()
        {
            DataTable dt = CUsuario.Agregar(User.Id,txtContraseña.Text , IdRol);
            DialogResult mensaje;

            if (dt.Rows.Count == 0)
            {
                mensaje = MessageBox.Show("El Usuario Fue Ingresado Correctamente ", "Mensaje de Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            DataRow fila = dt.Rows[0];

            if (fila.ItemArray[0].ToString() == "El empleado tiene ya un usuario")
            {
                mensaje = MessageBox.Show("El empleado tiene ya un usuario" +
                    "Seleccione un empleado diferente", "Mensaje de Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            
        }

        private void Actualizar(int Id,string rol)
        {
            //CUsuario.Actualizar_Usuario(Id, rol);
        }

        private void ObtenerEmpleado(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = ModalTemp.dgvDatos.SelectedRows[0];

            
            IdEmpleado = int.Parse(row.Cells[0].Value.ToString());
            lblNombreEmpleado.Text = row.Cells[1].Value.ToString();

            ModalTemp.Close();
            ModalTemp.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            SiActualiza();
        }

        private void btnBuscarEmp_Click(object sender, EventArgs e)
        {
            ModalTemp = new FrmCatalogModel(EnumCatalogo.Empleados, User);
            ModalTemp.flowPnlBotones.Visible = false;

            ModalTemp.dgvDatos.CellDoubleClick += ObtenerEmpleado;
            ModalTemp.StartPosition = FormStartPosition.CenterScreen;
            ModalTemp.pnlBarraTitulo.Visible = true;

            ModalTemp.ShowDialog(this);
        }

        private void lbxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRol.Text = string.Empty;
            txtRol.Text = lbxRoles.SelectedItem.ToString();
            IdRol = lbxRoles.SelectedIndex + 1;
           
        }
    }
}
