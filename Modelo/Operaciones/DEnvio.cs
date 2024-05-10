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

public class DEnvio
{
    public static DataTable Visualizar_Envíos()
    {
        DataTable DtResultado = new DataTable("Visualizar_Envíos");
        SqlConnection sqlCon = new SqlConnection(Connection.cn);

        try
        {

            SqlCommand sqlCmd = new SqlCommand()
            {
                Connection = sqlCon,
                CommandText = "Visualizar_Envíos",
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

    public static DataTable Buscar_Envios(string dato)
    {

        DataTable DtResultado = new DataTable("Buscar_Envios");

        SqlConnection sqlCon = new SqlConnection();

        try
        {
            sqlCon.ConnectionString = Connection.cn;

            SqlCommand sqlCmd = new SqlCommand
            {
                Connection = sqlCon,
                CommandText = "Buscar_Envios",
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

    public static DataTable Buscar_Envios(int idFactura)
    {

        DataTable DtResultado = new DataTable("Buscar_Envios");

        SqlConnection sqlCon = new SqlConnection();

        try
        {
            sqlCon.ConnectionString = Connection.cn;

            SqlCommand sqlCmd = new SqlCommand
            {
                Connection = sqlCon,
                CommandText = "Buscar_Envio",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter parDato = new SqlParameter()
            {
                ParameterName = "IdFactura",
                SqlDbType = SqlDbType.Int,
                Value = idFactura
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

    public static void Registrar_Envio(Envio t)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandText = "Registrar_Envio",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter ParIdMunicipio = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "IdMunicipio",
                Value = t.IdMunicipio
            };

            SqlParameter ParDireccion = new SqlParameter()
            {
                SqlDbType = SqlDbType.NVarChar,
                Size = 60,
                ParameterName = "Direccion",
                Value = t.Direccion
            };

            comando.Parameters.Add(ParIdMunicipio);
            comando.Parameters.Add(ParDireccion);

            comando.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            MessageBox.Show("Error: " + e.Message, "Ingresar Envio",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}