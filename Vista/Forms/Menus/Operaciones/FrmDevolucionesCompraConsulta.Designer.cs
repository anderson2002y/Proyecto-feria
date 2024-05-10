
namespace SistemaFerretero.Forms.Menus.Operaciones
{
    partial class FrmDevolucionesCompraConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDevolucionesCompraConsulta));
            this.visualizarDevComprasPeriodoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ferreteriaDataSetOperaciones = new SistemaFerretero.FerreteriaDataSetOperaciones();
            this.visualizarDevComprasPeriodoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.visualizar_DevComprasPeriodoTableAdapter = new SistemaFerretero.FerreteriaDataSetOperacionesTableAdapters.Visualizar_DevComprasPeriodoTableAdapter();
            this.pnlBarraTitulo = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarDevComprasPeriodoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSetOperaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarDevComprasPeriodoBindingSource1)).BeginInit();
            this.pnlBarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // visualizarDevComprasPeriodoBindingSource
            // 
            this.visualizarDevComprasPeriodoBindingSource.DataMember = "Visualizar_DevComprasPeriodo";
            this.visualizarDevComprasPeriodoBindingSource.DataSource = this.ferreteriaDataSetOperaciones;
            // 
            // ferreteriaDataSetOperaciones
            // 
            this.ferreteriaDataSetOperaciones.DataSetName = "FerreteriaDataSetOperaciones";
            this.ferreteriaDataSetOperaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // visualizarDevComprasPeriodoBindingSource1
            // 
            this.visualizarDevComprasPeriodoBindingSource1.DataMember = "Visualizar_DevComprasPeriodo";
            this.visualizarDevComprasPeriodoBindingSource1.DataSource = this.ferreteriaDataSetOperaciones;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetDevComprasPeriodo";
            reportDataSource1.Value = this.visualizarDevComprasPeriodoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaFerretero.ReportModels.DevComprasPeriodo.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 28);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 422);
            this.reportViewer1.TabIndex = 3;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // visualizar_DevComprasPeriodoTableAdapter
            // 
            this.visualizar_DevComprasPeriodoTableAdapter.ClearBeforeFill = true;
            // 
            // pnlBarraTitulo
            // 
            this.pnlBarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.pnlBarraTitulo.Controls.Add(this.btnCerrar);
            this.pnlBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraTitulo.Name = "pnlBarraTitulo";
            this.pnlBarraTitulo.Size = new System.Drawing.Size(800, 28);
            this.pnlBarraTitulo.TabIndex = 12;
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
            // FrmDevolucionesCompraConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pnlBarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDevolucionesCompraConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDevolucionesCompraConsulta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDevolucionesCompraConsulta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.visualizarDevComprasPeriodoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSetOperaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarDevComprasPeriodoBindingSource1)).EndInit();
            this.pnlBarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource visualizarDevComprasPeriodoBindingSource;
        private FerreteriaDataSetOperaciones ferreteriaDataSetOperaciones;
        private FerreteriaDataSetOperacionesTableAdapters.Visualizar_DevComprasPeriodoTableAdapter visualizar_DevComprasPeriodoTableAdapter;
        private System.Windows.Forms.BindingSource visualizarDevComprasPeriodoBindingSource1;
        private System.Windows.Forms.Panel pnlBarraTitulo;
        private System.Windows.Forms.PictureBox btnCerrar;
    }
}