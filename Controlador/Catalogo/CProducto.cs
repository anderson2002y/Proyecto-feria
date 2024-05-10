using Poco;
using Modelo.Catalogo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Catalogo
{
    public class CProducto : IDaoCatalogo<Producto>
    {
        public CProducto()
        {

        }

        public void Actualizar(int id, Producto t)
        {
            DProducto.Actualizar_Producto(id,t);
        }

        public void Agregar(Producto t)
        {
            DProducto.Insertar_Producto(t);
        }

        public DataTable Buscar(string busqueda)
        {
            return DProducto.Buscar_Producto(busqueda);
        }

        public void CambiarEstado(int id)
        {
            DProducto.Cambiar_EstadoProducto(id);
        }

        public DataTable Visualizar()
        {
            return DProducto.TablaProductos();
        }

        public static DataTable BuscarStatic(string busqueda)
        {
            return DProducto.Buscar_Producto(busqueda);
        }
    }
}
