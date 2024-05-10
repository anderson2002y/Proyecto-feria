using Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Catalogo
{
    public class Controles
    {
        public CProducto cProducto;
        public CEmpleado cEmpleado;
        public CProveedor cProveedor;
        public CCliente cCliente;
        public CUsuario cUsuario;

        public string Nombre;

        public Controles(string name)
        {
            Nombre = name;

            switch (name)
            {
                case "Productos":

                    if (cProducto == null)
                    {
                        cProducto = new CProducto();
                    }
                    break;

                case "Empleados":

                    if (cEmpleado == null)
                    {
                        cEmpleado = new CEmpleado();
                    }
                    break;

                case "Proveedores":

                    if (cProveedor == null)
                    {
                        cProveedor = new CProveedor();
                    }
                    break;
                case "Clientes":
                    if (cCliente == null)
                    {
                        cCliente = new CCliente();
                    }
                    break;

                case "Usuarios":
                    if (cUsuario == null)
                    {
                        cUsuario = new CUsuario();
                    }
                    break;
            }
        }
    }
}
