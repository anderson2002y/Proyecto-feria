using Modelo.Operaciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Seguridad
{
    public class CSeguridad
    {
        public static void Crear_Modulo(string Modulo)
        {
            DSeguridad.Crear_Modulo(Modulo);
        }

        public static void Crear_Rol(string Rol)
        {
            DSeguridad.Crear_Rol(Rol);
        }

        public static void Crear_Operacion(int IdModulo, string Operacion)
        {
            DSeguridad.Crear_Operacion(IdModulo, Operacion);
        }

        public static void Asignar_Operacion(int IdOperacion, int IdRol)
        {
            DSeguridad.Asignar_Operacion(IdOperacion,IdRol);
        }

        public static DataTable Acceso_Rol(int IdUsuario,int idModulo)
        {
            return DSeguridad.Acceso_Rol(IdUsuario,idModulo);
        }

        //
        public static DataTable Acceso_Rol_Modulo(int IdUsuario)
        {
            return DSeguridad.Acceso_Rol_Modulo(IdUsuario);
        }

        public static DataTable Mostrar_Modulo()
        {
            return DSeguridad.Mostrar_Modulo();
        }

        public static DataTable Mostrar_Operaciones(int IdModulo)
        {
            return DSeguridad.Mostrar_Operaciones(IdModulo);
        }


        public static DataTable Mostrar_Operaciones_Asignadas()
        {
            return DSeguridad.Mostrar_Operaciones_Asignadas();
        }

        public static DataTable Mostrar_Roles()
        {
            return DSeguridad.Mostrar_Roles();
        }
    }
}
