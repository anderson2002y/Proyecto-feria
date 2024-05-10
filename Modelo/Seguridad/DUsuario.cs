using Poco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo.Operaciones
{
    public class DUsuario
    {
        public static DataTable Vizualizar_Usuarios()
        {
            DataTable DtResultado = new DataTable("Vizualizar_Usuarios");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {

                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "Visualizar_Usuarios",
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

        public static DataTable Buscar_Usuarios(string dato)
        {

            DataTable DtResultado = new DataTable("Buscar_Usuarios");

            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Connection.cn;

                SqlCommand sqlCmd = new SqlCommand
                {
                    Connection = sqlCon,
                    CommandText = "Buscar_Usuarios",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parDato = new SqlParameter()
                {
                    ParameterName = "@Buscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = dato

                };

                sqlCmd.Parameters.Add(parDato);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {

                DtResultado = null;
            }

            return DtResultado;
        }

        public static void Cambiar_Estado_Usuario(int Id)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection.cn);
                conexion.Open();

                SqlCommand comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Cambiar_Estado_Usuario"
                };

                SqlParameter parIdUsuario = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    Value = Id,
                    ParameterName = "IdUsuario"
                };

                comando.Parameters.Add(parIdUsuario);

                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Cambiar Estado",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Actualizar_Usuario(int idUsuario, string rol)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection.cn);
                conexion.Open();

                SqlCommand comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandText = "Actualizar_Usuario",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdUsuario = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    Size = 50,
                    ParameterName = "@IdUsuario",
                    Value = idUsuario
                };

                SqlParameter ParRol = new SqlParameter()
                {
                    SqlDbType = SqlDbType.VarChar,
                    Size = 30,
                    ParameterName = "@rol",
                    Value = rol
                };


                comando.Parameters.Add(ParIdUsuario);
                comando.Parameters.Add(ParRol);


                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Actualzar Usuario",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public static DataTable Insertar_Usuario( int IdEmpleado,string contraseña,int rol)
        {

            DataTable DtResultado = new DataTable("Actualizar_Usuario");
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = Connection.cn;
                conexion.Open();

                SqlCommand comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandText = "Insertar_Usuario",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdEmpleado = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@IdEmpleado",
                    Value = IdEmpleado
                };

                SqlParameter ParContra = new SqlParameter()
                {
                    SqlDbType = SqlDbType.VarChar,
                    Size=30,
                    ParameterName= "@Contraseña",
                    Value = contraseña
                };


                SqlParameter ParRol = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@IdRol",
                    Value = rol
                };


                comando.Parameters.Add(ParIdEmpleado);
                comando.Parameters.Add(ParContra);
                comando.Parameters.Add(ParRol);

                SqlDataAdapter sqlDat = new SqlDataAdapter(comando);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        public static DataTable Cambiar_Contraseña_Usuario( int id, string userName ,string nueva, string contraseña)
        {
            DataTable DtResultado = new DataTable("Cambiar_Contraseña_Usuario");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Connection.cn;

                SqlCommand comando = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "Cambiar_Contraseña_Usuario",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdUsuario = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@IdUsuario",
                    Value = id
                };
               

                SqlParameter ParUsarname = new SqlParameter()
                {
                    SqlDbType = SqlDbType.VarChar,
                    Size = 30,
                    ParameterName = "@Username",
                    Value = userName
                };

                SqlParameter ParContraseña = new SqlParameter()
                {
                    SqlDbType = SqlDbType.VarChar,
                    Size = 30,
                    ParameterName = "@Contraseña",
                        Value = contraseña
                };

                SqlParameter ParNuevaContraseña = new SqlParameter()
                {
                    SqlDbType = SqlDbType.VarChar,
                    Size = 30,
                    ParameterName = "@nueva",
                    Value = nueva
                };


                comando.Parameters.Add(ParIdUsuario);
                comando.Parameters.Add(ParUsarname);
                comando.Parameters.Add(ParContraseña);
                comando.Parameters.Add(ParNuevaContraseña);


                SqlDataAdapter sqlDat = new SqlDataAdapter(comando);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception )
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        public static DataTable Validar_Acceso(string username, string contraseña)
        {
            DataTable DtResultado = new DataTable("Iniciar_Sesión");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Connection.cn;

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

    }
    
}
