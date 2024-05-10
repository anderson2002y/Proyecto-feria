using Controlador;
using Controlador.Catalogo;
using Controlador.Seguridad;
using Poco;
using SistemaFerretero.Forms.Menus.Operaciones;
using SistemaFerretero.Forms.Menus.Seguridad;
using SistemaFerretero.MenusEnum;
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
namespace SistemaFerretero.Forms.Menus.Catalogo
{
    public partial class FrmCatalogModel : Form
    {
        private EnumCatalogo NameForm;
        public FrmEleccionCliente frC;
        public FrmEmpleado frE;
        public FrmProveedor frP;
        public FrmProducto frPd;
        public Controles servicios;
        public FrmUsuarios frmUser;
        public FrmPrincipal frmPrincipal;
        private IEnumerable<Operacion> operaciones;
        public Usuario User { private get; set; }

        public FrmCatalogModel(Enum name, Usuario u)
        {
            InitializeComponent();

            NameForm = (EnumCatalogo) name;
            pnlBarraTitulo.Visible = false;
            btnFacturar.Visible = false;

            operaciones = new List<Operacion>();
            this.User = u;

            if (name.Equals(EnumCatalogo.Clientes))
            {
                lblRepresentante.Visible = true;
                label1.Visible = true;
                btnEstado.Visible = false;
            }
            else
            {
                lblRepresentante.Visible = false;
                label1.Visible = false;
            }

            if (name.Equals(EnumCatalogo.Productos) && User.Rol == "Vendedor")
            {
                btnFacturar.Visible = true;
                btnFacturar.Click += AbrirVenta;
            }
            else
            {
                btnFacturar.Visible = false;
            }

            RestringirAcceso();
            loadModel();
        }

        private void AbrirVenta(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count != 1)
            {
                MessageBox.Show("Seleccione un solo producto", "Mensaje de aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataGridViewRow producto = dgvDatos.SelectedRows[0];

            Producto p = new Producto()
            {
                Id = int.Parse(producto.Cells[0].Value.ToString()),
                Nombre = producto.Cells[1].Value.ToString(),
                Marca = producto.Cells[2].Value.ToString(),
                Precio = Math.Round(double.Parse(producto.Cells[6].Value.ToString()), 2),
                UnidadesDisponibles = int.Parse(producto.Cells[7].Value.ToString())
            };

            if (p.UnidadesDisponibles <= 0)
            {
                MessageBox.Show("Producto sin stock", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmPrincipal.AbrirPanel(MenusEnum.MnForm.Catalogos, "Venta", p);

        }

        private void RestringirAcceso()
        {
            foreach(DataRow fila in CSeguridad.Acceso_Rol(User.Id, 1).Rows)
            {
                Operacion op = new Operacion()
                {
                    Id = Convert.ToInt32(fila.ItemArray[0]),
                    Descripcion = Convert.ToString(fila.ItemArray[2]),
                    Estado = Convert.ToBoolean(fila.ItemArray[3])
                };

                operaciones.Append(op);
            }

            operaciones = operaciones.Where(o => o.Descripcion.Contains(this.NameForm.ToString()));

            foreach(Operacion o in operaciones)
            {
                string descripcion = o.Descripcion.Replace(" "+NameForm.ToString(),"");

                switch (descripcion)
                {
                    case "Agregar":
                        btnNuevo.Visible = o.Estado;
                        break;
                    case "Actualizar":
                        btnActualizar.Visible = o.Estado;
                        break;
                    case "Cambiar Estado":
                        btnEstado.Visible = o.Estado;
                        break;

                    default:
                        break;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            switch (NameForm)
            {
                case EnumCatalogo.Clientes:
                    frC = new FrmEleccionCliente(servicios, this);
                    frC.ShowDialog();

                    break;
                case EnumCatalogo.Proveedores:
                    frP = new FrmProveedor(this, servicios, true);
                    frP.ShowDialog();

                    break;
                case EnumCatalogo.Empleados:
                    frE = new FrmEmpleado(this, servicios, true);
                    frE.ShowDialog();
                    break;

                case EnumCatalogo.Productos:
                    frPd = new FrmProducto(this, servicios, true);
                    frPd.ShowDialog();
                    break;

                default:
                    frmUser = new FrmUsuarios(this, true,User);
                    frmUser.ShowDialog();
                    break;
            }
        }

        public void loadModel()
        {
            groupBox1.Text += " " + NameForm;
            lblBuscar.Text += " " + NameForm;
            servicios = new Controles(NameForm.ToString());

            RefrescarTabla();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = null;
            string busqueda = txtBuscar.Text;
            switch (NameForm)
            {
                case EnumCatalogo.Productos:
                    dt = servicios.cProducto.Buscar(busqueda);
                    break;
                case EnumCatalogo.Proveedores:
                    dt = servicios.cProveedor.Buscar(busqueda);
                    break;
                case EnumCatalogo.Empleados:
                    dt = servicios.cEmpleado.Buscar(busqueda);
                    break;
                case EnumCatalogo.Clientes:
                    dt = servicios.cCliente.Buscar(busqueda);
                    break;

                default:
                    dt = servicios.cUsuario.Buscar(busqueda);
                    break;
            }
            dgvDatos.DataSource = dt;
            dgvDatos.Columns[0].Visible = false;
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells[0].Value);

            switch (NameForm)
            {
                case EnumCatalogo.Productos:
                    servicios.cProducto.CambiarEstado(id);
                    break;
                case EnumCatalogo.Proveedores:
                    servicios.cProveedor.CambiarEstado(id);
                    break;
                case EnumCatalogo.Empleados:
                    servicios.cEmpleado.CambiarEstado(id);
                    break;
                case EnumCatalogo.Clientes:
                    servicios.cCliente.CambiarEstado(id);
                    break;

                default:
                    servicios.cUsuario.CambiarEstado(id);
                    break;

            }

            RefrescarTabla();
            MessageBox.Show("Se cambio el estado del " + NameForm.ToString().ToLower(), "Mensaje de información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void RefrescarTabla()
        {
            DataTable dt = null;

            switch (NameForm)
            {
                case EnumCatalogo.Productos:
                    dt = servicios.cProducto.Visualizar();
                    break;
                case EnumCatalogo.Proveedores:
                    dt = servicios.cProveedor.Visualizar();
                    break;
                case EnumCatalogo.Empleados:
                    dt = servicios.cEmpleado.Visualizar();
                    break;
                case EnumCatalogo.Clientes:
                    dt = servicios.cCliente.Visualizar();
                    break;

                default:
                    dt = servicios.cUsuario.Visualizar();
                    break;
            }
            dgvDatos.DataSource = dt;
            dgvDatos.Columns[0].Visible = false;
            dgvDatos.MultiSelect = false;
            dgvDatos.ClearSelection();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            switch (NameForm)
            {
                case EnumCatalogo.Clientes:
                    int idCliente = int.Parse(dgvDatos.SelectedRows[0].Cells[0].Value.ToString());
                    DataTable dt = CCliente.Buscar_Cliente(idCliente);
                    string tipoCliente = dt.Rows[0].ItemArray[0].ToString();

                    if (tipoCliente == "CN")
                    {
                        string pNombre = dt.Rows[0].ItemArray[2].ToString();
                        string sNombre = dt.Rows[0].ItemArray[3].ToString();
                        string pApellido = dt.Rows[0].ItemArray[4].ToString();
                        string sApellido = dt.Rows[0].ItemArray[5].ToString();
                        string telefono = dt.Rows[0].ItemArray[6].ToString();
                        string correo = dt.Rows[0].ItemArray[7].ToString();
                        string direccion = dt.Rows[0].ItemArray[8].ToString();

                        ClienteNatural c = new ClienteNatural()
                        {
                            Id = idCliente,
                            PrimerNombre = pNombre,
                            SegundoNombre = sNombre,
                            PrimerApellido = pApellido,
                            SegundoApellido = sApellido,
                            Telefono = telefono,
                            Correo = correo,
                            Direccion = direccion
                        };

                        FrmClienteNatural fcn = new FrmClienteNatural(servicios, c)
                        {
                            Flag = true,
                            CatalogModel = this
                        };

                        fcn.ShowDialog();
                    }
                    else
                    {
                        string nombreCompañia = dt.Rows[0].ItemArray[2].ToString();
                        string ruc = dt.Rows[0].ItemArray[3].ToString();
                        string pNombre = dt.Rows[0].ItemArray[4].ToString();
                        string sNombre = dt.Rows[0].ItemArray[5].ToString();
                        string pApellido = dt.Rows[0].ItemArray[6].ToString();
                        string sApellido = dt.Rows[0].ItemArray[7].ToString();
                        string telefono = dt.Rows[0].ItemArray[8].ToString();
                        string correo = dt.Rows[0].ItemArray[9].ToString();
                        string direccion = dt.Rows[0].ItemArray[10].ToString();

                        ClienteJuridico cj = new ClienteJuridico()
                        {
                            Id = idCliente,
                            NombreCompañia = nombreCompañia,
                            NoRuc = ruc,
                            PrimerNombre = pNombre,
                            SegundoNombre = sNombre,
                            PrimerApellido = pApellido,
                            SegundoApellido = sApellido,
                            Telefono = telefono,
                            Correo = correo,
                            Direccion = direccion
                        };

                        FrmClienteJuridico fcj = new FrmClienteJuridico(servicios, cj)
                        {
                            Flag = false,
                            CatalogModel = this
                        };

                        fcj.ShowDialog();
                    }

                    break;
                case EnumCatalogo.Proveedores:
                    frP = new FrmProveedor(this, servicios, false);
                    frP.flag = false;
                    frP.ShowDialog();

                    break;
                case EnumCatalogo.Empleados:
                    frE = new FrmEmpleado(this, servicios, false);
                    frE.flag = false;
                    frE.ShowDialog();

                    break;

                case EnumCatalogo.Productos:
                    frPd = new FrmProducto(this, servicios, false);
                    frPd.ShowDialog();
                    break;

                default:
                    frmUser = new FrmUsuarios(this, false,User);
                    frmUser.flag = false;
                    frmUser.ShowDialog();
                    break;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            if (!NameForm.Equals(EnumCatalogo.Clientes))
            {
                return;
            }

            int id = int.Parse(dgvDatos.SelectedRows[0].Cells[0].Value.ToString());

            DataRow cliente = CCliente.Buscar_Cliente(id).Rows[0];

            if (cliente.ItemArray[0].ToString() == "CJ")
            {
                label1.Visible = true;
                lblRepresentante.Visible = true;
                string pNombre = cliente.ItemArray[4].ToString();
                string sNombre = cliente.ItemArray[5].ToString();
                string pApellido = cliente.ItemArray[6].ToString();
                string sApellido = cliente.ItemArray[7].ToString();

                lblRepresentante.Text = pNombre + " " + sNombre + " " + pApellido + " " + sApellido;
            }
            else
            {
                label1.Visible = false;
                lblRepresentante.Visible = false;
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            switch (NameForm)
            {
                case EnumCatalogo.Clientes:
                    frC = new FrmEleccionCliente(servicios, this);
                    frC.ShowDialog();

                    break;
                case EnumCatalogo.Proveedores:
                    frP = new FrmProveedor(this, servicios, true);
                    frP.ShowDialog();

                    break;
                case EnumCatalogo.Empleados:
                    frE = new FrmEmpleado(this, servicios, true);
                    frE.ShowDialog();

                    break;

                case EnumCatalogo.Productos:
                    frPd = new FrmProducto(this, servicios, true);
                    frPd.ShowDialog();
                    break;
                default:
                    frmUser = new FrmUsuarios(this, true,User);
                    frmUser.ShowDialog();

                    break;
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (!ValidarSeleccion())
            {
                MessageBox.Show("Debe seleccionar una fila para actualizar","Mensaje de aviso",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            switch (NameForm)
            {
                case EnumCatalogo.Clientes:
                    int idCliente = int.Parse(dgvDatos.SelectedRows[0].Cells[0].Value.ToString());
                    DataTable dt = CCliente.Buscar_Cliente(idCliente);
                    string tipoCliente = dt.Rows[0].ItemArray[0].ToString();

                    if (tipoCliente == "CN")
                    {
                        string pNombre = dt.Rows[0].ItemArray[2].ToString();
                        string sNombre = dt.Rows[0].ItemArray[3].ToString();
                        string pApellido = dt.Rows[0].ItemArray[4].ToString();
                        string sApellido = dt.Rows[0].ItemArray[5].ToString();
                        string telefono = dt.Rows[0].ItemArray[6].ToString();
                        string correo = dt.Rows[0].ItemArray[7].ToString();
                        string direccion = dt.Rows[0].ItemArray[8].ToString();

                        ClienteNatural c = new ClienteNatural()
                        {
                            Id = idCliente,
                            PrimerNombre = pNombre,
                            SegundoNombre = sNombre,
                            PrimerApellido = pApellido,
                            SegundoApellido = sApellido,
                            Telefono = telefono,
                            Correo = correo,
                            Direccion = direccion
                        };

                        FrmClienteNatural fcn = new FrmClienteNatural(servicios, c)
                        {
                            Flag = false,
                            CatalogModel = this
                        };

                        fcn.ShowDialog();
                    }
                    else
                    {
                        string nombreCompañia = dt.Rows[0].ItemArray[2].ToString();
                        string ruc = dt.Rows[0].ItemArray[3].ToString();
                        string pNombre = dt.Rows[0].ItemArray[4].ToString();
                        string sNombre = dt.Rows[0].ItemArray[5].ToString();
                        string pApellido = dt.Rows[0].ItemArray[6].ToString();
                        string sApellido = dt.Rows[0].ItemArray[7].ToString();
                        string telefono = dt.Rows[0].ItemArray[8].ToString();
                        string correo = dt.Rows[0].ItemArray[9].ToString();
                        string direccion = dt.Rows[0].ItemArray[10].ToString();

                        ClienteJuridico cj = new ClienteJuridico()
                        {
                            Id = idCliente,
                            NombreCompañia = nombreCompañia,
                            NoRuc = ruc,
                            PrimerNombre = pNombre,
                            SegundoNombre = sNombre,
                            PrimerApellido = pApellido,
                            SegundoApellido = sApellido,
                            Telefono = telefono,
                            Correo = correo,
                            Direccion = direccion
                        };

                        FrmClienteJuridico fcj = new FrmClienteJuridico(servicios, cj)
                        {
                            Flag = false,
                            CatalogModel = this
                        };

                        fcj.ShowDialog();
                    }

                    break;
                case EnumCatalogo.Proveedores:
                    frP = new FrmProveedor(this, servicios, false);
                    frP.flag = false;
                    frP.ShowDialog();

                    break;
                case EnumCatalogo.Empleados:
                    frE = new FrmEmpleado(this, servicios, false);
                    frE.flag = false;
                    frE.ShowDialog();

                    break;

                case EnumCatalogo.Productos:
                    frPd = new FrmProducto(this, servicios, false);
                    frPd.ShowDialog();
                    break;

                default:
                    frmUser = new FrmUsuarios(this, false,User);
                    frmUser.flag = false;
                    frmUser.ShowDialog();
                    break;
            }
        }

        private void btnEstado_Click_1(object sender, EventArgs e)
        {
            if (!ValidarSeleccion())
            {
                MessageBox.Show("Seleccione una fila para cambiar el estado de ella","Mensaje de aviso",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                return;
            }

            int id = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells[0].Value);

            switch (NameForm)
            {
                case EnumCatalogo.Productos:
                    servicios.cProducto.CambiarEstado(id);
                    break;
                case EnumCatalogo.Proveedores:
                    servicios.cProveedor.CambiarEstado(id);
                    break;
                case EnumCatalogo.Empleados:
                    servicios.cEmpleado.CambiarEstado(id);
                    break;

                default:
                    servicios.cUsuario.CambiarEstado(id);
                    break;

            }

            RefrescarTabla();
            MessageBox.Show("Se cambio el estado del " + NameForm.ToString().ToLower().Replace("s",""), "Mensaje de información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dgvDatos_DataSourceChanged(object sender, EventArgs e)
        {
            int cantidad = dgvDatos.RowCount;
            lblCantidad.Text = cantidad.ToString();
        }

        private bool ValidarSeleccion()
        {
            if (dgvDatos.SelectedRows.Count <= 0)
            {
                return false;
            }

            return true;
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if ((keyData != Keys.Escape))
                return base.ProcessCmdKey(ref msg, keyData);

            if (pnlBarraTitulo.Visible == true)
            {
                if (keyData == Keys.Escape)
                {
                    this.Close();
                }
            }
            return true;
        }
    }
    
}
