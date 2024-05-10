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
    public partial class Frm_Ventas : Form
    {
        private DateTime FechaInicial;
        private DateTime FechaFinal;

        public Frm_Ventas()
        {
            InitializeComponent();

            FechaInicial = DateTime.Parse("01/01/2019");
            FechaFinal = DateTime.Now;

            dtpFechaInicio.Value = FechaInicial;
            dtpFechaFinal.Value = FechaFinal;
        }

        private void Frm_Ventas_Load(object sender, EventArgs e)
        {
            RefrescarReporte();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value.CompareTo(dtpFechaFinal.Value) == 1)
            {
                MessageBox.Show("La fecha inicial debe ser menor a la fecha final", "Consulta errónea", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            RefrescarReporte();
        }

        private void RefrescarReporte()
        {
            FechaInicial = dtpFechaInicio.Value;
            FechaFinal = dtpFechaFinal.Value;

            visualizar_VentasPeriodoTableAdapter.Fill(ferreteriaDataSetOperaciones.Visualizar_VentasPeriodo,FechaInicial,FechaFinal);
            rvVentas.RefreshReport();
        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpFechaFinal.Value = DateTime.Now;
            RefrescarReporte();
        }

        private void btnUltimosSiete_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today.AddDays(-7);
            dtpFechaFinal.Value = DateTime.Now;
            RefrescarReporte();
        }
    }
}
