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
    public partial class FrmVentasConsulta : Form
    {
        public FrmVentasConsulta(DateTime fechaInicial , DateTime fechaFinal)
        {
            InitializeComponent();
            this.visualizar_VentasPeriodoTableAdapter1.Fill(this.ferreteriaDataSetOperaciones1.Visualizar_VentasPeriodo, fechaInicial, fechaFinal);
            this.visualizar_DetVentasPeriodoTableAdapter1.Fill(this.ferreteriaDataSetOperaciones1.Visualizar_DetVentasPeriodo, fechaInicial, fechaFinal);
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }


        private void FrmVentasConsulta_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
