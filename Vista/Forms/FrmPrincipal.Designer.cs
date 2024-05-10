
namespace SistemaFerretero
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelFormularios = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCatalogo = new System.Windows.Forms.Button();
            this.btnOperaciones = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnSeguridad = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelBarraTitulo = new System.Windows.Forms.Panel();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.menuCatalogos = new SistemaFerretero.Componentes.RJDropDownMenu(this.components);
            this.clientesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOperaciones = new SistemaFerretero.Componentes.RJDropDownMenu(this.components);
            this.comprasItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devolucionesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devolucionesDeVentasItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devolucionesDeCompraItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportes = new SistemaFerretero.Componentes.RJDropDownMenu(this.components);
            this.comprasRItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasRItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devolucionesComprasRItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devolucionesVentasRItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentasPagarRItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesConMayorIngresosRItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesFrecuenciaRItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosMayorRecaudacionRItem = new System.Windows.Forms.ToolStripMenuItem();
            this.top10ProductosMasVendidosRItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otrosReportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeguridad = new SistemaFerretero.Componentes.RJDropDownMenu(this.components);
            this.usuariosItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.respaldarBDItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelContenedor.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelBarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.menuCatalogos.SuspendLayout();
            this.menuOperaciones.SuspendLayout();
            this.menuReportes.SuspendLayout();
            this.menuSeguridad.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelContenedor.Controls.Add(this.panelFormularios);
            this.panelContenedor.Controls.Add(this.panelMenu);
            this.panelContenedor.Controls.Add(this.panelBarraTitulo);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(856, 487);
            this.panelContenedor.TabIndex = 0;
            // 
            // panelFormularios
            // 
            this.panelFormularios.BackColor = System.Drawing.SystemColors.Control;
            this.panelFormularios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormularios.Location = new System.Drawing.Point(193, 27);
            this.panelFormularios.Name = "panelFormularios";
            this.panelFormularios.Size = new System.Drawing.Size(663, 460);
            this.panelFormularios.TabIndex = 2;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Controls.Add(this.flowLayoutPanel1);
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 27);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(193, 460);
            this.panelMenu.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRol);
            this.panel1.Controls.Add(this.lblUsuario);
            this.panel1.Controls.Add(this.lbl2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 268);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 192);
            this.panel1.TabIndex = 1;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(19, 129);
            this.lblRol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(42, 19);
            this.lblRol.TabIndex = 8;
            this.lblRol.Text = "Value";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(19, 62);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(42, 19);
            this.lblUsuario.TabIndex = 7;
            this.lblUsuario.Text = "Value";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.Color.White;
            this.lbl2.Location = new System.Drawing.Point(19, 103);
            this.lbl2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(31, 19);
            this.lbl2.TabIndex = 5;
            this.lbl2.Text = "Rol:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Usuario:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCatalogo);
            this.flowLayoutPanel1.Controls.Add(this.btnOperaciones);
            this.flowLayoutPanel1.Controls.Add(this.btnReportes);
            this.flowLayoutPanel1.Controls.Add(this.btnSeguridad);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 92);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(193, 176);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnCatalogo
            // 
            this.btnCatalogo.FlatAppearance.BorderSize = 0;
            this.btnCatalogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatalogo.Font = new System.Drawing.Font("Britannic Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatalogo.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCatalogo.Image = global::SistemaFerretero.Properties.Resources.Catalogo;
            this.btnCatalogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCatalogo.Location = new System.Drawing.Point(2, 2);
            this.btnCatalogo.Margin = new System.Windows.Forms.Padding(2);
            this.btnCatalogo.Name = "btnCatalogo";
            this.btnCatalogo.Size = new System.Drawing.Size(193, 40);
            this.btnCatalogo.TabIndex = 0;
            this.btnCatalogo.Text = "Catálogo";
            this.btnCatalogo.UseVisualStyleBackColor = true;
            this.btnCatalogo.Click += new System.EventHandler(this.btnCatalogo_Click);
            // 
            // btnOperaciones
            // 
            this.btnOperaciones.FlatAppearance.BorderSize = 0;
            this.btnOperaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOperaciones.Font = new System.Drawing.Font("Britannic Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOperaciones.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOperaciones.Image = global::SistemaFerretero.Properties.Resources.Transaccion;
            this.btnOperaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOperaciones.Location = new System.Drawing.Point(2, 46);
            this.btnOperaciones.Margin = new System.Windows.Forms.Padding(2);
            this.btnOperaciones.Name = "btnOperaciones";
            this.btnOperaciones.Size = new System.Drawing.Size(193, 40);
            this.btnOperaciones.TabIndex = 1;
            this.btnOperaciones.Text = "     Operaciones";
            this.btnOperaciones.UseVisualStyleBackColor = true;
            this.btnOperaciones.Click += new System.EventHandler(this.btnOperaciones_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Britannic Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReportes.Image = global::SistemaFerretero.Properties.Resources.Reporte;
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Location = new System.Drawing.Point(2, 90);
            this.btnReportes.Margin = new System.Windows.Forms.Padding(2);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(193, 40);
            this.btnReportes.TabIndex = 2;
            this.btnReportes.Text = " Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnSeguridad
            // 
            this.btnSeguridad.FlatAppearance.BorderSize = 0;
            this.btnSeguridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeguridad.Font = new System.Drawing.Font("Britannic Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeguridad.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSeguridad.Image = global::SistemaFerretero.Properties.Resources.Seguridad;
            this.btnSeguridad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeguridad.Location = new System.Drawing.Point(2, 134);
            this.btnSeguridad.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeguridad.Name = "btnSeguridad";
            this.btnSeguridad.Size = new System.Drawing.Size(193, 40);
            this.btnSeguridad.TabIndex = 3;
            this.btnSeguridad.Text = "   Seguridad";
            this.btnSeguridad.UseVisualStyleBackColor = true;
            this.btnSeguridad.Click += new System.EventHandler(this.btnSeguridad_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::SistemaFerretero.Properties.Resources.Logo_Ferreteria;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelBarraTitulo
            // 
            this.panelBarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(29)))), ((int)(((byte)(50)))));
            this.panelBarraTitulo.Controls.Add(this.btnRestaurar);
            this.panelBarraTitulo.Controls.Add(this.btnMaximizar);
            this.panelBarraTitulo.Controls.Add(this.btnMinimizar);
            this.panelBarraTitulo.Controls.Add(this.btnCerrar);
            this.panelBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelBarraTitulo.Name = "panelBarraTitulo";
            this.panelBarraTitulo.Size = new System.Drawing.Size(856, 27);
            this.panelBarraTitulo.TabIndex = 0;
            this.panelBarraTitulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBarraTitulo_MouseMove);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.Image = global::SistemaFerretero.Properties.Resources.subir;
            this.btnRestaurar.Location = new System.Drawing.Point(798, 4);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(20, 20);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRestaurar.TabIndex = 3;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Visible = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = global::SistemaFerretero.Properties.Resources.maximizar;
            this.btnMaximizar.Location = new System.Drawing.Point(798, 3);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(20, 20);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximizar.TabIndex = 2;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = global::SistemaFerretero.Properties.Resources.minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(772, 3);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(20, 20);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 1;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::SistemaFerretero.Properties.Resources.letra_x;
            this.btnCerrar.Location = new System.Drawing.Point(824, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(20, 20);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // menuCatalogos
            // 
            this.menuCatalogos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(96)))), ((int)(((byte)(170)))));
            this.menuCatalogos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuCatalogos.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuCatalogos.IsMainMenu = false;
            this.menuCatalogos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesItem,
            this.proveedoresItem,
            this.empleadosItem,
            this.productosItem});
            this.menuCatalogos.MenuItemHeight = 25;
            this.menuCatalogos.MenuItemTextColor = System.Drawing.Color.Empty;
            this.menuCatalogos.Name = "menuCatalogo";
            this.menuCatalogos.PrimaryColor = System.Drawing.Color.Empty;
            this.menuCatalogos.Size = new System.Drawing.Size(144, 124);
            // 
            // clientesItem
            // 
            this.clientesItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.clientesItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.clientesItem.ForeColor = System.Drawing.Color.White;
            this.clientesItem.Image = global::SistemaFerretero.Properties.Resources.clientes1;
            this.clientesItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clientesItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.clientesItem.Name = "clientesItem";
            this.clientesItem.Size = new System.Drawing.Size(143, 30);
            this.clientesItem.Text = "Cliente";
            this.clientesItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.clientesItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // proveedoresItem
            // 
            this.proveedoresItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.proveedoresItem.ForeColor = System.Drawing.Color.White;
            this.proveedoresItem.Image = global::SistemaFerretero.Properties.Resources.compras1;
            this.proveedoresItem.Name = "proveedoresItem";
            this.proveedoresItem.Size = new System.Drawing.Size(143, 30);
            this.proveedoresItem.Text = "Proveedor";
            this.proveedoresItem.Click += new System.EventHandler(this.proveedorToolStripMenuItem_Click);
            // 
            // empleadosItem
            // 
            this.empleadosItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.empleadosItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.empleadosItem.ForeColor = System.Drawing.Color.White;
            this.empleadosItem.Image = global::SistemaFerretero.Properties.Resources.empleados1;
            this.empleadosItem.Name = "empleadosItem";
            this.empleadosItem.Size = new System.Drawing.Size(143, 30);
            this.empleadosItem.Text = "Empleado";
            this.empleadosItem.Click += new System.EventHandler(this.empleadoToolStripMenuItem_Click);
            // 
            // productosItem
            // 
            this.productosItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.productosItem.ForeColor = System.Drawing.Color.White;
            this.productosItem.Image = global::SistemaFerretero.Properties.Resources.producto1;
            this.productosItem.Name = "productosItem";
            this.productosItem.Size = new System.Drawing.Size(143, 30);
            this.productosItem.Text = "Producto";
            this.productosItem.Click += new System.EventHandler(this.productoToolStripMenuItem_Click);
            // 
            // menuOperaciones
            // 
            this.menuOperaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(96)))), ((int)(((byte)(170)))));
            this.menuOperaciones.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuOperaciones.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuOperaciones.IsMainMenu = false;
            this.menuOperaciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comprasItem,
            this.ventasItem,
            this.devolucionesItem});
            this.menuOperaciones.MenuItemHeight = 25;
            this.menuOperaciones.MenuItemTextColor = System.Drawing.Color.Empty;
            this.menuOperaciones.Name = "menuOperaciones";
            this.menuOperaciones.PrimaryColor = System.Drawing.Color.Empty;
            this.menuOperaciones.Size = new System.Drawing.Size(189, 116);
            // 
            // comprasItem
            // 
            this.comprasItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.comprasItem.ForeColor = System.Drawing.Color.White;
            this.comprasItem.Image = global::SistemaFerretero.Properties.Resources.shopping_cart_115264;
            this.comprasItem.Name = "comprasItem";
            this.comprasItem.Size = new System.Drawing.Size(188, 30);
            this.comprasItem.Text = "Compras";
            this.comprasItem.Click += new System.EventHandler(this.comprasToolStripMenuItem_Click);
            // 
            // ventasItem
            // 
            this.ventasItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.ventasItem.ForeColor = System.Drawing.Color.White;
            this.ventasItem.Image = global::SistemaFerretero.Properties.Resources.grafico_de_barras;
            this.ventasItem.Name = "ventasItem";
            this.ventasItem.Size = new System.Drawing.Size(188, 30);
            this.ventasItem.Text = "Ventas";
            this.ventasItem.Click += new System.EventHandler(this.ventasToolStripMenuItem_Click);
            // 
            // devolucionesItem
            // 
            this.devolucionesItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.devolucionesItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.devolucionesDeVentasItem,
            this.devolucionesDeCompraItem});
            this.devolucionesItem.ForeColor = System.Drawing.Color.White;
            this.devolucionesItem.Image = global::SistemaFerretero.Properties.Resources.devoluciones;
            this.devolucionesItem.Name = "devolucionesItem";
            this.devolucionesItem.Size = new System.Drawing.Size(188, 30);
            this.devolucionesItem.Text = "Devoluciones";
            // 
            // devolucionesDeVentasItem
            // 
            this.devolucionesDeVentasItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.devolucionesDeVentasItem.ForeColor = System.Drawing.Color.White;
            this.devolucionesDeVentasItem.Name = "devolucionesDeVentasItem";
            this.devolucionesDeVentasItem.Size = new System.Drawing.Size(220, 22);
            this.devolucionesDeVentasItem.Text = "Devoluciones de Ventas";
            this.devolucionesDeVentasItem.Click += new System.EventHandler(this.devolucionesDeVentasToolStripMenuItem_Click);
            // 
            // devolucionesDeCompraItem
            // 
            this.devolucionesDeCompraItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.devolucionesDeCompraItem.ForeColor = System.Drawing.Color.White;
            this.devolucionesDeCompraItem.Name = "devolucionesDeCompraItem";
            this.devolucionesDeCompraItem.Size = new System.Drawing.Size(220, 22);
            this.devolucionesDeCompraItem.Text = "Devoluciones de Compra";
            this.devolucionesDeCompraItem.Click += new System.EventHandler(this.devolucionesDeCompraToolStripMenuItem_Click);
            // 
            // menuReportes
            // 
            this.menuReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(96)))), ((int)(((byte)(170)))));
            this.menuReportes.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuReportes.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuReportes.IsMainMenu = false;
            this.menuReportes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comprasRItem,
            this.ventasRItem,
            this.devolucionesComprasRItem,
            this.devolucionesVentasRItem,
            this.cuentasPagarRItem,
            this.clientesConMayorIngresosRItem,
            this.clientesFrecuenciaRItem,
            this.productosMayorRecaudacionRItem,
            this.top10ProductosMasVendidosRItem,
            this.otrosReportesToolStripMenuItem});
            this.menuReportes.MenuItemHeight = 25;
            this.menuReportes.MenuItemTextColor = System.Drawing.Color.Empty;
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.PrimaryColor = System.Drawing.Color.Empty;
            this.menuReportes.Size = new System.Drawing.Size(305, 304);
            // 
            // comprasRItem
            // 
            this.comprasRItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.comprasRItem.ForeColor = System.Drawing.Color.White;
            this.comprasRItem.Image = global::SistemaFerretero.Properties.Resources.reporteCompras;
            this.comprasRItem.Name = "comprasRItem";
            this.comprasRItem.Size = new System.Drawing.Size(304, 30);
            this.comprasRItem.Text = "Compras";
            this.comprasRItem.Click += new System.EventHandler(this.ComprasRToolStripMenuItem_Click);
            // 
            // ventasRItem
            // 
            this.ventasRItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.ventasRItem.ForeColor = System.Drawing.Color.White;
            this.ventasRItem.Image = ((System.Drawing.Image)(resources.GetObject("ventasRItem.Image")));
            this.ventasRItem.Name = "ventasRItem";
            this.ventasRItem.Size = new System.Drawing.Size(304, 30);
            this.ventasRItem.Text = "Ventas";
            this.ventasRItem.Click += new System.EventHandler(this.VentasRStripMenuItem_Click);
            // 
            // devolucionesComprasRItem
            // 
            this.devolucionesComprasRItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.devolucionesComprasRItem.ForeColor = System.Drawing.Color.White;
            this.devolucionesComprasRItem.Image = global::SistemaFerretero.Properties.Resources.caja_de_devolucion;
            this.devolucionesComprasRItem.Name = "devolucionesComprasRItem";
            this.devolucionesComprasRItem.Size = new System.Drawing.Size(304, 30);
            this.devolucionesComprasRItem.Text = "Devoluciones de compras";
            this.devolucionesComprasRItem.Click += new System.EventHandler(this.devolucionesComprasRToolStripMenuItem_Click);
            // 
            // devolucionesVentasRItem
            // 
            this.devolucionesVentasRItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.devolucionesVentasRItem.ForeColor = System.Drawing.Color.White;
            this.devolucionesVentasRItem.Image = global::SistemaFerretero.Properties.Resources.caja_de_devolucionVenta;
            this.devolucionesVentasRItem.Name = "devolucionesVentasRItem";
            this.devolucionesVentasRItem.Size = new System.Drawing.Size(304, 30);
            this.devolucionesVentasRItem.Text = "Devoluciones de ventas";
            this.devolucionesVentasRItem.Click += new System.EventHandler(this.DevolucionesVentasToolStripMenuItem_Click);
            // 
            // cuentasPagarRItem
            // 
            this.cuentasPagarRItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.cuentasPagarRItem.ForeColor = System.Drawing.Color.White;
            this.cuentasPagarRItem.Image = ((System.Drawing.Image)(resources.GetObject("cuentasPagarRItem.Image")));
            this.cuentasPagarRItem.Name = "cuentasPagarRItem";
            this.cuentasPagarRItem.Size = new System.Drawing.Size(304, 30);
            this.cuentasPagarRItem.Text = "Cuentas por pagar";
            this.cuentasPagarRItem.Click += new System.EventHandler(this.cuentasPagarRToolStripMenuItem_Click);
            // 
            // clientesConMayorIngresosRItem
            // 
            this.clientesConMayorIngresosRItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.clientesConMayorIngresosRItem.ForeColor = System.Drawing.Color.White;
            this.clientesConMayorIngresosRItem.Image = global::SistemaFerretero.Properties.Resources.recaudacion_de_fondosCliente;
            this.clientesConMayorIngresosRItem.Name = "clientesConMayorIngresosRItem";
            this.clientesConMayorIngresosRItem.Size = new System.Drawing.Size(304, 30);
            this.clientesConMayorIngresosRItem.Text = "Clientes con mayor monto de ingresos";
            this.clientesConMayorIngresosRItem.Click += new System.EventHandler(this.clientesIngresosRToolStripMenuItem_Click);
            // 
            // clientesFrecuenciaRItem
            // 
            this.clientesFrecuenciaRItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.clientesFrecuenciaRItem.ForeColor = System.Drawing.Color.White;
            this.clientesFrecuenciaRItem.Image = ((System.Drawing.Image)(resources.GetObject("clientesFrecuenciaRItem.Image")));
            this.clientesFrecuenciaRItem.Name = "clientesFrecuenciaRItem";
            this.clientesFrecuenciaRItem.Size = new System.Drawing.Size(304, 30);
            this.clientesFrecuenciaRItem.Text = "Clientes con mayor frecuencia";
            this.clientesFrecuenciaRItem.Click += new System.EventHandler(this.clientesFrecuenciaRToolStripMenuItem_Click);
            // 
            // productosMayorRecaudacionRItem
            // 
            this.productosMayorRecaudacionRItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.productosMayorRecaudacionRItem.ForeColor = System.Drawing.Color.White;
            this.productosMayorRecaudacionRItem.Image = global::SistemaFerretero.Properties.Resources.recaudacion_de_fondos;
            this.productosMayorRecaudacionRItem.Name = "productosMayorRecaudacionRItem";
            this.productosMayorRecaudacionRItem.Size = new System.Drawing.Size(304, 30);
            this.productosMayorRecaudacionRItem.Text = "Productos con mayor recaudación";
            this.productosMayorRecaudacionRItem.Click += new System.EventHandler(this.ProductosMayorRecaudacionToolStripMenuItem_Click);
            // 
            // top10ProductosMasVendidosRItem
            // 
            this.top10ProductosMasVendidosRItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.top10ProductosMasVendidosRItem.ForeColor = System.Drawing.Color.White;
            this.top10ProductosMasVendidosRItem.Image = global::SistemaFerretero.Properties.Resources.grafico_de_barras;
            this.top10ProductosMasVendidosRItem.Name = "top10ProductosMasVendidosRItem";
            this.top10ProductosMasVendidosRItem.Size = new System.Drawing.Size(304, 30);
            this.top10ProductosMasVendidosRItem.Text = "Top 10 productos mas vendidos";
            this.top10ProductosMasVendidosRItem.Click += new System.EventHandler(this.top10ProductosMasVendidosToolStripMenuItem_Click);
            // 
            // otrosReportesToolStripMenuItem
            // 
            this.otrosReportesToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.otrosReportesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.otrosReportesToolStripMenuItem.Image = global::SistemaFerretero.Properties.Resources.reporte__1_1;
            this.otrosReportesToolStripMenuItem.Name = "otrosReportesToolStripMenuItem";
            this.otrosReportesToolStripMenuItem.Size = new System.Drawing.Size(304, 30);
            this.otrosReportesToolStripMenuItem.Text = "Otros reportes";
            this.otrosReportesToolStripMenuItem.Click += new System.EventHandler(this.otrosReportesToolStripMenuItem_Click);
            // 
            // menuSeguridad
            // 
            this.menuSeguridad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(96)))), ((int)(((byte)(170)))));
            this.menuSeguridad.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuSeguridad.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuSeguridad.IsMainMenu = false;
            this.menuSeguridad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosItem,
            this.rolesItem,
            this.respaldarBDItem,
            this.cambiarContraseñaItem,
            this.cerrarSesiónItem});
            this.menuSeguridad.MenuItemHeight = 25;
            this.menuSeguridad.MenuItemTextColor = System.Drawing.Color.Empty;
            this.menuSeguridad.Name = "menuSeguridad";
            this.menuSeguridad.PrimaryColor = System.Drawing.Color.Empty;
            this.menuSeguridad.Size = new System.Drawing.Size(231, 154);
            // 
            // usuariosItem
            // 
            this.usuariosItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.usuariosItem.ForeColor = System.Drawing.Color.White;
            this.usuariosItem.Image = global::SistemaFerretero.Properties.Resources.programador;
            this.usuariosItem.Name = "usuariosItem";
            this.usuariosItem.Size = new System.Drawing.Size(230, 30);
            this.usuariosItem.Text = "Gestionar usuarios";
            this.usuariosItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // rolesItem
            // 
            this.rolesItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.rolesItem.ForeColor = System.Drawing.Color.White;
            this.rolesItem.Name = "rolesItem";
            this.rolesItem.Size = new System.Drawing.Size(230, 30);
            this.rolesItem.Text = "Gestionar roles";
            this.rolesItem.Click += new System.EventHandler(this.rolesItem_Click);
            // 
            // respaldarBDItem
            // 
            this.respaldarBDItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.respaldarBDItem.ForeColor = System.Drawing.Color.White;
            this.respaldarBDItem.Image = global::SistemaFerretero.Properties.Resources.archivo_de_respaldo;
            this.respaldarBDItem.Name = "respaldarBDItem";
            this.respaldarBDItem.Size = new System.Drawing.Size(230, 30);
            this.respaldarBDItem.Text = "Respaldar Base de datos";
            // 
            // cambiarContraseñaItem
            // 
            this.cambiarContraseñaItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.cambiarContraseñaItem.ForeColor = System.Drawing.Color.White;
            this.cambiarContraseñaItem.Image = global::SistemaFerretero.Properties.Resources.restablecer_la_contrasena;
            this.cambiarContraseñaItem.Name = "cambiarContraseñaItem";
            this.cambiarContraseñaItem.Size = new System.Drawing.Size(230, 30);
            this.cambiarContraseñaItem.Text = "Cambiar contraseña";
            this.cambiarContraseñaItem.Click += new System.EventHandler(this.cambiarContraseñaToolStripMenuItem_Click);
            // 
            // cerrarSesiónItem
            // 
            this.cerrarSesiónItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.cerrarSesiónItem.ForeColor = System.Drawing.Color.White;
            this.cerrarSesiónItem.Image = global::SistemaFerretero.Properties.Resources.logout;
            this.cerrarSesiónItem.Name = "cerrarSesiónItem";
            this.cerrarSesiónItem.Size = new System.Drawing.Size(230, 30);
            this.cerrarSesiónItem.Text = "Cerrar Sesión";
            this.cerrarSesiónItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 487);
            this.Controls.Add(this.panelContenedor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(872, 512);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelContenedor.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelBarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.menuCatalogos.ResumeLayout(false);
            this.menuOperaciones.ResumeLayout(false);
            this.menuReportes.ResumeLayout(false);
            this.menuSeguridad.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelBarraTitulo;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.Button btnCatalogo;
        private Componentes.RJDropDownMenu menuCatalogos;
        private System.Windows.Forms.ToolStripMenuItem clientesItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresItem;
        private System.Windows.Forms.ToolStripMenuItem empleadosItem;
        private System.Windows.Forms.ToolStripMenuItem productosItem;
        private System.Windows.Forms.Button btnOperaciones;
        private Componentes.RJDropDownMenu menuOperaciones;
        private System.Windows.Forms.ToolStripMenuItem comprasItem;
        private System.Windows.Forms.ToolStripMenuItem ventasItem;
        private System.Windows.Forms.ToolStripMenuItem devolucionesItem;
        private System.Windows.Forms.Button btnReportes;
        private Componentes.RJDropDownMenu menuReportes;
        private System.Windows.Forms.ToolStripMenuItem comprasRItem;
        private System.Windows.Forms.ToolStripMenuItem devolucionesComprasRItem;
        private System.Windows.Forms.ToolStripMenuItem devolucionesVentasRItem;
        private System.Windows.Forms.Button btnSeguridad;
        private Componentes.RJDropDownMenu menuSeguridad;
        private System.Windows.Forms.ToolStripMenuItem usuariosItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem productosMayorRecaudacionRItem;
        private System.Windows.Forms.ToolStripMenuItem clientesConMayorIngresosRItem;
        private System.Windows.Forms.ToolStripMenuItem otrosReportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem respaldarBDItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaItem;
        private System.Windows.Forms.ToolStripMenuItem devolucionesDeVentasItem;
        private System.Windows.Forms.ToolStripMenuItem devolucionesDeCompraItem;
        private System.Windows.Forms.Panel panelFormularios;
        private System.Windows.Forms.ToolStripMenuItem top10ProductosMasVendidosRItem;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ToolStripMenuItem ventasRItem;
        private System.Windows.Forms.ToolStripMenuItem cuentasPagarRItem;
        private System.Windows.Forms.ToolStripMenuItem clientesFrecuenciaRItem;
        private System.Windows.Forms.ToolStripMenuItem rolesItem;
    }
}

