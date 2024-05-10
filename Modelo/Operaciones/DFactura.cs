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

public class DFactura
{
    public static DataTable Buscar_Factura(string dato)
    {

        DataTable DtResultado = new DataTable("Buscar_Factura");

        SqlConnection sqlCon = new SqlConnection();

        try
        {
            sqlCon.ConnectionString = Connection.cn;

            SqlCommand sqlCmd = new SqlCommand
            {
                Connection = sqlCon,
                CommandText = "Buscar_Factura",
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

    public static void Cambiar_EstadoFactura(int Id)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Cambiar_EstadoFactura"
            };

            SqlParameter parIdFactura = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                Value = Id,
                ParameterName = "IdFactura"
            };

            comando.Parameters.Add(parIdFactura);

            comando.ExecuteNonQuery();
        }
        catch (Exception e)
        {
        }
    }

    public static void Registrar_Factura(Factura t)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandText = "Registrar_Factura",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter ParCostoEnvio = new SqlParameter()
            {
                SqlDbType = SqlDbType.Money,
                ParameterName = "CostoEnvio",
                Value = t.CostoEnvio
            };

            SqlParameter ParEstado = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size=10,
                ParameterName = "Estado",
                Value = t.EstadoTransaccion
            };


            comando.Parameters.Add(ParCostoEnvio);
            comando.Parameters.Add(ParEstado);

            comando.ExecuteNonQuery();

        }
        catch (Exception e)
        {
        }
    }

    public static DataTable Ver_Factura(int IdFactura)
    {
        DataTable DtResultado = new DataTable("Ver_Factura");
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Ver_Factura"
            };

            SqlParameter parIdFactura = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                Value = IdFactura,
                ParameterName = "IdFactura"
            };

            comando.Parameters.Add(parIdFactura);

            SqlDataAdapter sqlDat = new SqlDataAdapter(comando);
            sqlDat.Fill(DtResultado);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message,"Mensaje de error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            DtResultado = null;
        }

        return DtResultado;
    }
}