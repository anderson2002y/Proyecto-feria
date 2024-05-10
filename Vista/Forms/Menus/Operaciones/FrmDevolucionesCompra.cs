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
    public partial class FrmDevolucionesCompra : Form
    {
        private Usuario User;
        private int IdCompra;
        private int CantidadMax;
        private string[] headerProducto = {"IdDetalleCompra", "Producto", "Precio", "Cantidad", "Monto", "Observación", "Estado" };
        private double IVA = 0.15;
        private int currentIndex = 0;

        public FrmDevolucionesCompra(Usuario u)
        {
            InitializeComponent();
            CargarComboBox();
            this.User = u;

            dtpFechaInicial.Value = DateTime.Parse("01/01/2019");
            dtpFechaFinal.Value = DateTime.Now;
            dtPFecha.Value = DateTime.Now;
            CargarDatosRegistrar();
            CargarDatosDevCompras();
            CargarHeaderProductos();
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
            dgvCompras.DataSource = CCompra.Visualizar_Compras();
            dgvDetalleCompras.DataSource = CCompra.Visualizar_DetCompra(0);

            dgvCompras.Columns[0].Visible = false;

            dgvDetalleCompras.Columns[0].Visible = false;
        }

        private void CargarDatosDevCompras()
        {
            dgvDevCompras.DataSource = CDevolucionCompra.Visualizar_DevCompras();
            dgvDevCompras.Columns[0].Visible = false;
            dgvDevCompras.Columns[1].Visible = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró ningún producto a devolver","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                int idProducto = int.Parse(fila.Cells[0].Value.ToString());
                int cantidad = int.Parse(fila.Cells[3].Value.ToString());
                string observacion = fila.Cells[5].Value.ToString();
                string estado = fila.Cells[6].Value.ToString();

                int idDetalleCompra = CDevolucionCompra.Buscar_DevProductoCompra(IdCompra, idProducto);
                if (String.IsNullOrEmpty(observacion))
                {
                    MessageBox.Show("Agregue la razón de la devolución\n","Productos sin observación",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                    return;
                }

                DevolucionCompra dvc = new DevolucionCompra()
                {
                    Id = idDetalleCompra,
                    Cantidad = cantidad,
                    Observacion = observacion,
                    Estado = estado,
                    Fecha = dtPFecha.Value
                };

                CDevolucionCompra.Nueva_DevCompra(idDetalleCompra,dvc);
            }

            CargarDatosDevCompras();
            MessageBox.Show("Devolución de compra registrada","Mensaje de confirmación",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
            cmbEstado.SelectedIndex = 1;
        }

        private void txtBuscarCompra_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscarCompra.Text;

            dgvCompras.DataSource = CCompra.Buscar_Compra(busqueda);
        }

        private void txtBuscarDev_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscarDev.Text;

            dgvDevCompras.DataSource = CDevolucionCompra.Buscar_DevCompras(busqueda);
        }

        private bool ConfirmarCambiarCompra()
        {
            if (dgvProductos.Rows.Count > 0)
            {
                DialogResult confirmacion;
                confirmacion = MessageBox.Show("Aun tiene productos a devolver \nDesea cambiar de compra?", "Mensaje de aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.No)
                {
                    dgvCompras.Rows[currentIndex].Selected = false;
                    return false;
                }
            }

            currentIndex = dgvCompras.CurrentRow.Index;
            txtObservacion.Text = "";
            dgvProductos.Rows.Clear();
            return true;
        }
        private void dgvCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCompras.SelectedRows.Count != 1)
            {
                MessageBox.Show("Seleccione una fila para ver el detalle","Mensaje de error",
                                MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (!ConfirmarCambiarCompra())
            {
                return;
            }

            IdCompra = int.Parse(dgvCompras.SelectedRows[0].Cells[0].Value.ToString());
            ActualizarDetalleCompras(IdCompra);

            lblNombreProveedor.Text = dgvCompras.SelectedRows[0].Cells[1].Value.ToString();

            currentIndex = e.RowIndex;
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int IdDetalle = int.Parse(dgvDetalleCompras.SelectedRows[0].Cells[0].Value.ToString());

            foreach(DataGridViewRow filaP in dgvProductos.Rows)
            {
                if (int.Parse(filaP.Cells[0].Value.ToString()) == IdDetalle)
                {
                    MessageBox.Show("El producto ya se agregó","Producto agregado",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    return;
                }
            }

            CantidadMax = int.Parse(dgvDetalleCompras.SelectedRows[0].Cells[3].Value.ToString());

            DataGridViewRow fila = dgvDetalleCompras.SelectedRows[0];
            double precioVenta = FormatoString.QuitarFormato(fila.Cells[2].Value.ToString(),"C$",",");
            int cantidad = 1;
            double descuentoUnit = FormatoString.QuitarFormato(fila.Cells[4].Value.ToString(),"%") / 100;

            if (descuentoUnit != 0)
            {
                precioVenta = precioVenta * 0.85;
                precioVenta = (precioVenta - precioVenta * descuentoUnit) * (1 + IVA);
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicial = dtpFechaInicial.Value;
            DateTime fechaFinal = dtpFechaFinal.Value;

            dgvDevCompras.DataSource = CDevolucionCompra.Buscar_DevCompras(fechaInicial,fechaFinal);
            dgvDevCompras.Columns[0].Visible = false;
            dgvDevCompras.Columns[1].Visible = false;
        }

        private void btnEntregado_Click(object sender, EventArgs e)
        {
            if (dgvDevCompras.SelectedRows.Count != 1)
            {
                MessageBox.Show("Selecciona una sola fila","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            int idDetalleDev = int.Parse(dgvDevCompras.SelectedRows[0].Cells[0].Value.ToString());

            CDevolucionCompra.Cambiar_Estado_DevCompra(idDetalleDev);
            CargarDatosDevCompras();

            MessageBox.Show("Se cambio el estado de la devolucion","Mensaje de confirmación",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DateTime fechaI = dtpFechaInicial.Value;
            DateTime fechaF = dtpFechaFinal.Value;
            FrmDevolucionesCompraConsulta consulta = new FrmDevolucionesCompraConsulta(fechaI, fechaF);

            consulta.ShowDialog();
        }

        private void numUpDownCantidad_ValueChanged(object sender, EventArgs e)
        {
            int cantidadDev = int.Parse(numUpDownCantidad.Value.ToString());
            if (dgvProductos.RowCount <= 0)
            {
                return;
            }

            if (cantidadDev > CantidadMax)
            {
                MessageBox.Show("Cantidad máxima de productos:" + CantidadMax.ToString(),"Mensaje de aviso",
                                 MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                numUpDownCantidad.Value = CantidadMax;
                return;
            }

            double precio = FormatoString.QuitarFormato(dgvProductos.SelectedRows[0].Cells[2].Value.ToString(),"C$",",");
            dgvProductos.SelectedRows[0].Cells[3].Value = cantidadDev;
            dgvProductos.SelectedRows[0].Cells[4].Value = FormatoString.AgregarFormato(precio * cantidadDev);
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int index = dgvProductos.SelectedRows[0].Index;
                dgvProductos.Rows.RemoveAt(index);
            }
        }

        private void dgvCompras_DataSourceChanged(object sender, EventArgs e)
        {
            int cantidad = dgvCompras.RowCount;

            if (cantidad <= 0)
            {
                cantidad = 0;
            }

            lblMostrados.Text = cantidad.ToString();
        }

        private void dgvCompras_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCompras.RowCount<=0 || dgvCompras.SelectedRows.Count <= 0)
            {
                return;
            }

            if (!ConfirmarCambiarCompra())
            {
                return;
            }
            
            IdCompra = int.Parse(dgvCompras.SelectedRows[0].Cells[0].Value.ToString());
            ActualizarDetalleCompras(IdCompra);
        }

        private void ActualizarDetalleCompras(int idCompra)
        {
            dgvDetalleCompras.DataSource = CCompra.Visualizar_DetCompra(idCompra);
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count <=0 || dgvProductos.RowCount <= 0)
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

        private void btnDevolverTodo_Click(object sender, EventArgs e)
        {
            if (dgvProductos.RowCount == dgvDetalleCompras.RowCount)
            {
                MessageBox.Show("La compra ya se exportó para el registro","Productos agregados",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            CantidadMax = int.Parse(dgvDetalleCompras.Rows[0].Cells[3].Value.ToString());
            dgvProductos.Rows.Clear();

            foreach (DataGridViewRow fila in dgvDetalleCompras.Rows)
            {
                double precioVenta = FormatoString.QuitarFormato(fila.Cells[2].Value.ToString(), "C$", ",");
                int cantidad = 1;
                double descuentoUnit = FormatoString.QuitarFormato(fila.Cells[4].Value.ToString(), "%") / 100;

                if (descuentoUnit != 0)
                {
                    precioVenta = precioVenta * 0.85;
                    precioVenta = (precioVenta - precioVenta * descuentoUnit) * (1 + IVA);
                }


                string[] producto = { fila.Cells[0].Value.ToString(),
                                  fila.Cells[1].Value.ToString(),
                                  FormatoString.AgregarFormato(precioVenta),
                                  cantidad.ToString(),
                                  FormatoString.AgregarFormato(precioVenta * cantidad ).ToString(),
                                   "",
                                   "Aceptado"};

                dgvProductos.Rows.Add(producto);
            }
        }

        private void dgvDevCompras_DataSourceChanged(object sender, EventArgs e)
        {
            int cantidad = dgvDevCompras.RowCount;

            if (cantidad <= 0)
            {
                cantidad = 0;
            }

            lblCantidadDev.Text = cantidad.ToString();
        }

        private void btnConsultarCompra_Click(object sender, EventArgs e)
        {
            DateTime fechaInicial = dtpFechaInicialC.Value;
            DateTime fechaFinal = dtpFechaFinalC.Value;
            string buscar = txtBuscarCompra.Text;

            dgvCompras.DataSource = CCompra.Visualizar_Compras(fechaInicial, fechaFinal);

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
    }
}
