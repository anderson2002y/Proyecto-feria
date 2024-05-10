using Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Operaciones
{
    public class CCompra
    {
        public static DataTable Visualizar_Compras()
        {
            return DCompra.Visualizar_Compras();
        }

        public static void Cambiar_EstadoCompra(int id)
        {
            DCompra.Cambiar_EstadoCompra(id);
        }

        public static void Registrar_Compra(int idProveedor, Compra c)
        {
            DCompra.RegistrarCompra(idProveedor,c);
        }

        public static void Registrar_DetCompra(ProductoCompra pc)
        {
            DCompra.Registrar_DetCompra(pc);
        }

        public static DataTable Visualizar_DetCompra(int idCompra)
        {
            return DCompra.Visualizar_DetCompra(idCompra);
        }

        public static DataTable Buscar_Compra(string dato)
        {
            return DCompra.Buscar_Compra(dato);
        }

        public static DataTable Visualizar_Compras(DateTime fechaInicial,DateTime fechaFinal)
        {
            return DCompra.Visualizar_Compras(fechaInicial,fechaFinal);
        }

        public static double Buscar_PrecioProducto(int idProducto)
        {
            return DCompra.Precio_UltimaCompra(idProducto);
        }

        public static bool Validar_Factura(int idProveedor,string factura)
        {
            return DCompra.Validar_Factura(idProveedor,factura);
        }
    }
}
