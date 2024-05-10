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

public class DDevVenta
{
    public static DataTable Visualizar_DevVentas()
    {
        DataTable DtResultado = new DataTable("Visualizar_DevVentas");
        SqlConnection sqlCon = new SqlConnection(Connection.cn);

        try
        {

            SqlCommand sqlCmd = new SqlCommand()
            {
                Connection = sqlCon,
                CommandText = "Visualizar_DevVentas",
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

    public static DataTable Buscar_DevVentas(string dato)
    {

        DataTable DtResultado = new DataTable("Buscar_DevVentas");

        SqlConnection sqlCon = new SqlConnection();

        try
        {
            sqlCon.ConnectionString = Connection.cn;

            SqlCommand sqlCmd = new SqlCommand
            {
                Connection = sqlCon,
                CommandText = "Buscar_DevVentas",
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

    public static DataTable Buscar_DevVentas(DateTime FechaInicial, DateTime FechaFinal)
    {

        DataTable DtResultado = new DataTable("Buscar_DevVentas");

        SqlConnection sqlCon = new SqlConnection();

        try
        {
            sqlCon.ConnectionString = Connection.cn;

            SqlCommand sqlCmd = new SqlCommand
            {
                Connection = sqlCon,
                CommandText = "Visualizar_DevVentasPeriodo",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter parFechaInicial = new SqlParameter()
            {
                ParameterName = "FechaInicial",
                SqlDbType = SqlDbType.Date,
                Value = FechaInicial
            };

            SqlParameter parFechaFinal = new SqlParameter()
            {
                ParameterName = "FechaFinal",
                SqlDbType = SqlDbType.Date,
                Value = FechaFinal
            };

            sqlCmd.Parameters.Add(parFechaInicial);
            sqlCmd.Parameters.Add(parFechaFinal);

            SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
            sqlDat.Fill(DtResultado);

        }
        catch (Exception)
        {

            DtResultado = null;
        }

        return DtResultado;
    }

    public static void CambiarEstado_DevolucionVenta(int Id)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "CambiarEstado_DevolucionVenta"
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

    public static void Nueva_DevVenta(int IdFactura, DevolucionVenta t)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandText = "Nueva_DevVenta",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter ParIdFactura = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "IdFactura",
                Value = IdFactura
            };

            SqlParameter ParIdProducto= new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "IdProducto",
                Value = t.IdProducto
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
                Size = 11,
                ParameterName = "Estado",
                Value = t.Estado
            };

            comando.Parameters.Add(ParIdFactura);
            comando.Parameters.Add(ParIdProducto);
            comando.Parameters.Add(ParCantidad);
            comando.Parameters.Add(ParObservacion);
            comando.Parameters.Add(ParEstado);

            comando.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            MessageBox.Show("Error: " + e.Message, "Devolucion venta",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}