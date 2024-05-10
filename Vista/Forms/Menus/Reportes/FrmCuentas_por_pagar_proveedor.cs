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
    public partial class FrmCuentas_por_pagar_proveedor : Form
    {
        private DateTime FechaInicial;
        private DateTime FechaFinal;
        private string Estado;

        public FrmCuentas_por_pagar_proveedor()
        {
            InitializeComponent();

            FechaInicial = DateTime.Parse("01/01/2019");
            FechaFinal = DateTime.Now;

            RefrescarReporte();
        }

        private void FrmCuentas_por_pagar_proveedor_Load(object sender, EventArgs e)
        {
            RefrescarReporte();
        }

        private void RefrescarReporte()
        {
            this.reporte_Cuentas_por_pagar_proveedorTableAdapter.Fill(this.ferreteriaDataSet.Reporte_Cuentas_por_pagar_proveedor);
            this.reportViewer1.RefreshReport();
        }
    }

    public enum EnumPago
    {
        Seleccione_una_ópcion,Pendiente,Pagado
    }
}
