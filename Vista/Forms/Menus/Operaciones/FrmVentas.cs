using Controlador.Catalogo;
using Controlador.Operaciones;
using Controlador.Validaciones;
using Poco;
using SistemaFerretero.Forms.Menus.Catalogo;
using SistemaFerretero.Forms.Menus.Reportes;
using SistemaFerretero.MenusEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFerretero.Forms.Menus.Operaciones
{
    public partial class FrmVentas : Form
    {
        private FrmCatalogModel ModalTemp;
        private FrmVentasConsulta FrmVentasConsulta;
        private Dictionary<int, string> Departamentos = new Dictionary<int, string>();
        private Dictionary<int, string> Municipios = new Dictionary<int, string>();
        private static string[] header = { "Id", "Nombre", "Precio", "Cantidad", "Desc. unitario", "Monto", "Existencias" };
        private int IdCliente = 1;
        private int IdEmpleado = 3;
        public Usuario User { get; set; } 

        public FrmVentas(Usuario u)
        {
            InitializeComponent();
            CargarModeloDataGrid();
            tpFechaFinal.Value = DateTime.Now.Date;
            txtEnvio.Text = "0";
            User = u;

            RestringirAcceso();
            this.Focus();
        }

        private void RestringirAcceso()
        {

        }
    #region CargaModelo
        private void FrmVentas_Load(object sender, EventArgs e)
        {
            this.panel7.Visible = false;
            checkEnvio_CheckedChanged(sender, e);
            this.tpFechaInicial.Value = Convert.ToDateTime("01/01/2019");

            CargarDatos();
            CargarComboBox();
            lblVendedor.Text = User.Nombre;
        }

        private void CargarModeloDataGrid()
        {
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = header[0] });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = header[1] });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = header[2] });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = header[3] });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = header[4] });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = header[5] });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = header[6] });
            dgvCarrito.Columns[0].Visible = false;
        }

        private void CargarDatos()
        {
            dgvVentas.DataSource = CVenta.Visualizar_Ventas();
            dgvVentas.Columns[0].Visible = false;
            dgvVentas.Columns[1].Visible = false;

        }

        private void CargarComboBox()
        {
            DataTable dt = CDepartamento.Mostrar_Departamentos();

            foreach (DataRow fila in dt.Rows)
            {
                Departamentos.Add(fila.Field<int>("IdDepartamento"), fila.Field<string>("Nombre"));
            }

            cmbDepartamento.Items.AddRange(Departamentos.Values.ToArray());
            cmbDepartamento.SelectedIndex = 0;

        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Municipios.Clear();
            int index = cmbDepartamento.SelectedIndex + 1;
            cmbMunicipio.Items.Clear();

            foreach (DataRow fila in CMunicipio.Mostrar_Municipio(index).Rows)
            {
                Municipios.Add(fila.Field<int>("IdMunicipio"), fila.Field<string>("Nombre"));
            }

            cmbMunicipio.Items.AddRange(Municipios.Values.ToArray());
            cmbMunicipio.SelectedIndex = 0;
        }
        #endregion

    #region NuevaCompra
        private void CargarCatalogoDefault()
        {
            ModalTemp.Size = new Size(850, 480);
            ModalTemp.StartPosition = FormStartPosition.CenterScreen;
            ModalTemp.pnlBarraTitulo.Visible = true;
        }
        private void btnClientes_Click(object sender = null, EventArgs e = null)
        {
            ModalTemp = new FrmCatalogModel(EnumCatalogo.Clientes, User);
            ModalTemp.flowPnlBotones.Visible = false;

            ModalTemp.dgvDatos.CellDoubleClick += ObtenerCliente;

            CargarCatalogoDefault();
            ModalTemp.ShowDialog(this);
        }

        private void ObtenerCliente(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = ModalTemp.dgvDatos.SelectedRows[0];

            DataTable dt = CCliente.BuscarStatic(row.Cells[1].Value.ToString());

            DataRow fila = dt.Rows[0];

            IdCliente = int.Parse(fila[0].ToString());
            lblCliente.Text = fila[1].ToString();

            ModalTemp.Close();
            ModalTemp.Dispose();
        }

        private void btnProductos_Click(object sender = null, EventArgs e = null)
        {
            ModalTemp = new FrmCatalogModel(EnumCatalogo.Productos,User);
            ModalTemp.flowPnlBotones.Visible = false;
            ModalTemp.btnFacturar.Visible = false;

            foreach (DataGridViewRow fila in ModalTemp.dgvDatos.Rows)
            {
                int index = fila.Index;

                if (fila.Cells[9].Value.ToString() == "Inactivo")
                {
                    ModalTemp.dgvDatos.Rows.RemoveAt(index);
                }
            }

            ModalTemp.dgvDatos.CellDoubleClick += ObtenerProducto;
            ModalTemp.dgvDatos.KeyDown += ObtenerProductoEnter;

            CargarCatalogoDefault();
            ModalTemp.ShowDialog(this);
        }

        private void ObtenerProductoEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ObtenerProducto();
            }
        }

        private void ObtenerProducto(object sender = null, DataGridViewCellEventArgs e = null)
        {
            DataGridViewRow row = ModalTemp.dgvDatos.SelectedRows[0];

            Producto p = new Producto()
            {
                Id = int.Parse(row.Cells[0].Value.ToString()),
                Nombre = row.Cells[1].Value.ToString(),
                Marca = row.Cells[2].Value.ToString(),
                Precio = FormatoString.QuitarFormatoNic(row.Cells[6].Value.ToString()),
                UnidadesDisponibles = int.Parse(row.Cells[7].Value.ToString()),
                UnidadesRequeridas = int.Parse(row.Cells[8].Value.ToString())
            };

            if (p.UnidadesDisponibles <= 0)
            {
                MessageBox.Show("Producto sin stock", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (p.UnidadesRequeridas >= p.UnidadesDisponibles)
            {
                DialogResult mensaje;
                mensaje = MessageBox.Show("Las existencias es igual o menor a la cantidad mínima\n¿Desea continuar?","Existencias minimas",MessageBoxButtons.YesNo,MessageBoxIcon.Hand);

                if (mensaje == DialogResult.No)
                {
                    return;
                }
            }

            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                if (int.Parse(fila.Cells[0].Value.ToString()) == p.Id)
                {
                    MessageBox.Show("Producto ya agregado, ingrese otro producto", "Mensaje de aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }

            dgvCarrito.Rows.Add(p.toArray(FormatoString.AgregarFormato(p.Precio),FormatoString.AgregarFormato(0)));
        }

        private void checkEnvio_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEnvio.Checked == false)
            {
                cmbDepartamento.Enabled = false;
                cmbMunicipio.Enabled = false;
                lblCostoEnvio.Visible = false;
                lblEnvioH.Visible = false;
                txtDireccion.Enabled = false;
                txtEnvio.Enabled = false;
            }
            else
            {
                cmbDepartamento.Enabled = true;
                cmbMunicipio.Enabled = true;
                lblCostoEnvio.Visible = true;
                lblEnvioH.Visible = true;
                txtDireccion.Enabled = true;
                txtEnvio.Enabled = true;
            }
        }

        private void dgvCarrito_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCarrito.Columns[e.ColumnIndex].HeaderText != "Cantidad")
            {
                return;
            }

            int cantidad = int.Parse(dgvCarrito.SelectedRows[0].Cells[3].Value.ToString());
            double precio = FormatoString.QuitarFormato(dgvCarrito.SelectedRows[0].Cells[2].Value.ToString(),"C$",",");
            double descuento = FormatoString.QuitarFormato(dgvCarrito.SelectedRows[0].Cells[4].Value.ToString(),"C$",",");
            double monto = precio * cantidad - descuento * cantidad;

            if (dgvCarrito.Columns[e.ColumnIndex].HeaderText == "Monto")
            {
                double totalAntes = double.Parse(lblTotal.Text);
                totalAntes = totalAntes - precio * cantidad;
                totalAntes += monto;
            }

            dgvCarrito.SelectedRows[0].Cells[5].Value = FormatoString.AgregarFormato(monto);
            double SubTotal = FormatoString.QuitarFormato(lblSubtotal.Text,"C$",",");

            lblSubtotal.Text = FormatoString.AgregarFormato(monto + SubTotal);
        }

        private void dgvCarrito_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ActualizarFactura();
        }

        private void txtEnvio_TextChanged(object sender, EventArgs e)
        {
            if (txtEnvio.Text == "")
            {
                return;
            }

            double envio = 0;
            if (txtEnvio.Text == ".")
            {
                txtEnvio.Text = "0.";
                txtEnvio.Select(txtEnvio.TextLength,1);
            }
            else
            {
                envio = double.Parse(txtEnvio.Text);
            }

            
            lblCostoEnvio.Text = FormatoString.AgregarFormato(envio);
            ActualizarFactura();
        }

        private void txtEnvio_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionTexTBox.SoloNumeros(sender, e);
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (dgvCarrito.SelectedRows.Count == 0 || dgvCarrito.SelectedRows.Count > 1)
            {
                MessageBox.Show("Seleccione una sola fila", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NumericUpDown numerico = (sender as NumericUpDown);

            int existencias = int.Parse(dgvCarrito.SelectedRows[0].Cells[6].Value.ToString());
            if (numerico.Value > existencias)
            {
                MessageBox.Show("Unidades maximas disponibles: " + existencias, "Mensaje de aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                nudCantidad.Value = existencias;
                return;
            }

            int cantidad = int.Parse(nudCantidad.Value.ToString());
            dgvCarrito.SelectedRows[0].Cells[3].Value = cantidad;

            ActualizarFactura();

        }

        private void dgvCarrito_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCarrito.Rows.Count <= 0 || dgvCarrito.SelectedRows.Count <= 0)
            {
                return;
            }

            int cantidad = int.Parse(dgvCarrito.SelectedRows[0].Cells[3].Value.ToString());
            double descuento = FormatoString.QuitarFormato(dgvCarrito.SelectedRows[0].Cells[4].Value.ToString(),"C$",",");
            double precio = FormatoString.QuitarFormato(dgvCarrito.SelectedRows[0].Cells[2].Value.ToString(),"C$",",");

            double porcentaje = (descuento / precio) * 100;

            txtDescuento.Text = porcentaje.ToString();
            nudCantidad.Value = cantidad;
        }

        private void dgvCarrito_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvCarrito.SelectedRows[0].Index;
            EliminarProducto(index);
        }

        private void dgvCarrito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int index = dgvCarrito.SelectedRows[0].Index;
                EliminarProducto(index);
            }
        }

        private void EliminarProducto(int index = -1)
        {
            if (dgvCarrito.SelectedRows.Count < 0)
            {
                return;
            }

            if (dgvCarrito.SelectedRows.Count > 1)
            {
                MessageBox.Show("Seleccione una fila para borrar", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (index < 0)
            {
                return;
            }

            dgvCarrito.Rows.RemoveAt(index);
            ActualizarFactura();
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                return;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                return;
            }

            if (txtDescuento.Text == "")
            {
                return;
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            float descuento = 0;

            if (descuento > 100)
            {
                MessageBox.Show("El descuento debe ser menor a 100", "Mensaje de aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtDescuento.Text = "0";
                txtDescuento.Select(txtDescuento.TextLength,1);
                return;
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (txtDescuento.Text == "")
            {
                return;
            }

            if (dgvCarrito.Rows.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un producto", "Mensaje de aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvCarrito.SelectedRows.Count > 1)
            {
                MessageBox.Show("Seleccione una sola fila", "Mensaje de aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double precio = FormatoString.QuitarFormatoNic(dgvCarrito.SelectedRows[0].Cells[2].Value.ToString());
            double descuento = precio * (FormatoString.QuitarFormatoNic(txtDescuento.Text) / 100);
            int cantidad = int.Parse(dgvCarrito.SelectedRows[0].Cells[3].Value.ToString());

            dgvCarrito.SelectedRows[0].Cells[4].Value = FormatoString.AgregarFormato(descuento);
            dgvCarrito.SelectedRows[0].Cells[5].Value = FormatoString.AgregarFormato(precio * cantidad - descuento * cantidad);


            ActualizarFactura();
        }

        private void ActualizarFactura()
        {
            double subtotal = 0;
            double descuento = 0;
            double total = 0;

            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                double precio = FormatoString.QuitarFormatoNic(fila.Cells[2].Value.ToString());
                int cantidad = int.Parse(fila.Cells[3].Value.ToString());
                subtotal += precio * cantidad;

                if (FormatoString.QuitarFormatoNic(fila.Cells[4].Value.ToString()) != 0)
                {
                    descuento += FormatoString.QuitarFormatoNic(fila.Cells[4].Value.ToString()) * cantidad;
                }
            }

            string costoEnvio = txtEnvio.Text;

            if (costoEnvio == "" || costoEnvio == "0")
            {
                total = subtotal - descuento;
            }
            else
            {
                total = subtotal - descuento + FormatoString.QuitarFormatoNic(lblCostoEnvio.Text);
            }


            lblSubtotal.Text =  FormatoString.AgregarFormato(subtotal);
            lblDescuento.Text = FormatoString.AgregarFormato(descuento);
            lblTotal.Text = FormatoString.AgregarFormato(total);
        }

        private void txtEnvio_Enter(object sender, EventArgs e)
        {
            if (txtEnvio.Text == "0")
            {
                txtEnvio.Text = "";
            }
        }

        private void txtEnvio_Leave(object sender, EventArgs e)
        {
            if (txtEnvio.Text == "")
            {
                txtEnvio.Text = "0";
            }
        }

        private void txtDescuento_Enter(object sender, EventArgs e)
        {
            if (txtDescuento.Text == "0")
            {
                txtDescuento.Text = "";
            }
        }

        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            if (txtDescuento.Text == "")
            {
                txtDescuento.Text = "0";
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.Rows.Count <= 0)
            {
                MessageBox.Show("Seleccione al menos un producto", "Error de facturación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (checkEnvio.Checked == true && txtDireccion.TextLength == 0)
            {
                MessageBox.Show("Ingrese la dirección del envío", "Mensaje de aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lblCliente.Text == "")
            {
                MessageBox.Show("Seleccione un cliente", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (checkEnvio.Checked == true && (txtEnvio.Text == "" || txtEnvio.Text == "0"))
            {
                DialogResult mensaje;
                mensaje = MessageBox.Show("Costo del envío igual a 0. \nDesea continuar?", "Mensaje de aviso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (mensaje == DialogResult.No)
                {
                    return;
                }
            }         

            CVenta.Registrar_Venta(IdCliente,IdEmpleado);
            
            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                int IdProducto = int.Parse(fila.Cells[0].Value.ToString());
                int cantidad = int.Parse(fila.Cells[3].Value.ToString());
                double precio = FormatoString.QuitarFormatoNic(fila.Cells[2].Value.ToString());
                double descuento = FormatoString.QuitarFormatoNic(fila.Cells[4].Value.ToString()) / 
                                    FormatoString.QuitarFormatoNic(fila.Cells[2].Value.ToString());

                ProductoVenta producto = new ProductoVenta()
                {
                    Id = IdProducto,
                    Precio = precio,
                    Cantidad = cantidad,
                    Descuento = descuento
                };

                CVenta.Registrar_DetVenta(producto);
            }

            if (lblCostoEnvio.Text != "0" && checkEnvio.Checked == true)
            {
                int idMunicipio = 0;

                foreach(var municipio in Municipios)
                {
                    string seleccion = cmbMunicipio.SelectedItem.ToString();

                    if (municipio.Value == seleccion)
                    {
                        idMunicipio = municipio.Key;
                        continue;
                    }
                }

                Envio envio = new Envio()
                {
                    IdMunicipio = idMunicipio,
                    Direccion = txtDireccion.Text
                };

                CEnvio.Registrar_Envio(envio);
               
            }

            DialogResult impresion;
            impresion = MessageBox.Show("¿Desea imprimir la factura?","Facturación",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            string estado = "";
            if (impresion == DialogResult.Yes)
                estado = "Facturado";
            else
                estado = "Registrado";

            Factura f = new Factura()
            {
                CostoEnvio = FormatoString.QuitarFormatoNic(txtEnvio.Text),
                EstadoTransaccion = estado
            };

            CVenta.Registrar_Factura(f);

            if (estado == "Facturado")
            {
                FrmFactura factura = new FrmFactura();
                factura.ShowDialog();
            }

            MessageBox.Show("Venta registrada","Confirmación",MessageBoxButtons.OK,MessageBoxIcon.Information);
            dgvCarrito.Rows.Clear();
            CargarDatos();
        }
        #endregion

    #region ListadoVentas

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            DateTime inicio = DateTime.MinValue;
            DateTime final = DateTime.Now;

            try
            {
                inicio = DateTime.Parse(tpFechaInicial.Text);
                final = DateTime.Parse(tpFechaFinal.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }


            DataTable dt = CVenta.Visualizar_Ventas(inicio, final);

            dgvVentas.DataSource = dt;
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 1)
            {
                MessageBox.Show("Seleccione una sola fila","Error del usuario",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                return;
            }
            int IdFactura = Convert.ToInt32(dgvVentas.SelectedRows[0].Cells[0].Value.ToString());

            CVenta.Cambiar_EstadoFactura(IdFactura);
            CargarDatos();

            MessageBox.Show("Se cambio el estado de la factura", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DateTime fechainicio, fechafinal;
            fechainicio = tpFechaInicial.Value;
            fechafinal = tpFechaFinal.Value;
            FrmVentasConsulta = new FrmVentasConsulta(fechainicio, fechafinal);
            FrmVentasConsulta.ShowDialog();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvVentas.DataSource = CVenta.Buscar_Factura(txtBuscar.Text);
        }

        private void dgvVentas_DataSourceChanged(object sender, EventArgs e)
        {
            int cantidad = dgvVentas.RowCount;

            if (cantidad <= 0)
            {
                cantidad = 0;
                VerDetalle(-1);
            }

            lblCantidad.Text = cantidad.ToString();
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex<= 0)
            {
                return;
            }

            int id = int.Parse(dgvVentas.Rows[e.RowIndex].Cells[0].Value.ToString());
            VerDetalle(id);
        }

        private void dgvVentas_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvVentas.Rows.Count <= 0 || dgvVentas.SelectedRows.Count <= 0)
            {
                return;
            }

            int id = int.Parse(dgvVentas.SelectedRows[0].Cells[0].Value.ToString());
            VerDetalle(id);
        }

        private void dgvDetalleVentas_DataSourceChanged(object sender, EventArgs e)
        {
            int cantidad = dgvDetalleVentas.RowCount;

            if (cantidad <= 0)
            {
                cantidad = 0;
            }

            lblCantidadP.Text = cantidad.ToString();
        }

        private void VerDetalle(int idFactura)
        {
            this.panel7.Visible = true;

            dgvDetalleVentas.DataSource = CVenta.Visualizar_DetVenta(idFactura);
            dgvDetalleVentas.Columns[0].Visible = false;
            dgvDetalleVentas.ClearSelection();

            DataTable dt = CEnvio.Buscar_Envio(idFactura);

            if (dt.Rows.Count == 1)
            {
                boxEnvio.Visible = true;
                string direccion = dt.Rows[0].ItemArray.GetValue(2).ToString();
                string departamento = dt.Rows[0].ItemArray.GetValue(3).ToString();
                string municipio = dt.Rows[0].ItemArray.GetValue(4).ToString();
                decimal costoEnvio = Convert.ToDecimal(dt.Rows[0].ItemArray.GetValue(5).ToString());

                
                lblDireccion.Text = direccion;
                lblDepartamento.Text = departamento;
                lblMunicipio.Text = municipio;
                lblCostoEnvioDet.Text = Math.Round(costoEnvio, 2).ToString();
            }
            else
            {
                boxEnvio.Visible = false;
            }
        }
        #endregion

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if ((keyData != Keys.F1) & (keyData != Keys.F2))
                return base.ProcessCmdKey(ref msg, keyData);

            switch (keyData)
            {
                case Keys.F1:
                    btnProductos_Click();
                    break;
                case Keys.F2:
                    btnClientes_Click();
                    break;
            }
            return true;
        }
    }
}
