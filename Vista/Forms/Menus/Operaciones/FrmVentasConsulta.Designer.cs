
namespace SistemaFerretero.Forms.Menus.Reportes
{
    partial class FrmVentasConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVentasConsulta));
            this.visualizarVentasPeriodoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ferreteriaDataSetOperaciones1 = new SistemaFerretero.FerreteriaDataSetOperaciones();
            this.visualizarDetVentasPeriodoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlBarraTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.visualizar_VentasPeriodoTableAdapter1 = new SistemaFerretero.FerreteriaDataSetOperacionesTableAdapters.Visualizar_VentasPeriodoTableAdapter();
            this.visualizar_DetVentasPeriodoTableAdapter1 = new SistemaFerretero.FerreteriaDataSetOperacionesTableAdapters.Visualizar_DetVentasPeriodoTableAdapter();
            this.tbPVentas = new System.Windows.Forms.TabControl();
            this.tpPReporteVentas = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbPReporteDetVentas = new System.Windows.Forms.TabPage();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarVentasPeriodoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSetOperaciones1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarDetVentasPeriodoBindingSource)).BeginInit();
            this.pnlBarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.tbPVentas.SuspendLayout();
            this.tpPReporteVentas.SuspendLayout();
            this.tbPReporteDetVentas.SuspendLayout();
            this.SuspendLayout();
            // 
            // visualizarVentasPeriodoBindingSource
            // 
            this.visualizarVentasPeriodoBindingSource.DataMember = "Visualizar_VentasPeriodo";
            this.visualizarVentasPeriodoBindingSource.DataSource = this.ferreteriaDataSetOperaciones1;
            // 
            // ferreteriaDataSetOperaciones1
            // 
            this.ferreteriaDataSetOperaciones1.DataSetName = "FerreteriaDataSetOperaciones";
            this.ferreteriaDataSetOperaciones1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // visualizarDetVentasPeriodoBindingSource
            // 
            this.visualizarDetVentasPeriodoBindingSource.DataMember = "Visualizar_DetVentasPeriodo";
            this.visualizarDetVentasPeriodoBindingSource.DataSource = this.ferreteriaDataSetOperaciones1;
            // 
            // pnlBarraTitulo
            // 
            this.pnlBarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.pnlBarraTitulo.Controls.Add(this.label1);
            this.pnlBarraTitulo.Controls.Add(this.btnCerrar);
            this.pnlBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraTitulo.Name = "pnlBarraTitulo";
            this.pnlBarraTitulo.Size = new System.Drawing.Size(902, 28);
            this.pnlBarraTitulo.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(334, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Listado de ventas";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::SistemaFerretero.Properties.Resources.letra_x;
            this.btnCerrar.Location = new System.Drawing.Point(872, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(20, 20);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // visualizar_VentasPeriodoTableAdapter1
            // 
            this.visualizar_VentasPeriodoTableAdapter1.ClearBeforeFill = true;
            // 
            // visualizar_DetVentasPeriodoTableAdapter1
            // 
            this.visualizar_DetVentasPeriodoTableAdapter1.ClearBeforeFill = true;
            // 
            // tbPVentas
            // 
            this.tbPVentas.Controls.Add(this.tpPReporteVentas);
            this.tbPVentas.Controls.Add(this.tbPReporteDetVentas);
            this.tbPVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPVentas.Location = new System.Drawing.Point(0, 28);
            this.tbPVentas.Name = "tbPVentas";
            this.tbPVentas.SelectedIndex = 0;
            this.tbPVentas.Size = new System.Drawing.Size(902, 524);
            this.tbPVentas.TabIndex = 10;
            // 
            // tpPReporteVentas
            // 
            this.tpPReporteVentas.Controls.Add(this.reportViewer1);
            this.tpPReporteVentas.Location = new System.Drawing.Point(4, 22);
            this.tpPReporteVentas.Name = "tpPReporteVentas";
            this.tpPReporteVentas.Padding = new System.Windows.Forms.Padding(3);
            this.tpPReporteVentas.Size = new System.Drawing.Size(894, 498);
            this.tpPReporteVentas.TabIndex = 0;
            this.tpPReporteVentas.Text = "Reporte Ventas";
            this.tpPReporteVentas.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Ventas";
            reportDataSource1.Value = this.visualizarVentasPeriodoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaFerretero.ReportModels.VentasReporteReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(888, 492);
            this.reportViewer1.TabIndex = 10;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // tbPReporteDetVentas
            // 
            this.tbPReporteDetVentas.Controls.Add(this.reportViewer2);
            this.tbPReporteDetVentas.Location = new System.Drawing.Point(4, 22);
            this.tbPReporteDetVentas.Name = "tbPReporteDetVentas";
            this.tbPReporteDetVentas.Padding = new System.Windows.Forms.Padding(3);
            this.tbPReporteDetVentas.Size = new System.Drawing.Size(894, 498);
            this.tbPReporteDetVentas.TabIndex = 1;
            this.tbPReporteDetVentas.Text = "Reporte Detalle Ventas";
            this.tbPReporteDetVentas.UseVisualStyleBackColor = true;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DetalleVenta";
            reportDataSource2.Value = this.visualizarDetVentasPeriodoBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "SistemaFerretero.ReportModels.DetalleVentasReport.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(3, 3);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(888, 492);
            this.reportViewer2.TabIndex = 10;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // FrmVentasConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 552);
            this.Controls.Add(this.tbPVentas);
            this.Controls.Add(this.pnlBarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmVentasConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmVentasConsulta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.visualizarVentasPeriodoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSetOperaciones1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarDetVentasPeriodoBindingSource)).EndInit();
            this.pnlBarraTitulo.ResumeLayout(false);
            this.pnlBarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.tbPVentas.ResumeLayout(false);
            this.tpPReporteVentas.ResumeLayout(false);
            this.tbPReporteDetVentas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlBarraTitulo;
        private System.Windows.Forms.PictureBox btnCerrar;
        private FerreteriaDataSetOperaciones ferreteriaDataSetOperaciones;
        private FerreteriaDataSetOperacionesTableAdapters.Visualizar_VentasPeriodoTableAdapter visualizar_VentasPeriodoTableAdapter;
        private FerreteriaDataSetOperacionesTableAdapters.Visualizar_DetVentasPeriodoTableAdapter visualizar_DetVentasPeriodoTableAdapter;
        private System.Windows.Forms.BindingSource visualizarVentasPeriodoBindingSource;
        private FerreteriaDataSetOperaciones ferreteriaDataSetOperaciones1;
        private FerreteriaDataSetOperacionesTableAdapters.Visualizar_VentasPeriodoTableAdapter visualizar_VentasPeriodoTableAdapter1;
        private System.Windows.Forms.BindingSource visualizarDetVentasPeriodoBindingSource;
        private FerreteriaDataSetOperacionesTableAdapters.Visualizar_DetVentasPeriodoTableAdapter visualizar_DetVentasPeriodoTableAdapter1;
        private System.Windows.Forms.TabControl tbPVentas;
        private System.Windows.Forms.TabPage tbPReporteDetVentas;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.TabPage tpPReporteVentas;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
    }
}