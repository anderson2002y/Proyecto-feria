using Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Catalogo
{
    public class CProveedor : IDaoCatalogo<Proveedor>
    {
        public void Actualizar(int id, Proveedor t)
        {
            DProveedor.Actualizar_Proveedor(id, t);
        }

        public void Agregar(Proveedor t)
        {
            DProveedor.Insertar_Proveedor(t);
        }

        public DataTable Buscar(string busqueda)
        {
            return DProveedor.Buscar_Proveedor(busqueda);
        }

        public void CambiarEstado(int id)
        {
            DProveedor.Cambiar_EstadoProveedor(id);
        }

        public DataTable Visualizar()
        {
            return DProveedor.Mostrar_Proveedor();
        }
    }
}
