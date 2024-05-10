namespace SistemaFerretero.Forms.Menus.Reportes
{
    partial class Frm_Top_10_Productos_Vendidos
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
            this.top10ProductosMasVendidoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ferreteriaDataSet = new SistemaFerretero.FerreteriaDataSet();
            this.ferreteriaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.top10ProductosMasVendidoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.top10_Productos_Mas_VendidoTableAdapter = new SistemaFerretero.FerreteriaDataSetTableAdapters.Top10_Productos_Mas_VendidoTableAdapter();
            this.reporteProductosMayorRecaudacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporte_Productos_Mayor_RecaudacionTableAdapter = new SistemaFerretero.FerreteriaDataSetTableAdapters.Reporte_Productos_Mayor_RecaudacionTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowPanelBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMes = new System.Windows.Forms.Button();
            this.btnUltimosSiete = new System.Windows.Forms.Button();
            this.btnConsultar = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.top10ProductosMasVendidoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.top10ProductosMasVendidoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteProductosMayorRecaudacionBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.flowPanelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // top10ProductosMasVendidoBindingSource1
            // 
            this.top10ProductosMasVendidoBindingSource1.DataMember = "Top10_Productos_Mas_Vendido";
            this.top10ProductosMasVendidoBindingSource1.DataSource = this.ferreteriaDataSet;
            // 
            // ferreteriaDataSet
            // 
            this.ferreteriaDataSet.DataSetName = "FerreteriaDataSet";
            this.ferreteriaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ferreteriaDataSetBindingSource
            // 
            this.ferreteriaDataSetBindingSource.DataSource = this.ferreteriaDataSet;
            this.ferreteriaDataSetBindingSource.Position = 0;
            // 
            // top10ProductosMasVendidoBindingSource
            // 
            this.top10ProductosMasVendidoBindingSource.DataMember = "Top10_Productos_Mas_Vendido";
            this.top10ProductosMasVendidoBindingSource.DataSource = this.ferreteriaDataSet;
            // 
            // top10_Productos_Mas_VendidoTableAdapter
            // 
            this.top10_Productos_Mas_VendidoTableAdapter.ClearBeforeFill = true;
            // 
            // reporteProductosMayorRecaudacionBindingSource
            // 
            this.reporteProductosMayorRecaudacionBindingSource.DataMember = "Reporte_Productos_Mayor_Recaudacion";
            this.reporteProductosMayorRecaudacionBindingSource.DataSource = this.ferreteriaDataSet;
            // 
            // reporte_Productos_Mayor_RecaudacionTableAdapter
            // 
            this.reporte_Productos_Mayor_RecaudacionTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSetTop10_Productos";
            reportDataSource1.Value = this.top10ProductosMasVendidoBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaFerretero.ReportModels.Top10_Productos_Mas_Vendido.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 93);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(823, 363);
            this.reportViewer1.TabIndex = 8;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.groupBox1.Controls.Add(this.flowPanelBotones);
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFechaFinal);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(822, 91);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametros";
            // 
            // flowPanelBotones
            // 
            this.flowPanelBotones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPanelBotones.Controls.Add(this.btnMes);
            this.flowPanelBotones.Controls.Add(this.btnUltimosSiete);
            this.flowPanelBotones.Location = new System.Drawing.Point(572, 33);
            this.flowPanelBotones.Name = "flowPanelBotones";
            this.flowPanelBotones.Size = new System.Drawing.Size(238, 46);
            this.flowPanelBotones.TabIndex = 10;
            // 
            // btnMes
            // 
            this.btnMes.BackColor = System.Drawing.Color.SeaGreen;
            this.btnMes.FlatAppearance.BorderSize = 0;
            this.btnMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMes.Location = new System.Drawing.Point(2, 2);
            this.btnMes.Margin = new System.Windows.Forms.Padding(2);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(113, 38);
            this.btnMes.TabIndex = 17;
            this.btnMes.Text = "Ultimo mes";
            this.btnMes.UseVisualStyleBackColor = false;
            this.btnMes.Click += new System.EventHandler(this.btnMes_Click);
            // 
            // btnUltimosSiete
            // 
            this.btnUltimosSiete.BackColor = System.Drawing.Color.SeaGreen;
            this.btnUltimosSiete.FlatAppearance.BorderSize = 0;
            this.btnUltimosSiete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUltimosSiete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUltimosSiete.Location = new System.Drawing.Point(119, 2);
            this.btnUltimosSiete.Margin = new System.Windows.Forms.Padding(2);
            this.btnUltimosSiete.Name = "btnUltimosSiete";
            this.btnUltimosSiete.Size = new System.Drawing.Size(113, 38);
            this.btnUltimosSiete.TabIndex = 20;
            this.btnUltimosSiete.Text = "Ultima semana";
            this.btnUltimosSiete.UseVisualStyleBackColor = false;
            this.btnUltimosSiete.Click += new System.EventHandler(this.btnUltimosSiete_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.Navy;
            this.btnConsultar.FlatAppearance.BorderSize = 0;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.IconChar = FontAwesome.Sharp.IconChar.Scroll;
            this.btnConsultar.IconColor = System.Drawing.Color.White;
            this.btnConsultar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConsultar.IconSize = 32;
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.Location = new System.Drawing.Point(247, 34);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(130, 38);
            this.btnConsultar.TabIndex = 26;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Fecha Final:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Fecha Inicial:";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(115, 58);
            this.dtpFechaFinal.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(111, 22);
            this.dtpFechaFinal.TabIndex = 23;
            this.dtpFechaFinal.Value = new System.DateTime(2022, 12, 23, 0, 0, 0, 0);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.AccessibleDescription = "dtpFechaFinal";
            this.dtpFechaInicio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(115, 26);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(111, 22);
            this.dtpFechaInicio.TabIndex = 22;
            // 
            // Frm_Top_10_Productos_Vendidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Top_10_Productos_Vendidos";
            this.Text = "TOP 10 productos mas vendidos";
            this.Load += new System.EventHandler(this.Frm_Top_10_Productos_Vendidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.top10ProductosMasVendidoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.top10ProductosMasVendidoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteProductosMayorRecaudacionBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowPanelBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource ferreteriaDataSetBindingSource;
        private FerreteriaDataSet ferreteriaDataSet;
        private System.Windows.Forms.BindingSource top10ProductosMasVendidoBindingSource;
        private FerreteriaDataSetTableAdapters.Top10_Productos_Mas_VendidoTableAdapter top10_Productos_Mas_VendidoTableAdapter;
        private System.Windows.Forms.BindingSource top10ProductosMasVendidoBindingSource1;
        private System.Windows.Forms.BindingSource reporteProductosMayorRecaudacionBindingSource;
        private FerreteriaDataSetTableAdapters.Reporte_Productos_Mayor_RecaudacionTableAdapter reporte_Productos_Mayor_RecaudacionTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMes;
        private System.Windows.Forms.Button btnUltimosSiete;
        private FontAwesome.Sharp.IconButton btnConsultar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.FlowLayoutPanel flowPanelBotones;
    }
}