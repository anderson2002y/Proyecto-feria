using Modelo.Operaciones;
using Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Operaciones
{
    public class CVenta
    {
        public static DataTable Visualizar_Ventas()
        {
            return Dventa.Visualizar_Ventas();
        }

        public static DataTable Buscar_Factura(string dato)
        {
            return DFactura.Buscar_Factura(dato); 
        }

        public static DataTable  Visualizar_DetVenta(int id)
        {
            return Dventa.Visualizar_DetVentas(id);
        }

        public static void Registrar_Venta(int IdCliente, int IdEmpleado)
        {
            Dventa.Registrar_Venta(IdCliente, IdEmpleado);
        }
        public static void Registrar_DetVenta(ProductoVenta pv)
        {
            Dventa.Registrar_DetVenta(pv);
        }

        public static void Cambiar_EstadoFactura(int id)
        {
            DFactura.Cambiar_EstadoFactura(id);
        }

        public static void Registrar_Factura(Factura f)
        {
            DFactura.Registrar_Factura(f);
        }

        public static DataTable Visualizar_Ventas(DateTime inicio, DateTime final)
        {
            return Dventa.Visualizar_VentasPeriodo(inicio,final);
        }

        public static DataTable Ver_Factura(int idFactura)
        {
            return DFactura.Ver_Factura(idFactura);
        }
    }
}
