using Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo.Catalogo
{
    public class DProducto
    {
        public static DataTable TablaProductos()
        {
            DataTable DtResultado = new DataTable("Producto");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {

                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "Mostrar_Productos",
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

        public static DataTable Buscar_Producto(string dato)
        {

            DataTable DtResultado = new DataTable("Buscar_Producto");

            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Connection.cn;

                SqlCommand sqlCmd = new SqlCommand
                {
                    Connection = sqlCon,
                    CommandText = "Buscar_Producto",
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

        public static void Cambiar_EstadoProducto(int Id)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection.cn);
                conexion.Open();

                SqlCommand comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Cambiar_EstadoProducto"
                };

                SqlParameter parIdProducto = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    Value = Id,
                    ParameterName = "IdProducto"
                };

                comando.Parameters.Add(parIdProducto);

                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
        }
        //Insertar producto
        public static void Insertar_Producto( Producto t)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection.cn);
                conexion.Open();

                SqlCommand comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandText = "Insertar_Producto",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParNombre = new SqlParameter()
                {
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    ParameterName = "Nombre",
                    Value = t.Nombre
                };

                SqlParameter ParMarca = new SqlParameter()
                {
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    ParameterName = "Marca",
                    Value = t.Marca
                };

                SqlParameter ParModelo = new SqlParameter()
                {
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    ParameterName = "Modelo",
                    Value = t.Modelo
                };

                SqlParameter ParPeso = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "Peso",
                    Value = t.Peso
                };

                SqlParameter ParContenido = new SqlParameter()
                {
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    ParameterName = "Contenido",
                    Value = t.Contenido
                };

                SqlParameter ParPrecio = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Money,
                    ParameterName = "Precio",
                    Value = t.Precio
                };

                SqlParameter ParUnidadesRequeridas = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    Size = 50,
                    ParameterName = "UnidadesRequeridas",
                    Value = t.UnidadesRequeridas
                };

                comando.Parameters.Add(ParNombre);
                comando.Parameters.Add(ParMarca);
                comando.Parameters.Add(ParModelo);
                comando.Parameters.Add(ParPeso);
                comando.Parameters.Add(ParContenido);
                comando.Parameters.Add(ParPrecio);
                comando.Parameters.Add(ParUnidadesRequeridas);

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Ingresar Producto",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Actualizar_Producto(int id, Producto t)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection.cn);
                conexion.Open();

                SqlCommand comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandText = "Actualizar_Producto",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdProducto = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "IdProducto",
                    Value = id
                };

                SqlParameter ParNombre = new SqlParameter()
                {
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    ParameterName = "Nombre",
                    Value = t.Nombre
                };

                SqlParameter ParMarca = new SqlParameter()
                {
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    ParameterName = "Marca",
                    Value = t.Marca
                };

                SqlParameter ParModelo = new SqlParameter()
                {
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    ParameterName = "Modelo",
                    Value = t.Modelo
                };

                SqlParameter ParPeso = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    Size = 50,
                    ParameterName = "Peso",
                    Value = t.Peso
                };

                SqlParameter ParContenido = new SqlParameter()
                {
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    ParameterName = "Medida",
                    Value = t.Contenido
                };

                SqlParameter ParPrecio = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Money,
                    ParameterName = "Precio",
                    Value = t.Precio
                };

                SqlParameter ParUnidadesRequeridas = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    Size = 50,
                    ParameterName = "UnidadesRequeridas",
                    Value = t.UnidadesRequeridas
                };

                comando.Parameters.Add(ParIdProducto);
                comando.Parameters.Add(ParNombre);
                comando.Parameters.Add(ParMarca);
                comando.Parameters.Add(ParModelo);
                comando.Parameters.Add(ParPeso);
                comando.Parameters.Add(ParContenido);
                comando.Parameters.Add(ParPrecio);
                comando.Parameters.Add(ParUnidadesRequeridas);

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Actualizar Producto",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}