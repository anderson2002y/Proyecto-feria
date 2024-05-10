using Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Operaciones
{
    public class CDevolucionCompra
    {
        public static DataTable Visualizar_DevCompras()
        {
            return DDevCompra.Visualizar_DevCompras();
        }

        public static DataTable Buscar_DevCompras(string dato)
        {
            return DDevCompra.Buscar_DevCompras(dato);
        }

        public static void Cambiar_Estado_DevCompra(int id)
        {
            DDevCompra.CambiarEstado_DevolucionCompra(id);
        }

        public static void Nueva_DevCompra(int idDetalleCompra, DevolucionCompra dc)
        {
            DDevCompra.Nueva_DevCompra(idDetalleCompra,dc);
        }

        public static DataTable Buscar_DevCompras(DateTime fechaInicial,DateTime fechaFinal)
        {
            return DDevCompra.Buscar_DevCompras(fechaInicial,fechaFinal);
        }

        public static int Buscar_DevProductoCompra(int idCompra, int idProducto)
        {
            return DDevCompra.Buscar_DevProductoCompra(idCompra,idProducto);
        }
    }
}
