using Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Operaciones
{
    public class CDevolucionVenta
    {
        public static DataTable Visualizar_DevVentas()
        {
            return DDevVenta.Visualizar_DevVentas();
        }

        public static DataTable Buscar_DevVentas(string dato)
        {
            return DDevVenta.Buscar_DevVentas(dato);
        }

        public static void Cambiar_Estado_DevolucionVenta(int id)
        {
            DDevVenta.CambiarEstado_DevolucionVenta(id);
        }

        public static void Nueva_DevVenta(int idFactura, DevolucionVenta dv)
        {
            DDevVenta.Nueva_DevVenta(idFactura, dv);
        }

        public static DataTable Buscar_DevVentas(DateTime FechaInicial,DateTime FechaFinal)
        {
            return DDevVenta.Buscar_DevVentas(FechaInicial,FechaFinal);
        }
        
    }
}
