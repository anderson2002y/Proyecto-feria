using Controlador.Operaciones;
using Controlador.Validaciones;
using Poco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFerretero.Forms.Menus.Operaciones
{
    public partial class FrmPagos : Form
    {
        private DataGridViewRow Compra;
        private int IdCompra;
        public FrmPagos(DataGridViewRow compra = null)
        {
            InitializeComponent();

            Compra = compra;

            cargarPagos();
            ValidarPago();
            CargarPago();
        }

        private void CargarPago()
        {
            if (Compra.Cells[9].Value.ToString() == "Pagado" || Compra.Cells[4].Value.ToString() == "Contado")
            {
                txtMonto.Enabled = false;
                btnPagar.Visible = false;
                return;
            }

            string proveedor = Compra.Cells[1].Value.ToString();
            string factura = Compra.Cells[2].Value.ToString();
            double monto = FormatoString.QuitarFormato(Compra.Cells[8].Value.ToString(),"C$",",");

            DataTable abonos = CPagoCredito.Buscar_PagosCredito(Compra.Cells[2].Value.ToString());
            double pagos = 0;

            foreach (DataRow fila in abonos.Rows)
            {
                pagos += FormatoString.QuitarFormato(fila.ItemArray[4].ToString(),"C$",",");
            }

            lblProveedor.Text = proveedor;
            lblFactura.Text = factura;
            lblDeuda.Text = FormatoString.AgregarFormato(monto - pagos);
        }

        private void ValidarPago()
        {
            if (Compra == null)
            {
                txtMonto.Enabled = false;
                btnPagar.Visible = false;
                return;
            }
        }

        private void cargarPagos()
        {
            dgvPagos.DataSource = CPagoCredito.Visualizar_PagosCredito();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionTexTBox.SoloNumeros(sender, e);

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            int idCompra = int.Parse(Compra.Cells[0].Value.ToString());
            DateTime fechaPago = DateTime.Now;
            double monto = double.Parse(txtMonto.Text);

            if (monto == 0)
            {
                MessageBox.Show("El monto de pago debe ser mayor a 0","Mensaje de aviso",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            if (monto > FormatoString.QuitarFormato(lblDeuda.Text,"C$",","))
            {
                MessageBox.Show("El abono debe ser menor o igual a la deuda","Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            Pago p = new Pago()
            {
                Id = idCompra,
                Fecha = fechaPago,
                Monto = monto
            };

            CPagoCredito.Registrar_PagoCredito(p);

            MessageBox.Show("Pago realizado", "Mensaje de confirmación",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvPagos.DataSource = CPagoCredito.Buscar_PagosCredito(txtBuscar.Text);
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
