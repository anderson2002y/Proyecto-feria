using Modelo.Operaciones;
using Modelo.Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Operaciones
{
    public class CUsuarioi
    {
        public static DataTable Visualizar_Usuariois()
        {
            return DUsuario.Vizualizar_Usuarios();
        }

        public static DataTable Buscar_Usuarios(string dato)
        {
            return DUsuario.Buscar_Usuarios(dato);
        }

        public static void Cambiar_EstadoUsuario(int id)
        {
            DUsuario.Cambiar_Estado_Usuario(id);
        }

        public static void Insertar_Usuario(Usuario u, int idEmpleado)
        {
            DUsuario.Insertar_Usuario(u,idEmpleado);
        }

        public static void Actualizar_Usuario(int id, Usuario t)
        {

        }


    }
}
