using Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Catalogo
{
    public class CEmpleado : IDaoCatalogo<Empleado>
    {
        public void Actualizar(int id, Empleado t)
        {
            DEmpleado.Actualizar_Empleado(id,t);
        }

        public static DataTable BuscarStatic(string dato)
        {
            return DEmpleado.Buscar_Empleado(dato);
        }
        public void Agregar(Empleado t)
        {
            DEmpleado.Insertar_Empleado(t);
        }

        public DataTable Buscar(string busqueda)
        {
            return DEmpleado.Buscar_Empleado(busqueda);
        }

        public void CambiarEstado(int id)
        {
            DEmpleado.Cambiar_EstadoEmpleado(id);
        }

        public DataTable Visualizar()
        {
            return DEmpleado.Mostrar_Empleado();
        }
    }
}
