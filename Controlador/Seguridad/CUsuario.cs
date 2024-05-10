using Controlador.Catalogo;
using Modelo.Operaciones;
using Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class CUsuario : IDaoCatalogo<Usuario>
    {
        private int idEmpleado;
        public void Actualizar(int id, Usuario t)
        {
            //DUsuario.Actualizar_Usuario(id, t);
        }

        public void Agregar(Usuario t)
        {

        }

        public static DataTable Agregar( int IdEmpleado,string contraseña,int rol)
        {
            return DUsuario.Insertar_Usuario(IdEmpleado,contraseña ,rol);
        }

        public DataTable Buscar(string busqueda)
        {
             return DUsuario.Buscar_Usuarios(busqueda);
            
        }

        public void CambiarEstado(int id)
        {
            DUsuario.Cambiar_Estado_Usuario(id);
        }

        public void Actualizar_Usuario(int idUsuario,string rol)
        {
            DUsuario.Actualizar_Usuario(idUsuario,rol);
        }

        public DataTable Visualizar()
        {
            return DUsuario.Vizualizar_Usuarios();
        }

        public static int Validar_Acceso(string usuario, string contraseña)
        {
            DataTable dt = DUsuario.Validar_Acceso(usuario,contraseña);
            DataRow fila = dt.Rows[0];

            if (fila.ItemArray[0].ToString() == "Acceso Denegado")
            {
                return 1;
            }

            if (fila.ItemArray[0].ToString() == "Acceso revocado")
            {
                return 2;
            }

            return 0;
        }

        public static int Actualizar_Contraseña(int id,string userName,string contraseña, string nueva)
        {
            DataTable dt = DUsuario.Cambiar_Contraseña_Usuario(id,userName,nueva,contraseña);
            DataRow fila = dt.Rows[0];

            if (fila.ItemArray[0].ToString() == "Acceso Denegado")
            {
                return 1;
            }

            if (fila.ItemArray[0].ToString() == "No debe poner la misma contraseña")
            {
                return 2;
            }

            return 0;
        }

        public static DataTable Obtener_Usuario(string usuario, string contraseña)
        {
            return DUsuario.Validar_Acceso(usuario, contraseña);
        }
    }
}
