using SistemaFerretero.MenusEnum;
using SistemaFerretero.Forms;
using SistemaFerretero.Forms.Fabrica;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SistemaFerretero.Forms.Menus.Seguridad;
using SistemaFerretero.Forms.Menus.Catalogo;
using Poco;
using SistemaFerretero.Forms.Menus.Operaciones;
using System.Diagnostics;
using Controlador.Validaciones;
using System.Collections.Generic;
using Controlador.Seguridad;
using System.Data;
using System.Linq;

namespace SistemaFerretero
{
    public partial class FrmPrincipal : Form
    {
        private Form FrmDashboard;
        //Fields
        private int borderSize = 2;
        private Size formSize; //Keep form size when it is minimized and restored.Since the form is resized because it takes into account the size of the title bar and borders.
        private FrmLogin Login;
        private FrmCambioContraseña frmCambioContraseña;
        private Dictionary<Modulo,List<Operacion>> Op_Validas;
        private Usuario User;//Diccionario que contiene las operaciones en correspondencia al módulo

        public FrmPrincipal()
        {
            InitializeComponent();
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(04, 29, 50);//Border color
            FrmDashboard = new FrmHome();
            FrmDashboard.Dock = DockStyle.Fill;
            FrmDashboard.TopLevel = false;

            User = new Usuario()
            {
                Nombre = "Desarrollador Nic.",
                Rol = "Desarrollador",
                Username = "developer c.",
            };
        }
        public FrmPrincipal(Usuario u, FrmLogin login)
        {
            InitializeComponent();
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(04,29,50);//Border color
            FrmDashboard = new FrmHome();
            FrmDashboard.Dock = DockStyle.Fill;
            FrmDashboard.TopLevel = false;
            User = u;
            Login = login;

            lblUsuario.Text = User.Nombre;
            lblRol.Text = User.Rol;
            AccesoOperaciones();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelFormularios.Controls.Add(FrmDashboard);
            FrmDashboard.Show();
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-NI");
        }    
        
        private void AccesosModulos()
        {
            DataTable modulos = CSeguridad.Acceso_Rol_Modulo(User.Id);

            //Guardar los modulos y operaciones que tiene acceso
            for (int i = 0; i < modulos.Rows.Count; i++)
            {
                Modulo m = new Modulo()
                {
                    Id = int.Parse(modulos.Rows[i].ItemArray[0].ToString()),
                    Descripcion = modulos.Rows[i].ItemArray[1].ToString()
                };

                List<Operacion> operaciones = new List<Operacion>();

                foreach (DataRow fila in CSeguridad.Acceso_Rol(User.Id, m.Id).Rows)
                {
                    Operacion op = new Operacion()
                    {
                        Id = int.Parse(fila.ItemArray[0].ToString()),
                        Descripcion = fila.ItemArray[2].ToString(),
                        Estado = bool.Parse(fila.ItemArray[3].ToString())
                    };

                    operaciones.Add(op);
                }

                Op_Validas.Add(m, operaciones); //Guardar  en el diccionario
            }
        }
        private void OcultarMenus()
        {
            clientesItem.Visible = false;
            proveedoresItem.Visible = false;
            empleadosItem.Visible = false;
            productosItem.Visible = false;

            comprasItem.Visible = false;
            ventasItem.Visible = false;
            devolucionesDeCompraItem.Visible = false;
            devolucionesDeVentasItem.Visible = false;
            devolucionesItem.Visible = false;

            comprasRItem.Visible = false;
            ventasRItem.Visible = false;
            clientesFrecuenciaRItem.Visible = false;
            clientesConMayorIngresosRItem.Visible = false;
            productosMayorRecaudacionRItem.Visible = false;
            top10ProductosMasVendidosRItem.Visible = false;
            cuentasPagarRItem.Visible = false;
            devolucionesComprasRItem.Visible = false;
            devolucionesVentasRItem.Visible = false;

            usuariosItem.Visible = false;
            rolesItem.Visible = false;
            respaldarBDItem.Visible = false;
        }
        private void AccesoOperaciones()
        {
            Op_Validas = new Dictionary<Modulo, List<Operacion>>();

            OcultarMenus();
            AccesosModulos();

            foreach (List<Operacion> op in Op_Validas.Values)
            {
                List<Operacion> mostrarSubmenus = op.FindAll(x => x.Descripcion.Contains("Visualizar") || x.Descripcion.Contains("Agregar") || x.Descripcion.Contains("Ver reporte"));

                foreach (Operacion o in mostrarSubmenus)
                {
                    o.Descripcion = o.Descripcion.Replace("Agregar ","");
                    o.Descripcion = o.Descripcion.Replace("Visualizar ", "");
                    o.Descripcion = o.Descripcion.Replace("Ver ", "");

                    switch (o.Descripcion)
                    {
                        case "cliente":
                            clientesItem.Visible = o.Estado;
                            break;

                        case "proveedor":
                            proveedoresItem.Visible = o.Estado;
                            break;

                        case "producto":
                            productosItem.Visible = o.Estado;
                            break;

                        case "empleado":
                            empleadosItem.Visible = o.Estado;
                            break;

                        case "compra":
                            comprasItem.Visible = o.Estado;
                            break;

                        case "venta":
                            ventasItem.Visible = o.Estado;
                            break;

                        case "devolución de compra":
                            devolucionesItem.Visible = true;
                            devolucionesDeCompraItem.Visible = o.Estado;
                            break;

                        case "devolución de venta":
                            devolucionesItem.Visible = true;
                            devolucionesDeVentasItem.Visible = o.Estado;
                            break;

                        case "reporte de compras":
                            comprasRItem.Visible = true;
                            break;

                        case "reporte de ventas":
                            ventasRItem.Visible = true;
                            break;

                        case "reporte de devoluciones de compras":
                            devolucionesComprasRItem.Visible = true;
                            break;

                        case "reporte de devoluciones de ventas":
                            devolucionesVentasRItem.Visible = true;
                            break;

                        case "reporte de cuentas por pagar":
                            cuentasPagarRItem.Visible = true;
                            break;

                        case "reporte de clientes con mayor recaudación":
                            clientesConMayorIngresosRItem.Visible = true;
                            break;

                        case "reporte de clientes con mayores ventas realizadas":
                            clientesFrecuenciaRItem.Visible = true;
                            break;

                        case "reporte de productos con mayor recaudación":
                            productosMayorRecaudacionRItem.Visible = true;
                            break;

                        case "reporte de productos más vendidos":
                            top10ProductosMasVendidosRItem.Visible = true;
                            break;

                        default:
                            break;
                    }
                }
            }

            if (User.Rol == "Administrador")
            {
                usuariosItem.Visible = true;
                rolesItem.Visible = true;
                respaldarBDItem.Visible = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult mensaje;

            mensaje = MessageBox.Show("¿Esta seguro de salir?", "Mensaje de aviso",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if (mensaje == DialogResult.OK)
            {
                Application.Exit();
            }
        } 

        public void AbrirPanel(MnForm menu, Enum name)
        {
            panelFormularios.Controls.Clear();
            FrmDashboard.Dispose();
            FrmDashboard = FabricaForms.ObtenerFormulario(menu, name,User);
            FrmDashboard.TopLevel = false;
            FrmDashboard.Dock = DockStyle.Fill;
            
            if (name.ToString() == "Productos")
            {
                FrmCatalogModel modelProducto = (FrmCatalogModel) FrmDashboard;
                panelFormularios.Controls.Add(FrmDashboard);
                modelProducto.frmPrincipal = this;
                FrmDashboard.Show();
                return;
            }

            if (name.ToString() == "Ventas" && User.Rol == "Vendedor")
            {
                FrmVentas frmVentas= (FrmVentas) FrmDashboard;
                panelFormularios.Controls.Add(FrmDashboard);
                frmVentas.User = User;
                FrmDashboard.Show();
                return;
            }

            panelFormularios.Controls.Add(FrmDashboard);
            FrmDashboard.Show();
        }

        public void AbrirPanel(MnForm menu, string name, Producto p)
        {
            panelFormularios.Controls.Clear();
            FrmVentas frmVentas = new FrmVentas(User);
            frmVentas.dgvCarrito.Rows.Add(p.toArray(FormatoString.AgregarFormato(p.Precio)));

            FrmDashboard = frmVentas;
            FrmDashboard.TopLevel = false;
            FrmDashboard.Dock = DockStyle.Fill;

            panelFormularios.Controls.Add(FrmDashboard);
            FrmDashboard.Show();
        }

    #region MenusClicks

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Catalogos, EnumCatalogo.Proveedores);
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Catalogos, EnumCatalogo.Empleados);
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Catalogos, EnumCatalogo.Productos);
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Catalogos, EnumCatalogo.Clientes);
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Operaciones, EnumOperacion.Compras);
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Operaciones, EnumOperacion.Ventas);
        }

        private void devolucionesDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Operaciones, EnumOperacion.Dev_Ventas);
        }

        private void devolucionesDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Operaciones, EnumOperacion.Dev_Compras);
        }

        private void clientesIngresosRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Reportes,EnumReporte.Clientes_Recaudacion);
        }

        private void ComprasRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Reportes, EnumReporte.Compras);
        }

        public void VentasRStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Reportes, EnumReporte.Ventas);
        }

        private void devolucionesComprasRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Reportes,EnumReporte.Dev_Compras);
        }

        private void DevolucionesVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Reportes,EnumReporte.Dev_Ventas);
        }

        private void ProductosMayorRecaudacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Reportes,EnumReporte.Productos_Recaudacion);
        }

        private void top10ProductosMasVendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Reportes, EnumReporte.Productos_Vendidos);
        }
        private void cuentasPagarRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Reportes, EnumReporte.Cuentas_Pagar);
        }

        private void clientesFrecuenciaRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Reportes, EnumReporte.Frecuencia_Clientes);
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Seguridad, EnumSeguridad.Usuarios);
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            menuCatalogos.Show(btnCatalogo, btnCatalogo.Width, 0);
        }

        private void btnOperaciones_Click(object sender, EventArgs e)
        {
            menuOperaciones.Show(btnOperaciones, btnOperaciones.Width, 0);
        }        

        private void btnReportes_Click(object sender, EventArgs e)
        {
            menuReportes.Show(btnReportes, btnReportes.Width, 0);
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            menuSeguridad.Show(btnSeguridad, btnSeguridad.Width, 0);
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCambioContraseña = new FrmCambioContraseña(User);
            frmCambioContraseña.ShowDialog();
            frmCambioContraseña.StartPosition=FormStartPosition.CenterScreen;
        }

        #endregion

    #region MaxMinCerrar
        //captura posicion y tamaño antes de maximizar para restaurar
        int lx, ly;
        int sw, sh;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    #endregion
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login = new FrmLogin();
            Login.Show();
            this.Dispose(true);
        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;
            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion
            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            if (m.Msg == WM_SYSCOMMAND)
            {
                /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
                /// Quote:
                /// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
                /// are used internally by the system.To obtain the correct result when testing 
                /// the value of wParam, an application must combine the value 0xFFF0 with the 
                /// wParam value by using the bitwise AND operator.
                int wParam = (m.WParam.ToInt32() & 0xFFF0);
                if (wParam == SC_MINIMIZE)  //Before
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)// Restored form(Before)
                    this.Size = formSize;
            }
            base.WndProc(ref m);
        }

        private void otrosReportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://app.powerbi.com/view?r=eyJrIjoiZmQ2MTE0N2EtMWIwMy00YTM1LTgwOGYtMGVkNWQ4MGY5YmU3IiwidCI6ImUxMTlmY2ZmLTRmMzUtNDMzOC04MzQzLTc2ZDQ1OTg5NGI2YiIsImMiOjR9");
        }

        private void rolesItem_Click(object sender, EventArgs e)
        {
            AbrirPanel(MnForm.Seguridad,EnumSeguridad.Roles);
        }

        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }
    }
}
