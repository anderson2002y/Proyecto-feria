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
    public partial class Frm_Productos_Mayor_Recaudacion : Form
    {
        private DateTime FechaInicio;
        private DateTime FechaFinal;
        public Frm_Productos_Mayor_Recaudacion()
        {
            InitializeComponent();

            FechaInicio = DateTime.Parse("01/01/2019"); //Mes/Dia/Año
            FechaFinal = DateTime.Now; //Mes/Dia/Año

            dtpFechaInicio.Value = FechaInicio;
            dtpFechaFinal.Value = FechaFinal;
        }

        private void Frm_Productos_Mayor_Recaudacion_Load(object sender, EventArgs e)
        {
            this.reporte_Productos_Mayor_RecaudacionTableAdapter.Fill(this.ferreteriaDataSet.Reporte_Productos_Mayor_Recaudacion, FechaInicio, FechaFinal);
            this.reportViewer1.RefreshReport();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value.CompareTo(dtpFechaFinal.Value) > 1)
            {
                MessageBox.Show("La fecha inicial debe ser menor a la fecha final", "Consulta errónea", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            Consultar();
        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpFechaFinal.Value = DateTime.Now;
            Consultar();

        }

        private void Consultar()
        {
            FechaInicio = dtpFechaInicio.Value;
            FechaFinal = dtpFechaFinal.Value;

            this.reporte_Productos_Mayor_RecaudacionTableAdapter.Fill(ferreteriaDataSet.Reporte_Productos_Mayor_Recaudacion, FechaInicio, FechaFinal);
            this.reportViewer1.RefreshReport();
        }

        private void btnUltimosSiete_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today.AddDays(-7);
            dtpFechaFinal.Value = DateTime.Now;
            Consultar();
        }
    }
}
