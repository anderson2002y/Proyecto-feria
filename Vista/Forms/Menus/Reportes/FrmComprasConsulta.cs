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
    public partial class FrmComprasConsulta : Form
    {
        public FrmComprasConsulta(DateTime fechaInicial, DateTime fechaFinal)
        {
            InitializeComponent();
            this.visualizar_ComprasPeriodoTableAdapter.Fill(this.ferreteriaDataSetOperaciones.Visualizar_ComprasPeriodo, fechaInicial, fechaFinal);
            this.visualizar_DetComprasPeriodoTableAdapter.Fill(this.ferreteriaDataSetOperaciones.Visualizar_DetComprasPeriodo, fechaInicial, fechaFinal);
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }

        private void FrmComprasConsulta_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();

        }
    }
}
