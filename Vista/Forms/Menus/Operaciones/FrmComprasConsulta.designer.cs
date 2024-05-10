namespace SistemaFerretero.Forms.Menus.Reportes
{
    partial class FrmComprasConsulta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComprasConsulta));
            this.tbPVentas = new System.Windows.Forms.TabControl();
            this.tpPReporteCompras = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbPReporteDetCompras = new System.Windows.Forms.TabPage();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlBarraTitulo = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.visualizarComprasPeriodoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.visualizarComprasPeriodoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ferreteriaDataSetOperaciones = new SistemaFerretero.FerreteriaDataSetOperaciones();
            this.visualizarDetComprasPeriodoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Visualizar_DetComprasPeriodoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.visualizar_ComprasPeriodoTableAdapter = new SistemaFerretero.FerreteriaDataSetOperacionesTableAdapters.Visualizar_ComprasPeriodoTableAdapter();
            this.visualizar_DetComprasPeriodoTableAdapter = new SistemaFerretero.FerreteriaDataSetOperacionesTableAdapters.Visualizar_DetComprasPeriodoTableAdapter();
            this.tbPVentas.SuspendLayout();
            this.tpPReporteCompras.SuspendLayout();
            this.tbPReporteDetCompras.SuspendLayout();
            this.pnlBarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarComprasPeriodoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarComprasPeriodoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSetOperaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarDetComprasPeriodoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Visualizar_DetComprasPeriodoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPVentas
            // 
            this.tbPVentas.Controls.Add(this.tpPReporteCompras);
            this.tbPVentas.Controls.Add(this.tbPReporteDetCompras);
            this.tbPVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPVentas.Location = new System.Drawing.Point(0, 28);
            this.tbPVentas.Name = "tbPVentas";
            this.tbPVentas.SelectedIndex = 0;
            this.tbPVentas.Size = new System.Drawing.Size(800, 422);
            this.tbPVentas.TabIndex = 12;
            // 
            // tpPReporteCompras
            // 
            this.tpPReporteCompras.Controls.Add(this.reportViewer1);
            this.tpPReporteCompras.Location = new System.Drawing.Point(4, 22);
            this.tpPReporteCompras.Name = "tpPReporteCompras";
            this.tpPReporteCompras.Padding = new System.Windows.Forms.Padding(3);
            this.tpPReporteCompras.Size = new System.Drawing.Size(792, 396);
            this.tpPReporteCompras.TabIndex = 0;
            this.tpPReporteCompras.Text = "Reporte Compras";
            this.tpPReporteCompras.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetCompra";
            reportDataSource1.Value = this.visualizarComprasPeriodoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaFerretero.ReportModels.ComprasReporteReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(786, 390);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // tbPReporteDetCompras
            // 
            this.tbPReporteDetCompras.Controls.Add(this.reportViewer2);
            this.tbPReporteDetCompras.Location = new System.Drawing.Point(4, 22);
            this.tbPReporteDetCompras.Name = "tbPReporteDetCompras";
            this.tbPReporteDetCompras.Padding = new System.Windows.Forms.Padding(3);
            this.tbPReporteDetCompras.Size = new System.Drawing.Size(792, 396);
            this.tbPReporteDetCompras.TabIndex = 1;
            this.tbPReporteDetCompras.Text = "Reporte Detalle Compras";
            this.tbPReporteDetCompras.UseVisualStyleBackColor = true;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSetDetalleCompra";
            reportDataSource2.Value = this.visualizarDetComprasPeriodoBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "SistemaFerretero.ReportModels.DetalleCompraReport.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(3, 3);
            this.reportViewer2.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(786, 390);
            this.reportViewer2.TabIndex = 0;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // pnlBarraTitulo
            // 
            this.pnlBarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.pnlBarraTitulo.Controls.Add(this.btnCerrar);
            this.pnlBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraTitulo.Name = "pnlBarraTitulo";
            this.pnlBarraTitulo.Size = new System.Drawing.Size(800, 28);
            this.pnlBarraTitulo.TabIndex = 11;
            this.pnlBarraTitulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlBarraTitulo_MouseMove);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::SistemaFerretero.Properties.Resources.letra_x;
            this.btnCerrar.Location = new System.Drawing.Point(770, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(20, 20);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // visualizarComprasPeriodoBindingSource
            // 
            this.visualizarComprasPeriodoBindingSource.DataMember = "Visualizar_ComprasPeriodo";
            this.visualizarComprasPeriodoBindingSource.DataSource = this.ferreteriaDataSetOperaciones;
            // 
            // ferreteriaDataSetOperaciones
            // 
            this.ferreteriaDataSetOperaciones.DataSetName = "FerreteriaDataSetOperaciones";
            this.ferreteriaDataSetOperaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // visualizarDetComprasPeriodoBindingSource
            // 
            this.visualizarDetComprasPeriodoBindingSource.DataMember = "Visualizar_DetComprasPeriodo";
            this.visualizarDetComprasPeriodoBindingSource.DataSource = this.ferreteriaDataSetOperaciones;
            // 
            // Visualizar_DetComprasPeriodoBindingSource
            // 
            this.Visualizar_DetComprasPeriodoBindingSource.DataMember = "Visualizar_DetComprasPeriodo";
            this.Visualizar_DetComprasPeriodoBindingSource.DataSource = this.ferreteriaDataSetOperaciones;
            // 
            // visualizar_ComprasPeriodoTableAdapter
            // 
            this.visualizar_ComprasPeriodoTableAdapter.ClearBeforeFill = true;
            // 
            // visualizar_DetComprasPeriodoTableAdapter
            // 
            this.visualizar_DetComprasPeriodoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmComprasConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbPVentas);
            this.Controls.Add(this.pnlBarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmComprasConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultas de Compras";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmComprasConsulta_Load);
            this.tbPVentas.ResumeLayout(false);
            this.tpPReporteCompras.ResumeLayout(false);
            this.tbPReporteDetCompras.ResumeLayout(false);
            this.pnlBarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarComprasPeriodoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarComprasPeriodoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSetOperaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarDetComprasPeriodoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Visualizar_DetComprasPeriodoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbPVentas;
        private System.Windows.Forms.TabPage tpPReporteCompras;
        private System.Windows.Forms.TabPage tbPReporteDetCompras;
        private System.Windows.Forms.Panel pnlBarraTitulo;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.BindingSource visualizarComprasPeriodoBindingSource1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource visualizarComprasPeriodoBindingSource;
        private FerreteriaDataSetOperaciones ferreteriaDataSetOperaciones;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private FerreteriaDataSetOperacionesTableAdapters.Visualizar_ComprasPeriodoTableAdapter visualizar_ComprasPeriodoTableAdapter;
        private System.Windows.Forms.BindingSource Visualizar_DetComprasPeriodoBindingSource;
        private System.Windows.Forms.BindingSource visualizarDetComprasPeriodoBindingSource;
        private FerreteriaDataSetOperacionesTableAdapters.Visualizar_DetComprasPeriodoTableAdapter visualizar_DetComprasPeriodoTableAdapter;
    }
}