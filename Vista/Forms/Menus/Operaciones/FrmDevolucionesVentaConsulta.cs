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

namespace SistemaFerretero.Forms.Menus.Operaciones
{
    public partial class FrmDevolucionesVentaConsulta : Form
    {
        private DateTime FechaInicial;
        private DateTime FechaFinal;
        public FrmDevolucionesVentaConsulta(DateTime fechaInicial,DateTime fechaFinal)
        {
            InitializeComponent();

            FechaInicial = fechaInicial;
            FechaFinal = fechaFinal;

            this.visualizar_DevVentasPeriodoTableAdapter.Fill(this.ferreteriaDataSetOperaciones.Visualizar_DevVentasPeriodo, fechaInicial, fechaFinal);
            this.reportViewer1.RefreshReport();
        }

        private void FrmDevolucionesVentaConsulta_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
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
    }

    
}
