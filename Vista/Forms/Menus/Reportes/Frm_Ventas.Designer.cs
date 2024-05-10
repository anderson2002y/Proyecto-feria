
namespace SistemaFerretero.Forms.Menus.Reportes
{
    partial class Frm_Ventas
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConsultar = new FontAwesome.Sharp.IconButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMes = new System.Windows.Forms.Button();
            this.btnUltimosSiete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.rvVentas = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ferreteriaDataSetOperaciones = new SistemaFerretero.FerreteriaDataSetOperaciones();
            this.visualizarVentasPeriodoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.visualizar_VentasPeriodoTableAdapter = new SistemaFerretero.FerreteriaDataSetOperacionesTableAdapters.Visualizar_VentasPeriodoTableAdapter();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSetOperaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarVentasPeriodoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFechaFinal);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(800, 87);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametros";
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
            this.btnConsultar.Location = new System.Drawing.Point(257, 23);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(130, 38);
            this.btnConsultar.TabIndex = 0;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnMes);
            this.flowLayoutPanel1.Controls.Add(this.btnUltimosSiete);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(518, 19);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(271, 42);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // btnMes
            // 
            this.btnMes.BackColor = System.Drawing.Color.SeaGreen;
            this.btnMes.FlatAppearance.BorderSize = 0;
            this.btnMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMes.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMes.Location = new System.Drawing.Point(2, 2);
            this.btnMes.Margin = new System.Windows.Forms.Padding(2);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(113, 38);
            this.btnMes.TabIndex = 18;
            this.btnMes.Text = "Ultimo mes";
            this.btnMes.UseVisualStyleBackColor = false;
            this.btnMes.Click += new System.EventHandler(this.btnMes_Click);
            // 
            // btnUltimosSiete
            // 
            this.btnUltimosSiete.BackColor = System.Drawing.Color.SeaGreen;
            this.btnUltimosSiete.FlatAppearance.BorderSize = 0;
            this.btnUltimosSiete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUltimosSiete.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUltimosSiete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUltimosSiete.Location = new System.Drawing.Point(119, 2);
            this.btnUltimosSiete.Margin = new System.Windows.Forms.Padding(2);
            this.btnUltimosSiete.Name = "btnUltimosSiete";
            this.btnUltimosSiete.Size = new System.Drawing.Size(140, 38);
            this.btnUltimosSiete.TabIndex = 19;
            this.btnUltimosSiete.Text = "Ultima semana";
            this.btnUltimosSiete.UseVisualStyleBackColor = false;
            this.btnUltimosSiete.Click += new System.EventHandler(this.btnUltimosSiete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fecha Final:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fecha Inicial:";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(114, 45);
            this.dtpFechaFinal.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(117, 23);
            this.dtpFechaFinal.TabIndex = 2;
            this.dtpFechaFinal.Value = new System.DateTime(2022, 10, 8, 9, 45, 23, 0);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.AccessibleDescription = "dtpFechaFinal";
            this.dtpFechaInicio.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(114, 14);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(117, 23);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // rvVentas
            // 
            this.rvVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource3.Name = "Ventas";
            reportDataSource3.Value = this.visualizarVentasPeriodoBindingSource;
            this.rvVentas.LocalReport.DataSources.Add(reportDataSource3);
            this.rvVentas.LocalReport.ReportEmbeddedResource = "SistemaFerretero.ReportModels.VentasReporteReport.rdlc";
            this.rvVentas.Location = new System.Drawing.Point(0, 89);
            this.rvVentas.Margin = new System.Windows.Forms.Padding(0);
            this.rvVentas.Name = "rvVentas";
            this.rvVentas.ServerReport.BearerToken = null;
            this.rvVentas.Size = new System.Drawing.Size(800, 361);
            this.rvVentas.TabIndex = 3;
            this.rvVentas.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // ferreteriaDataSetOperaciones
            // 
            this.ferreteriaDataSetOperaciones.DataSetName = "FerreteriaDataSetOperaciones";
            this.ferreteriaDataSetOperaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // visualizarVentasPeriodoBindingSource
            // 
            this.visualizarVentasPeriodoBindingSource.DataMember = "Visualizar_VentasPeriodo";
            this.visualizarVentasPeriodoBindingSource.DataSource = this.ferreteriaDataSetOperaciones;
            // 
            // visualizar_VentasPeriodoTableAdapter
            // 
            this.visualizar_VentasPeriodoTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvVentas);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Ventas";
            this.Text = "Frm_Ventas";
            this.Load += new System.EventHandler(this.Frm_Ventas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ferreteriaDataSetOperaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarVentasPeriodoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnConsultar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnMes;
        private System.Windows.Forms.Button btnUltimosSiete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private Microsoft.Reporting.WinForms.ReportViewer rvVentas;
        private System.Windows.Forms.BindingSource visualizarVentasPeriodoBindingSource;
        private FerreteriaDataSetOperaciones ferreteriaDataSetOperaciones;
        private FerreteriaDataSetOperacionesTableAdapters.Visualizar_VentasPeriodoTableAdapter visualizar_VentasPeriodoTableAdapter;
    }
}