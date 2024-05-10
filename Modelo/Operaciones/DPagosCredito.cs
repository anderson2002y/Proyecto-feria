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

public class DPagosCredito
{
    public static DataTable Visualizar_PagosCredito()
    {
        DataTable DtResultado = new DataTable("Visualizar_PagosCredito");
        SqlConnection sqlCon = new SqlConnection(Connection.cn);

        try
        {

            SqlCommand sqlCmd = new SqlCommand()
            {
                Connection = sqlCon,
                CommandText = "Visualizar_PagosCredito",
                CommandType = CommandType.StoredProcedure
            };
            sqlCon.Open();

            SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
            sqlDat.Fill(DtResultado);

        }
        catch (Exception)
        {
            DtResultado = null;
        }

        return DtResultado;
    }

    public static DataTable Buscar_PagosCredito(string dato)
    {

        DataTable DtResultado = new DataTable("Buscar_PagosCredito");

        SqlConnection sqlCon = new SqlConnection();

        try
        {
            sqlCon.ConnectionString = Connection.cn;
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand
            {
                Connection = sqlCon,
                CommandText = "Buscar_PagosCredito",
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

    public static void Registrar_PagoCredito(Pago p)
    {
        SqlConnection connection = new SqlConnection(Connection.cn);

        try
        {
            connection.Open();
            SqlCommand comando = new SqlCommand()
            {
                CommandText = "Registrar_PagoCredito",
                Connection = connection,
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter parIdCompra = new SqlParameter()
            {
                ParameterName = "IdCompra",
                Value = p.Id,
                SqlDbType = SqlDbType.Int
            };

            SqlParameter parFecha = new SqlParameter()
            {
                ParameterName = "Fecha",
                Value = p.Fecha,
                SqlDbType = SqlDbType.Date
            };

            SqlParameter parMonto = new SqlParameter()
            {
                ParameterName = "Monto",
                Value = p.Monto,
                SqlDbType = SqlDbType.Money
            };

            comando.Parameters.Add(parIdCompra);
            comando.Parameters.Add(parFecha);
            comando.Parameters.Add(parMonto);

            comando.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message,"Error al insertar pago",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}