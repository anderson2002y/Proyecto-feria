
namespace SistemaFerretero.Forms.Menus.Operaciones
{
    partial class FrmFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFactura));
            this.verFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ferreteriaDataSet = new SistemaFerretero.FerreteriaDataSet();
            this.visualizarDetVentaFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ferreteriaDataSetOperaciones = new SistemaFerretero.FerreteriaDataSetOperaciones();
            this.visualizarDetVentaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pnlBarraTitulo = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ver_FacturaTableAdapter = new SistemaFerretero.FerreteriaDataSetTableAdapters.Ver_FacturaTableAdapter();
            this.visualizar_DetVentaFacturaTableAdapter = new SistemaFerretero.FerreteriaDataSetOperacionesTableAdapters.Visualizar_DetVentaFacturaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.verFacturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarDetVentaFacturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSetOperaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarDetVentaBindingSource1)).BeginInit();
            this.pnlBarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // verFacturaBindingSource
            // 
            this.verFacturaBindingSource.DataMember = "Ver_Factura";
            this.verFacturaBindingSource.DataSource = this.ferreteriaDataSet;
            // 
            // ferreteriaDataSet
            // 
            this.ferreteriaDataSet.DataSetName = "FerreteriaDataSet";
            this.ferreteriaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // visualizarDetVentaFacturaBindingSource
            // 
            this.visualizarDetVentaFacturaBindingSource.DataMember = "Visualizar_DetVentaFactura";
            this.visualizarDetVentaFacturaBindingSource.DataSource = this.ferreteriaDataSetOperaciones;
            // 
            // ferreteriaDataSetOperaciones
            // 
            this.ferreteriaDataSetOperaciones.DataSetName = "FerreteriaDataSetOperaciones";
            this.ferreteriaDataSetOperaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlBarraTitulo
            // 
            this.pnlBarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.pnlBarraTitulo.Controls.Add(this.btnCerrar);
            this.pnlBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraTitulo.Name = "pnlBarraTitulo";
            this.pnlBarraTitulo.Size = new System.Drawing.Size(1200, 28);
            this.pnlBarraTitulo.TabIndex = 14;
            this.pnlBarraTitulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlBarraTitulo_MouseMove);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::SistemaFerretero.Properties.Resources.letra_x;
            this.btnCerrar.Location = new System.Drawing.Point(1170, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(20, 20);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DTFactura";
            reportDataSource1.Value = this.verFacturaBindingSource;
            reportDataSource2.Name = "DTDetVentas";
            reportDataSource2.Value = this.visualizarDetVentaFacturaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaFerretero.ReportModels.Factura.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 28);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1200, 772);
            this.reportViewer1.TabIndex = 15;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // ver_FacturaTableAdapter
            // 
            this.ver_FacturaTableAdapter.ClearBeforeFill = true;
            // 
            // visualizar_DetVentaFacturaTableAdapter
            // 
            this.visualizar_DetVentaFacturaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pnlBarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.FrmFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.verFacturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarDetVentaFacturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSetOperaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarDetVentaBindingSource1)).EndInit();
            this.pnlBarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource visualizarDetVentaBindingSource1;
        private System.Windows.Forms.Panel pnlBarraTitulo;
        private System.Windows.Forms.PictureBox btnCerrar;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource verFacturaBindingSource;
        private FerreteriaDataSet ferreteriaDataSet;
        private System.Windows.Forms.BindingSource visualizarDetVentaFacturaBindingSource;
        private FerreteriaDataSetOperaciones ferreteriaDataSetOperaciones;
        private FerreteriaDataSetTableAdapters.Ver_FacturaTableAdapter ver_FacturaTableAdapter;
        private FerreteriaDataSetOperacionesTableAdapters.Visualizar_DetVentaFacturaTableAdapter visualizar_DetVentaFacturaTableAdapter;
    }
}