using Controlador.Catalogo;
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

namespace SistemaFerretero.Forms.Menus.Catalogo
{
    public partial class FrmEleccionCliente : Form
    {
        public FrmClienteJuridico frCJ;
        public FrmClienteNatural frCN;
        public Controles Servicios;
        private FrmCatalogModel Model;
        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public FrmEleccionCliente(Controlador.Catalogo.Controles servicios, FrmCatalogModel frmCatalogModel)
        {
            Servicios = servicios;
            Model = frmCatalogModel;
            InitializeComponent();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnClienteNatural_Click(object sender, EventArgs e)
        {
            frCN = new FrmClienteNatural(Servicios);
            frCN.Flag = true;
            frCN.CatalogModel = Model;
            this.Close();
            frCN.ShowDialog();
        }

        private void btnClienteJuridico_Click(object sender, EventArgs e)
        {
            frCJ = new FrmClienteJuridico(Servicios);
            frCJ.Flag = true;
            frCJ.CatalogModel = Model;
            this.Close();
            frCJ.ShowDialog();
        }

        private void pnlBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
