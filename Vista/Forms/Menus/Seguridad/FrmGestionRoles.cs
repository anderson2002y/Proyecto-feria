using Controlador.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFerretero.Forms.Menus.Seguridad
{
    public partial class FrmGestionRoles : Form
    {
        private Dictionary<int, string> Roles = new Dictionary<int, string>();
        private Dictionary<int, string> Modulos = new Dictionary<int, string>();
        private int IdRol;

        public FrmGestionRoles()
        {
            InitializeComponent();
            CargarComboBox();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void CargarComboBox()
        {
            DataTable dt = CSeguridad.Mostrar_Modulo();

            foreach (DataRow fila in dt.Rows)
            {
                Modulos.Add(fila.Field<int>("IdModulo"), fila.Field<string>("Modulo"));
            }

            cmbModulo.Items.AddRange(Modulos.Values.ToArray());
            cmbModulo.SelectedIndex = 0;

        }

        private void lbxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblRol.Text = string.Empty;
            lblRol.Text = lbxRoles.SelectedItem.ToString();
            IdRol = lbxRoles.SelectedIndex + 1;

        }

        private void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbModulo.SelectedIndex + 1;
            DataTable dt = CSeguridad.Mostrar_Operaciones(index);
            dgvOperaciones.DataSource = dt;

        }
    }
}
