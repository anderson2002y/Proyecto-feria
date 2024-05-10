using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace SistemaFerretero.Forms
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
            //Bitmap img = new Bitmap(Application.StartupPath+@"LogoFerreteria.png");
          //  this.BackgroundImage = img;
           // this.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            ActualizarReport();
        }

        private void ActualizarReport()
        {
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToString("HH:mm:ss");
            labelFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void labelFecha_Click(object sender, EventArgs e)
        {

        }

        private void labelFecha_Click_1(object sender, EventArgs e)
        {

        }
    }
}
         


