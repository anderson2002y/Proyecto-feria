using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFerretero.Forms.Menus.Reportes
{
    public partial class FrmDevolucion_Compra : Form
    {
        private DateTime FechaInicial;
        private DateTime FechaFinal;
        private string Estado;

        public FrmDevolucion_Compra()
        {
            InitializeComponent();

            FechaInicial = DateTime.Parse("01/01/2019");
            FechaFinal = DateTime.Now;

            dtpFechaInicio.Value = FechaInicial;
            dtpFechaFinal.Value = FechaFinal;

            CargarComboBox();
            RefrescarReporte();
        }

        private void CargarComboBox()
        {
            cmbEstado.Items.Clear();

            List<string> estados = new List<string>();
            foreach (var estado in Enum.GetValues(typeof(EnumDevVenta)))
            {
                estados.Add(estado.ToString().Replace("_", " "));
            }

            cmbEstado.Items.AddRange(estados.ToArray());
            cmbEstado.SelectedIndex = 0;
        }

        private void FrmDevolucion_Compra_Load(object sender, EventArgs e)
        {
            this.rv.RefreshReport();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value.CompareTo(dtpFechaFinal.Value) == 1)
            {
                MessageBox.Show("La fecha inicial debe ser menor a la fecha final", "Consulta errónea", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (cmbEstado.SelectedIndex == 0 && checkTodo.Checked == false)
            {
                MessageBox.Show("Seleccione un estado", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RefrescarReporte();
        }

        private void RefrescarReporte()
        {
            FechaInicial = dtpFechaInicio.Value;
            FechaFinal = dtpFechaFinal.Value;
            Estado = cmbEstado.SelectedItem.ToString();

            if (checkTodo.Checked == true)
            {
                Estado = "Todo";
            }

            reporte_Devolucion_Compra_Entre_Fechas_Por_EstadoTableAdapter.Fill(ferreteriaDataSet.Reporte_Devolucion_Compra_Entre_Fechas_Por_Estado,FechaInicial,FechaFinal,Estado);
            rv.RefreshReport();
        }

        public enum EnumDevVenta
        {
            Seleccione_una_ópcion, No_Aceptado, Aceptado, Recibido
        }
    }
}
