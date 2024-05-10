using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo.Operaciones
{
    public class DSeguridad
    {
        public static DataTable Validar_Acceso(string username, string contraseña)
        {
            DataTable DtResultado = new DataTable("Iniciar_Sesión");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Connection.cn;
                sqlCon.Open();


                SqlCommand sqlCmd = new SqlCommand
                {
                    Connection = sqlCon,
                    CommandText = "Validar_Acceso",
                    CommandType = CommandType.StoredProcedure
                };

                //Cargando los parametros del procedimiento almacenado
                SqlParameter parUser = new SqlParameter
                {
                    ParameterName = "@usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 60,
                    Value = username
                };

                SqlParameter parContraseña = new SqlParameter
                {
                    ParameterName = "@contraseña",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = contraseña
                };
                sqlCmd.Parameters.Add(parUser);
                sqlCmd.Parameters.Add(parContraseña);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public static DataTable Validar_Creacion_Usuario(string username)
        {
            DataTable DtResultado = new DataTable("Validar_Creacion");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Connection.cn;
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand
                {
                    Connection = sqlCon,
                    CommandText = "Validar_Creacion_Usuario",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parUser = new SqlParameter
                {
                    ParameterName = "@usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 60,
                    Value = username
                };
                sqlCmd.Parameters.Add(parUser);


                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public static void Crear_Modulo( string Modulo)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection.cn);
                conexion.Open();

                SqlCommand comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandText = "CrearModulo",
                    CommandType = CommandType.StoredProcedure
                };


                SqlParameter ParModulo = new SqlParameter()
                {
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    ParameterName = "@Modulo",
                    Value = Modulo
                };


                comando.Parameters.Add(ParModulo);


                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Crear Modulo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public static void Crear_Rol(string Rol)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection.cn);
                conexion.Open();

                SqlCommand comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandText = "CrearRol",
                    CommandType = CommandType.StoredProcedure
                };


                SqlParameter ParRol = new SqlParameter()
                {
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    ParameterName = "@Rol",
                    Value = Rol
                };


                comando.Parameters.Add(ParRol);


                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Crear Rol",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public static void Crear_Operacion(int IdModulo ,string Operacion)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection.cn);
                conexion.Open();

                SqlCommand comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandText = "CrearRol",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdModulo = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@IdModulo",
                    Value = IdModulo
                };

                SqlParameter ParOperacion = new SqlParameter()
                {
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    ParameterName = "@Rol",
                    Value = Operacion
                };


                comando.Parameters.Add(ParOperacion);
                comando.Parameters.Add(ParIdModulo);



                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Crear Operación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public static void Asignar_Operacion(int IdOperacion, int IdRol)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection.cn);
                conexion.Open();

                SqlCommand comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandText = "CrearRol",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdRol = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@IdRol",
                    Value = IdRol
                };

                SqlParameter ParIdOperacion = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@IdOperacion",
                    Value = IdOperacion
                };


                comando.Parameters.Add(ParIdRol);
                comando.Parameters.Add(ParIdOperacion);



                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Asignar Operación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public static DataTable Acceso_Rol(int IdUsuario,int idModulo)
        {

            DataTable DtResultado = new DataTable("Aceso Operaciones");

            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Connection.cn;
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand
                {
                    Connection = sqlCon,
                    CommandText = "AccesoRol",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parIdUsuario = new SqlParameter()
                {
                    ParameterName = "@IdUsuario",
                    SqlDbType = SqlDbType.Int,
                    Value = IdUsuario
                };

                SqlParameter parIdModulo = new SqlParameter()
                {
                    ParameterName = "IdModulo",
                    SqlDbType = SqlDbType.Int,
                    Value = idModulo
                };

                sqlCmd.Parameters.Add(parIdUsuario);
                sqlCmd.Parameters.Add(parIdModulo);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {

                DtResultado = null;
            }

            return DtResultado;
        }


        public static DataTable Acceso_Rol_Modulo(int IdUsuario)
        {

            DataTable DtResultado = new DataTable("Aceso Modulo");

            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Connection.cn;
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand
                {
                    Connection = sqlCon,
                    CommandText = "AccesoRolModulo",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parIdUsuario = new SqlParameter()
                {
                    ParameterName = "@IdUsuario",
                    SqlDbType = SqlDbType.Int,
                    Value = IdUsuario
                };

                sqlCmd.Parameters.Add(parIdUsuario);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtResultado);
            }
            catch (SqlException sqlE)
            {
                MessageBox.Show(sqlE.Message);
                DtResultado = null;
            }

            return DtResultado;
        }


        public static DataTable Mostrar_Modulo()
        {
            DataTable DtResultado = new DataTable("Mostrar_Modulos");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "MostrarModulos",
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (SqlException sqlE)
            {
                DtResultado = null;
                MessageBox.Show(sqlE.Message);
            }

            return DtResultado;
        }
        public static DataTable Mostrar_Operaciones(int IdModulo)
        {
            DataTable DtResultado = new DataTable("Mostrar_Operaciones");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "MostrarOperaciones",
                    CommandType = CommandType.StoredProcedure
                };


                SqlParameter parIdModulo = new SqlParameter()
                {
                    ParameterName = "@IdModulo",
                    SqlDbType = SqlDbType.Int,
                    Value = IdModulo

                };

                sqlCmd.Parameters.Add(parIdModulo);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtResultado);



            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        public static DataTable Mostrar_Operaciones_Asignadas()
        {
            DataTable DtResultado = new DataTable("Mostrar_Operaciones_Asignadas");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {
                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "MostrarOperacionesAsignadas",
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        public static DataTable Mostrar_Roles()
        {
            DataTable DtResultado = new DataTable("Mostrar_Roles");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "MostrarRoles",
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

    }
}
