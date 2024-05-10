using SistemaFerretero.Forms;
using SistemaFerretero.Forms.Menus.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFerretero
{
    static class Program
    {
        private static FrmLogin frmLogin;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin = new FrmLogin();
            frmLogin.Show();
            Application.Run();
        }
    }
}