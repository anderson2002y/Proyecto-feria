namespace SistemaFerretero.Forms.Menus.Reportes
{
    partial class FrmCuentas_por_pagar_proveedor
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
            this.reporteCuentasporpagarproveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ferreteriaDataSet = new SistemaFerretero.FerreteriaDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reporte_Cuentas_por_pagar_proveedorTableAdapter = new SistemaFerretero.FerreteriaDataSetTableAdapters.Reporte_Cuentas_por_pagar_proveedorTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reporteCuentasporpagarproveedorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reporteCuentasporpagarproveedorBindingSource
            // 
            this.reporteCuentasporpagarproveedorBindingSource.DataMember = "Reporte_Cuentas_por_pagar_proveedor";
            this.reporteCuentasporpagarproveedorBindingSource.DataSource = this.ferreteriaDataSet;
            // 
            // ferreteriaDataSet
            // 
            this.ferreteriaDataSet.DataSetName = "FerreteriaDataSet";
            this.ferreteriaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet_Cuentas_Por_Pagar";
            reportDataSource1.Value = this.reporteCuentasporpagarproveedorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaFerretero.ReportModels.Cuentas_por_pagar_proveedor.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // reporte_Cuentas_por_pagar_proveedorTableAdapter
            // 
            this.reporte_Cuentas_por_pagar_proveedorTableAdapter.ClearBeforeFill = true;
            // 
            // FrmCuentas_por_pagar_proveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCuentas_por_pagar_proveedor";
            this.Text = "Cuentas por pagar a proveedores";
            this.Load += new System.EventHandler(this.FrmCuentas_por_pagar_proveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reporteCuentasporpagarproveedorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FerreteriaDataSet ferreteriaDataSet;
        private System.Windows.Forms.BindingSource reporteCuentasporpagarproveedorBindingSource;
        private FerreteriaDataSetTableAdapters.Reporte_Cuentas_por_pagar_proveedorTableAdapter reporte_Cuentas_por_pagar_proveedorTableAdapter;
    }
}