using Controlador.Catalogo;
using Controlador.Operaciones;
using Controlador.Validaciones;
using Poco;
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
    public partial class FrmDevolucionesVentas : Form
    {
        private Usuario User;
        private int CantidadMax = 0;
        private int IdFactura = 0;
        private string[] headerProducto = { "Id", "Producto", "Precio", "Cantidad", "Monto", "Observación", "Estado" };
        private double IVA = 0.15;
        private int currentIndex = 0;

        public FrmDevolucionesVentas(Usuario u)
        {
            InitializeComponent();
            this.User = u;
            CargarComboBox();
            RestringirAcceso();

            dtpFechaInicial.Value = DateTime.Parse("01/01/2019");
            dtpFechaFinal.Value = DateTime.Now;
            dtPFecha.Value = DateTime.Now;

            CargarDatosRegistrar();
            CargarDatosDevoluciones();
            CargarHeaderProductos();
        }

        private void RestringirAcceso()
        {
        }

        private void CargarDatosDevoluciones()
        {
            dgvDevVenta.DataSource = CDevolucionVenta.Visualizar_DevVentas();
            dgvDevVenta.Columns[0].Visible = false;
        }

        private void CargarHeaderProductos()
        {
            dgvProductos.Columns.Add(headerProducto[0], headerProducto[0]);
            dgvProductos.Columns.Add(headerProducto[1], headerProducto[1]);
            dgvProductos.Columns.Add(headerProducto[2], headerProducto[2]);
            dgvProductos.Columns.Add(headerProducto[3], headerProducto[3]);
            dgvProductos.Columns.Add(headerProducto[4], headerProducto[4]);
            dgvProductos.Columns.Add(headerProducto[5], headerProducto[5]);
            dgvProductos.Columns.Add(headerProducto[6], headerProducto[6]);
            dgvProductos.Columns[0].Visible = false;
        }

        private void CargarDatosRegistrar()
        {
            dgvVentas.DataSource = CVenta.Visualizar_Ventas();
            dgvDetalleVenta.DataSource = CVenta.Visualizar_DetVenta(0);

            dgvVentas.Columns[0].Visible = false;
            dgvVentas.Columns[1].Visible = false;

            dgvDetalleVenta.Columns[0].Visible = false;

            if (dgvVentas.SelectedRows.Count != 0)
            {
                int idVenta = int.Parse(dgvVentas.SelectedRows[0].Cells[1].Value.ToString());
                dgvDetalleVenta.DataSource = CVenta.Visualizar_DetVenta(idVenta);
            }


        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count == 0)
            {
                MessageBox.Show("Sin productos a devolver", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {

                int id = int.Parse(fila.Cells[0].Value.ToString());
                int cantidad = int.Parse(fila.Cells[3].Value.ToString());
                string observacion = fila.Cells[5].Value.ToString();

                if (String.IsNullOrEmpty(observacion))
                {
                    MessageBox.Show("Agregue la razón de la devolución\n", "Productos sin observación", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                DevolucionVenta devolucionVenta = new DevolucionVenta()
                {
                    IdProducto = id,
                    Fecha = DateTime.Now,
                    Cantidad = cantidad,
                    Observacion = observacion,
                    Estado = fila.Cells[6].Value.ToString()
                };

                CDevolucionVenta.Nueva_DevVenta(IdFactura, devolucionVenta);
            }

            CargarDatosDevoluciones();
            MessageBox.Show("Devolución de venta registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CargarComboBox()
        {
            cmbEstado.Items.Clear();
            List<string> cargos = new List<string>();

            foreach (var item in Enum.GetValues(typeof(EstadoDevolucionEnum)))
            {
                cargos.Add(item.ToString().Replace("_", " "));
            }

            cmbEstado.Items.AddRange(cargos.ToArray());
            cmbEstado.SelectedIndex = 0;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            DateTime FechaInicial = dtpFechaInicial.Value;
            DateTime FechaFinal = dtpFechaFinal.Value;

            dgvDevVenta.DataSource = CDevolucionVenta.Buscar_DevVentas(FechaInicial, FechaFinal);
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVentas.SelectedRows.Count != 1)
            {
                MessageBox.Show("Seleccione una sola venta para ver el detalle", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvProductos.Rows.Count != 0)
            {
                DialogResult confirmacion;
                confirmacion = MessageBox.Show("Aún tiene productos agregados\nSeguro desea cambiar la venta?", "Mensaje de aviso",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.No)
                {
                    return;
                }

                dgvProductos.Rows.Clear();
            }
            int index = e.RowIndex;
            DataGridViewRow fila = dgvVentas.Rows[index];

            int IdVenta = int.Parse(fila.Cells[1].Value.ToString());
            ActualizarDetalleVenta(IdVenta);

            lblCliente.Text = fila.Cells[4].Value.ToString();
            IdFactura = int.Parse(fila.Cells[0].Value.ToString());
        }

        private void txtBuscarVentas_TextChanged(object sender, EventArgs e)
        {
            dgvVentas.DataSource = CVenta.Buscar_Factura(txtBuscarVentas.Text);
        }

        private void txtBuscarDev_TextChanged(object sender, EventArgs e)
        {
            dgvDevVenta.DataSource = CDevolucionVenta.Buscar_DevVentas(txtBuscarDev.Text);
        }

        private void btnEntregado_Click(object sender, EventArgs e)
        {
            if (dgvDevVenta.SelectedRows.Count != 1)
            {
                MessageBox.Show("Seleccione una sola fila", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idDevolucion = int.Parse(dgvDevVenta.SelectedRows[0].Cells[0].Value.ToString());

            CDevolucionVenta.Cambiar_Estado_DevolucionVenta(idDevolucion);

            CargarDatosDevoluciones();

            MessageBox.Show("Se cambió el estado de la devolución", "Mensaje de información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicial = dtpFechaInicial.Value;
            DateTime fechaFinal = dtpFechaFinal.Value;

            FrmDevolucionesVentaConsulta consulta = new FrmDevolucionesVentaConsulta(fechaInicial, fechaFinal);
            consulta.ShowDialog();
        }

        private void dgvVentas_DataSourceChanged(object sender, EventArgs e)
        {
            int cantidad = dgvVentas.RowCount;

            if (cantidad <= 0)
            {
                cantidad = 0;
            }

            lblMostrados.Text = cantidad.ToString();
        }

        private void btnConsultarVenta_Click(object sender, EventArgs e)
        {
            DateTime fechaInicial = dtpFechaInicialV.Value;
            DateTime fechaFinal = dtpFechaFinalV.Value;

            dgvVentas.DataSource = CVenta.Visualizar_Ventas(fechaInicial, fechaFinal);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int IdProducto = int.Parse(dgvDetalleVenta.SelectedRows[0].Cells[0].Value.ToString());

            foreach (DataGridViewRow filaP in dgvProductos.Rows)
            {
                if (int.Parse(filaP.Cells[0].Value.ToString()) == IdProducto)
                {
                    MessageBox.Show("El producto ya se agregó", "Producto agregado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            CantidadMax = int.Parse(dgvDetalleVenta.SelectedRows[0].Cells[3].Value.ToString());

            DataGridViewRow fila = dgvDetalleVenta.SelectedRows[0];
            double precioVenta = FormatoString.QuitarFormato(fila.Cells[2].Value.ToString(), "C$", ",");
            int cantidad = 1;
            double descuentoUnit = FormatoString.QuitarFormato(fila.Cells[4].Value.ToString(), "%") / 100;

            if (descuentoUnit != 0)
            {
                precioVenta = (precioVenta - precioVenta * descuentoUnit) ;
            }


            string[] producto = { fila.Cells[0].Value.ToString(),
                                  fila.Cells[1].Value.ToString(),
                                  FormatoString.AgregarFormato(precioVenta),
                                  cantidad.ToString(),
                                  FormatoString.AgregarFormato(precioVenta * cantidad ),
                                   "",
                                   "Aceptado"};

            dgvProductos.Rows.Add(producto);
        }

        private void btnDevolverTodo_Click(object sender, EventArgs e)
        {
            if (dgvProductos.RowCount == dgvDetalleVenta.RowCount)
            {
                MessageBox.Show("La venta ya se exportó para el registro", "Productos agregados", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            CantidadMax = int.Parse(dgvDetalleVenta.Rows[0].Cells[3].Value.ToString());
            dgvProductos.Rows.Clear();

            foreach (DataGridViewRow fila in dgvDetalleVenta.Rows)
            {
                double precioVenta = FormatoString.QuitarFormato(fila.Cells[2].Value.ToString(), "C$", ",");
                int cantidad = 1;
                double descuentoUnit = FormatoString.QuitarFormato(fila.Cells[4].Value.ToString(), "%") / 100;

                if (descuentoUnit != 0)
                {
                    precioVenta = (precioVenta - precioVenta * descuentoUnit);
                }


                string[] producto = { fila.Cells[0].Value.ToString(),
                                  fila.Cells[1].Value.ToString(),
                                  FormatoString.AgregarFormato(precioVenta),
                                  cantidad.ToString(),
                                  FormatoString.AgregarFormato(precioVenta * cantidad ),
                                   "",
                                   "Aceptado"};

                dgvProductos.Rows.Add(producto);
            }
        }

        private void dgvVentas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVentas.RowCount <= 0 || dgvVentas.SelectedRows.Count <= 0)
            {
                return;
            }

            if (!ConfirmarCambiarVenta())
            {
                return;
            }

            lblCliente.Text = dgvVentas.SelectedRows[0].Cells[4].Value.ToString();
            IdFactura = int.Parse(dgvVentas.SelectedRows[0].Cells[0].Value.ToString());
            ActualizarDetalleVenta(IdFactura);
            
        }

        private bool ConfirmarCambiarVenta()
        {
            if (dgvProductos.Rows.Count > 0)
            {
                DialogResult confirmacion;
                confirmacion = MessageBox.Show("Aun tiene productos a devolver \nDesea cambiar de compra?", "Mensaje de aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.No)
                {
                    dgvVentas.Rows[currentIndex].Selected = false;
                    return false;
                }
            }

            currentIndex = dgvVentas.CurrentRow.Index;
            dgvProductos.Rows.Clear();
            return true;
        }

        private void ActualizarDetalleVenta(int idFactura)
        {
            dgvDetalleVenta.DataSource = CVenta.Visualizar_DetVenta(idFactura);
        }

        private void numUpDownCantidad_ValueChanged_1(object sender, EventArgs e)
        {
            int cantidadDev = int.Parse(numUpDownCantidad.Value.ToString());
            if (dgvProductos.RowCount <= 0)
            {
                return;
            }

            if (cantidadDev > CantidadMax)
            {
                MessageBox.Show("Cantidad máxima de productos:" + CantidadMax.ToString(), "Mensaje de aviso",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numUpDownCantidad.Value = CantidadMax;
                return;
            }

            double precio = FormatoString.QuitarFormato(dgvProductos.SelectedRows[0].Cells[2].Value.ToString(), "C$", ",");
            dgvProductos.SelectedRows[0].Cells[3].Value = cantidadDev;
            dgvProductos.SelectedRows[0].Cells[4].Value = FormatoString.AgregarFormato(precio * cantidadDev);
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count <= 0 || dgvProductos.RowCount <= 0)
            {
                lblProducto.Text = "";
                return;
            }

            DataGridViewRow fila = dgvProductos.SelectedRows[0];
            string producto = fila.Cells[1].Value.ToString();
            int cantidad = int.Parse(fila.Cells[3].Value.ToString());
            string observacion = fila.Cells[5].Value.ToString();
            string estado = fila.Cells[6].Value.ToString();

            lblProducto.Text = producto;
            numUpDownCantidad.Value = cantidad;
            txtObservacion.Text = observacion;

            if (estado == "Aceptado")
            {
                cmbEstado.SelectedIndex = 0;
            }
            else
            {
                cmbEstado.SelectedIndex = 1;
            }
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int index = dgvProductos.SelectedRows[0].Index;
                dgvProductos.Rows.RemoveAt(index);
            }
        }

        private void dgvDevVenta_DataSourceChanged(object sender, EventArgs e)
        {
            int cantidad = dgvDevVenta.RowCount;

            if (cantidad <= 0)
            {
                cantidad = 0;
            }

            lblCantidadDev.Text = cantidad.ToString();
        }

        private void txtObservacion_TextChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count <= 0)
            {
                return;
            }

            string observacion = txtObservacion.Text;

            dgvProductos.SelectedRows[0].Cells[5].Value = observacion;
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count <= 0)
            {
                return;
            }

            dgvProductos.SelectedRows[0].Cells[6].Value = cmbEstado.SelectedItem.ToString();
        }
    }
}