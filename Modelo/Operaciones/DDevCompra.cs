using Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;


public class DDevCompra
{
    public static DataTable Visualizar_DevCompras()
    {
        DataTable DtResultado = new DataTable("Visualizar_DevCompras");
        SqlConnection sqlCon = new SqlConnection(Connection.cn);

        try
        {

            SqlCommand sqlCmd = new SqlCommand()
            {
                Connection = sqlCon,
                CommandText = "Visualizar_DevCompras",
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

    public static DataTable Buscar_DevCompras(string dato)
    {

        DataTable DtResultado = new DataTable("Buscar_DevCompras");

        SqlConnection sqlCon = new SqlConnection();

        try
        {
            sqlCon.ConnectionString = Connection.cn;

            SqlCommand sqlCmd = new SqlCommand
            {
                Connection = sqlCon,
                CommandText = "Buscar_DevCompras",
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

    public static DataTable Buscar_DevCompras(DateTime fechaInicial, DateTime fechaFinal)
    {

        DataTable DtResultado = new DataTable("Visualizar_DevComprasPeriodo");

        SqlConnection sqlCon = new SqlConnection();

        try
        {
            sqlCon.ConnectionString = Connection.cn;
            sqlCon.Open();

            SqlCommand sqlCmd = new SqlCommand
            {
                Connection = sqlCon,
                CommandText = "Visualizar_DevComprasPeriodo",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter parFechaInicial = new SqlParameter()
            {
                ParameterName = "FechaInicial",
                SqlDbType = SqlDbType.Date,
                Value = fechaInicial.Date

            };

            SqlParameter parFechaFinal = new SqlParameter()
            {
                ParameterName = "FechaFinal",
                SqlDbType = SqlDbType.Date,
                Value = fechaFinal.Date
            };

            sqlCmd.Parameters.Add(parFechaInicial);
            sqlCmd.Parameters.Add(parFechaFinal);

            SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
            sqlDat.Fill(DtResultado);

        }
        catch (Exception e)
        {

            DtResultado = null;
            MessageBox.Show(e.Message);
        }

        return DtResultado;
    }

    public static void CambiarEstado_DevolucionCompra(int Id)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "CambiarEstado_DevolucionCompra"
            };

            SqlParameter parIdDevolucion = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                Value = Id,
                ParameterName = "IdDevolucion"
            };

            comando.Parameters.Add(parIdDevolucion);

            comando.ExecuteNonQuery();
        }
        catch (Exception e)
        {
        }
    }

    public static void Nueva_DevCompra(int IdDetalleCompra , DevolucionCompra t)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandText = "Nueva_DevCompra",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter ParIdDetalleCompra = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "IdDetalleCompra",
                Value = IdDetalleCompra
            };

            SqlParameter ParCantidad = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "Cantidad",
                Value = t.Cantidad
            };

            SqlParameter ParObservacion = new SqlParameter()
            {
                SqlDbType = SqlDbType.NVarChar,
                Size = 60,
                ParameterName = "Observacion",
                Value = t.Observacion
            };

            SqlParameter ParEstado = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 8,
                ParameterName = "Estado",
                Value = t.Estado 
            };

            comando.Parameters.Add(ParIdDetalleCompra);
            comando.Parameters.Add(ParCantidad);
            comando.Parameters.Add(ParObservacion);
            comando.Parameters.Add(ParEstado);

            comando.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            MessageBox.Show("Error: " + e.Message, "Devolucion compra",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static int Buscar_DevProductoCompra(int idCompra, int idProducto)
    {
        SqlConnection connection;
        int idDetalleProducto;

        try
        {
            connection = new SqlConnection(Connection.cn);
            connection.Open();
            SqlCommand comando = new SqlCommand()
            {
                Connection = connection,
                CommandText = "Buscar_DevProductoCompra",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter parIdCompra = new SqlParameter()
            {
                ParameterName = "IdCompra",
                SqlDbType = SqlDbType.Int,
                Value = idCompra
            };

            SqlParameter parIdProducto = new SqlParameter()
            {
                ParameterName = "IdProducto",
                SqlDbType = SqlDbType.Int,
                Value = idProducto
            };

            comando.Parameters.Add(parIdCompra);
            comando.Parameters.Add(parIdProducto);

            if (comando.ExecuteScalar() == null)
            {
                MessageBox.Show("Error interno de datos");
                return 0;
            }

            idDetalleProducto = int.Parse(comando.ExecuteScalar().ToString());

        }
        catch (SqlException sqlE)
        {
            MessageBox.Show(sqlE.Message);
            idDetalleProducto = 0;
        }

        return idDetalleProducto;
    }


}