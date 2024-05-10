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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFerretero.Forms.Menus.Operaciones
{
    public partial class FrmCompras : Form
    {
        private FrmCatalogModel ModalTemp;
        private FrmPagos frmPagos;
        private string[] headerCarrito = {"Id","Descripcion","Marca","Modelo","Peso","Contenido","Precio","Cantidad","Subtotal","Descuento", "Iva","Monto" };
        private int IdProveedor;
        private string Rol;
        private double descuento=0.00;
        private Usuario User;

        public FrmCompras(Usuario u)
        {
            InitializeComponent();
            this.User = u;

            CargarComboBox();
            dtpFechaInicial.Value = DateTime.Parse("01/01/2019");
            dtpFechaFinal.Value = DateTime.Now;
            dtpFechaCompra.Value = DateTime.Now;
            CargarHeaderCarrito();
            txtDescuento.Text = Convert.ToString(descuento);

            RestringirAcceso();
        }

        private void RestringirAcceso()
        {

        }

        private void CargarHeaderCarrito()
        {
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = headerCarrito[0] });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = headerCarrito[1] });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = headerCarrito[2] });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = headerCarrito[3] });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = headerCarrito[4] });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = headerCarrito[5] });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = headerCarrito[6] });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = headerCarrito[7] });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = headerCarrito[8] });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = headerCarrito[9] });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = headerCarrito[10] });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = headerCarrito[11] });

            dgvCarrito.Columns[0].Visible = false;
        }

        private void CargarComboBox()
        {
            cmbTipoCompra.Items.Clear();
            cmbTipoCompra.Items.AddRange(Enum.GetValues(typeof(TipoPagoEnum)).Cast<object>().ToArray());
            cmbTipoCompra.SelectedIndex = 0;

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ModalTemp = new FrmCatalogModel(EnumCatalogo.Productos,User);
            CargarCatalogoDefault();

            ModalTemp.dgvDatos.CellDoubleClick += ObtenerProducto;
            ModalTemp.dgvDatos.KeyDown += ObtenerProductoKey;

            EliminarProductosInactivos();

            ModalTemp.ShowDialog(this);
        }
        private void CargarCatalogoDefault()
        {
            ModalTemp.Size = new Size(850, 480);
            ModalTemp.StartPosition = FormStartPosition.CenterScreen;
            ModalTemp.pnlBarraTitulo.Visible = true;
            ModalTemp.flowPnlBotones.Visible = false;
        }

        private void EliminarProductosInactivos()
        {
            foreach (DataGridViewRow fila in ModalTemp.dgvDatos.Rows)
            {
                int index = fila.Index;

                if (fila.Cells[9].Value.ToString() == "Inactivo")
                {
                    ModalTemp.dgvDatos.Rows.RemoveAt(index);
                }
            }
        }

        private void ObtenerProductoKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ObtenerProducto();
            }
        }

        private void ObtenerProducto(object sender = null, DataGridViewCellEventArgs e = null)
        {
            DataGridViewRow row = ModalTemp.dgvDatos.SelectedRows[0];

            DataTable dt = CProducto.BuscarStatic(row.Cells[1].Value.ToString());

            Producto p = new Producto()
            {
                Id  = int.Parse(row.Cells[0].Value.ToString()),
                Nombre = row.Cells[1].Value.ToString(),
                Marca = row.Cells[2].Value.ToString(),
                Modelo = row.Cells[3].Value.ToString(),
                Peso = int.Parse(row.Cells[4].Value.ToString()),
                Contenido = row.Cells[5].Value.ToString(),
                UnidadesDisponibles = int.Parse(row.Cells[7].Value.ToString()),
                UnidadesRequeridas = int.Parse(row.Cells[8].Value.ToString())
            };

            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                if (int.Parse(fila.Cells[0].Value.ToString()) == p.Id)
                {
                    MessageBox.Show("Producto ya agregado, ingrese otro producto", "Mensaje de aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }

            double precio = CCompra.Buscar_PrecioProducto(p.Id);
            lblProducto.Text = p.Nombre;

            dgvCarrito.Rows.Add(p.toArrayCompra(FormatoString.AgregarFormato(precio)));
            ActualizarTabla();
        }



        private void txtDecuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionTexTBox.SoloNumeros(sender, e);
        }

        private void btnPagarFactura_Click(object sender, EventArgs e)
        {
            DataGridViewRow fila = null;
            if (dgvCompra.SelectedRows.Count == 1)
            {
                fila = dgvCompra.SelectedRows[0];
            }

            
            frmPagos = new FrmPagos(fila);
            frmPagos.ShowDialog();
            CargarDatos();
        }

        private void CargarDatos()
        {

            dgvCompra.DataSource = CCompra.Visualizar_Compras();
            dgvCompra.Columns[0].Visible = false;
           
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            DateTime inicio = DateTime.MinValue;
            DateTime final = DateTime.Now;

            try
            {
                inicio = DateTime.Parse(dtpFechaInicial.Text);
                final = DateTime.Parse(dtpFechaFinal.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }

            DataTable dt = CCompra.Visualizar_Compras(inicio, final);

            dgvCompra.DataSource = dt;
        }

        private void dgvCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= 0)
            {
                return;
            }

            int idCompra = int.Parse(dgvCompra.Rows[e.RowIndex].Cells[0].Value.ToString());

            ActualizarDgvDetalleCompra(idCompra);
        }

        private void ActualizarDgvDetalleCompra(int idCompra)
        {
            dgvDetalleCompra.DataSource = CCompra.Visualizar_DetCompra(idCompra);
            dgvDetalleCompra.Columns[0].Visible = false;
            dgvDetalleCompra.ClearSelection();
        }

        private void numUpDowCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (dgvCarrito.SelectedRows.Count == 0 || dgvCarrito.SelectedRows.Count > 1)
            {
                MessageBox.Show("Seleccione una sola fila", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int cantidad = int.Parse(numUpDowCantidad.Value.ToString());
            double precio = double.Parse(txtPrecio.Text);

            dgvCarrito.SelectedRows[0].Cells[7].Value = cantidad;

            double descuentoUnit = FormatoString.QuitarFormatoNic(txtDescuento.Text) / 100;

            dgvCarrito.SelectedRows[0].Cells[9].Value = descuentoUnit * precio * 0.85 * cantidad;

        }

        private void ActualizarTabla()
        {
            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                double precio = FormatoString.QuitarFormato(fila.Cells[6].Value.ToString(),"C$",",");
                int cantidad = int.Parse(fila.Cells[7].Value.ToString());
                double total = precio * cantidad;
                double descuentoUnit = FormatoString.QuitarFormato(fila.Cells[9].Value.ToString(),"C$",",") / ( precio * cantidad* 0.85 );

                if (precio == 0)
                {
                    descuentoUnit = 0;
                }

                double subMonto = total * 0.85;
                descuento = total * 0.85 * descuentoUnit;
                double iva;

                if (descuentoUnit == 0)
                {
                    iva = precio * 0.15 * cantidad;
                }
                else
                {
                    iva = (total * 0.85 - total * 0.85 * descuentoUnit) * 0.15;
                }

                double monto = subMonto - descuento + iva;

                dgvCarrito.Rows[fila.Index].Cells[8].Value = FormatoString.AgregarFormato(subMonto);
                dgvCarrito.Rows[fila.Index].Cells[9].Value = FormatoString.AgregarFormato(descuento);
                dgvCarrito.Rows[fila.Index].Cells[10].Value = FormatoString.AgregarFormato(iva);
                dgvCarrito.Rows[fila.Index].Cells[11].Value = FormatoString.AgregarFormato(monto);
            }
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (dgvCarrito.SelectedRows.Count <= 0)
            {
                return;
            }

            if (dgvCarrito.SelectedRows.Count > 1)
            {
                MessageBox.Show("Seleccione un solo producto","Mensaje de aviso",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                return;
            }

            if (txtPrecio.Text == "")
            {
                return;
            }

            double precio = 0;
            if (txtPrecio.Text == ".")
            {
                txtPrecio.Text = "0.";
                txtPrecio.Select(txtPrecio.TextLength,2);
            }

            precio = double.Parse(txtPrecio.Text);

            dgvCarrito.SelectedRows[0].Cells[6].Value = FormatoString.AgregarFormato(precio);
            //int cantidad = int.Parse(numUpDowCantidad.Value.ToString());
            //dgvCarrito.SelectedRows[0].Cells[7].Value = cantidad;

            //double descuentoUnit = double.Parse(txtDescuento.Text) / 100;

            //dgvCarrito.SelectedRows[0].Cells[9].Value = FormatoString.AgregarFormato(descuentoUnit * precio * 0.85 * cantidad);

        }

        private void dgvCarrito_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCarrito.SelectedRows.Count < 1)
            {
                return;
            }

            int cantidad = int.Parse(dgvCarrito.SelectedRows[0].Cells[7].Value.ToString());
            double precio = FormatoString.QuitarFormato(dgvCarrito.SelectedRows[0].Cells[6].Value.ToString(),"C$",",");
            double descuentoUnit;
            if (cantidad == 0 || precio == 0)
            {
                descuentoUnit = 0;
            }
            else
            {
                descuentoUnit = FormatoString.QuitarFormato(dgvCarrito.SelectedRows[0].Cells[9].Value.ToString(),"C$",",") / (cantidad * precio * 0.85) * 100;
            }

            descuentoUnit = Math.Round(descuentoUnit, 2);
            txtPrecio.Text = precio.ToString();
            numUpDowCantidad.Value = cantidad;
            txtDescuento.Text = descuentoUnit.ToString() ;
            lblProducto.Text = dgvCarrito.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            if (txtDescuento.Text  == "")
            {
                txtDescuento.Text = "0";
            }
        }

        private void txtDescuento_Enter(object sender, EventArgs e)
        {
            if (txtDescuento.Text == "0")
            {
                txtDescuento.Text = "";
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {

            if (dgvCarrito.Rows.Count == 0)
            {
                return;
            }            

            double descuentoUnit = double.Parse(txtDescuento.Text) / 100;
            
            DataGridViewRow fila = dgvCarrito.SelectedRows[0];

            double precio = FormatoString.QuitarFormato(fila.Cells[6].Value.ToString(),"C$",",");
            int cantidad = int.Parse(fila.Cells[7].Value.ToString());

            dgvCarrito.SelectedRows[0].Cells[9].Value = FormatoString.AgregarFormato(descuentoUnit * precio *0.85 * cantidad);
        }

        private void dgvCarrito_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ActualizarTabla();
            ActualizarMontos();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            ModalTemp = new FrmCatalogModel(EnumCatalogo.Proveedores,User);
            CargarCatalogoDefault();

            ModalTemp.dgvDatos.CellDoubleClick += ObtenerProveedor;
            ModalTemp.ShowDialog(this);
        }

        private void ObtenerProveedor(object sender, DataGridViewCellEventArgs e)
        {
            IdProveedor = int.Parse(ModalTemp.dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
            string proveedor = ModalTemp.dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString();

            lblProveedor.Text = proveedor;
            ModalTemp.Close();
            ModalTemp.Dispose();
        }

        private void dgvCarrito_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvCarrito.Rows.Count == 0)
            {
                return;
            }

            if (dgvCarrito.SelectedRows.Count > 1)
            {
                MessageBox.Show("Seleccione una fila a eliminar", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if  (e.KeyCode == Keys.Delete)
            {
                int index = dgvCarrito.SelectedRows[0].Index;
                dgvCarrito.Rows.RemoveAt(index);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvCompra.DataSource = CCompra.Buscar_Compra(txtBuscar.Text);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionTexTBox.SoloNumeros(sender,e);
        }

        private void dgvCarrito_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvCarrito.Rows.Count == 0)
            {
                lblProducto.Text = "";
            }

            ActualizarMontos();
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            
            if (Double.TryParse(txtDescuento.Text,out descuento) == false)
            {
                return;
            }

            if (descuento > 100)
            {
                txtDescuento.Text = "";
                MessageBox.Show("El descuento debe ser menor a 100","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicial, fechafinal;
            fechaInicial = dtpFechaInicial.Value;
            fechafinal = dtpFechaFinal.Value;
            FrmComprasConsulta frmComprasConsulta = new FrmComprasConsulta(fechaInicial,fechafinal);
            frmComprasConsulta.ShowDialog();
        }

        private void dgvCarrito_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvCarrito.Rows.Count == 0)
            {
                return;
            }

            dgvCarrito.Columns[0].Visible = false;
        }

        private void dgvCompra_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCompra.RowCount <= 0 || dgvCompra.SelectedRows.Count <= 0)
            {
                return;
            }

            int idCompra = int.Parse(dgvCompra.SelectedRows[0].Cells[0].Value.ToString());

            ActualizarDgvDetalleCompra(idCompra);

        }

        private void dgvCompra_DataSourceChanged(object sender, EventArgs e)
        {
            int cantidad = dgvCompra.RowCount;

            lblCantidad.Text = cantidad.ToString();

            if (cantidad == 0)
            {
                lblCantidadP.Text = "0";
                ActualizarDgvDetalleCompra(-1);
            }
        }

        private void dgvDetalleCompra_DataSourceChanged(object sender, EventArgs e)
        {
            int cantidad = dgvDetalleCompra.RowCount;

            lblCantidadP.Text = cantidad.ToString();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            if (dgvCarrito.Rows.Count == 0)
            {
                MessageBox.Show("Seleccione al menos 1 producto", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lblProveedor.Text == "")
            {
                MessageBox.Show("Seleccione un proveedor", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtFactura.Text == "")
            {
                MessageBox.Show("Ingrese la factura de compra", "Mensaje de error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return;
            }

            string factura = txtFactura.Text;

            if (CCompra.Validar_Factura(IdProveedor, factura))
            {
                MessageBox.Show("El número de factura ya fue registrada con anterioridad","Factura duplicada",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            string TipoPago = cmbTipoCompra.SelectedItem.ToString();
            DateTime fecha = dtpFechaCompra.Value;
            string estado;

            if (TipoPago == "Crédito")
            {
                estado = "Pendiente";
            }
            else
            {
                estado = "Registrado";
            }

            Compra c = new Compra()
            {
                Id = IdProveedor,
                EstadoTransaccion = TipoPago,
                NoFactura = factura,
                Fecha = fecha,
                Estado = estado
                
            };

            CCompra.Registrar_Compra(IdProveedor, c);

            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                int idProducto = int.Parse(fila.Cells[0].Value.ToString());
                double precio = FormatoString.QuitarFormato(fila.Cells[6].Value.ToString(),"C$",",");
                int cantidad = int.Parse(fila.Cells[7].Value.ToString());
                double descuentoUnit = FormatoString.QuitarFormato(fila.Cells[9].Value.ToString(),"C$",",") / (precio * cantidad * 0.85);

                ProductoCompra pc = new ProductoCompra()
                {
                    Id = idProducto,
                    Costo = precio,
                    Cantidad = cantidad,
                    Descuento = descuentoUnit
                };

                CCompra.Registrar_DetCompra(pc);
            }

            CargarDatos();
            MessageBox.Show("Compra registrada", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtFactura.Text = "";
            dgvCarrito.Rows.Clear();
            txtDescuento.Text = "";
            txtPrecio.Text = "";
        }

        //{"Id","Descripcion","Marca","Modelo","Peso","Contenido","Precio","Cantidad","Subtotal","Descuento", "Iva","Monto" };

        private void ActualizarMontos()
        {
            double subtotal = 0, iva = 0, descuento = 0, total = 0;
            foreach(DataGridViewRow fila in dgvCarrito.Rows)
            {
                subtotal += FormatoString.QuitarFormato(fila.Cells[8].Value.ToString(), "C$", ",");
                descuento += FormatoString.QuitarFormato(fila.Cells[9].Value.ToString(), "C$", ",");
                iva += FormatoString.QuitarFormato(fila.Cells[10].Value.ToString(), "C$", ",");
            }

            total = subtotal - descuento + iva;

            lblSubtotal.Text = FormatoString.AgregarFormato(subtotal);
            lblDescuentoT.Text = FormatoString.AgregarFormato(descuento);
            lblIva.Text = FormatoString.AgregarFormato(iva);
            lblTotal.Text = FormatoString.AgregarFormato(total);
        }
    }
}
