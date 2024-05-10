using Modelo;
using Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class DProveedor
{
    // Mostrar Proveedores
    public static DataTable Mostrar_Proveedor()
    {
        DataTable DtResultado = new DataTable("Mostrar_Proveedor");
        SqlConnection sqlCon = new SqlConnection(Connection.cn);

        try
        {

            SqlCommand sqlCmd = new SqlCommand()
            {
                Connection = sqlCon,
                CommandText = "Mostrar_Proveedor",
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

    //Buscar proveedores
    public static DataTable Buscar_Proveedor(string dato)
    {

        DataTable DtResultado = new DataTable("Buscar_Proveedor");

        SqlConnection sqlCon = new SqlConnection();

        try
        {
            sqlCon.ConnectionString = Connection.cn;

            SqlCommand sqlCmd = new SqlCommand
            {
                Connection = sqlCon,
                CommandText = "Buscar_Proveedor",
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

    public static void Cambiar_EstadoProveedor(int Id)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Cambiar_EstadoProveedor"
            };

            SqlParameter parIdProveedor = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                Value = Id,
                ParameterName = "IdProveedor"
            };

            comando.Parameters.Add(parIdProveedor);

            comando.ExecuteNonQuery();
        }
        catch (Exception e)
        {
        }
    }
    public static void Insertar_Proveedor(Proveedor t)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandText = "Insertar_Proveedor",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter ParNombreCompania = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "NombreCompañia",
                Value = t.NombreCompañia
            };

            SqlParameter ParNoRuc = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "RUC",
                Value = t.RUC
            };

            SqlParameter ParTelefono = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "Telefono",
                Value = t.Telefono
            };

            SqlParameter ParCorreo = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "Correo",
                Value = t.Correo
            };

            SqlParameter ParCredito = new SqlParameter()
            {
                SqlDbType = SqlDbType.Money,
                Size = 50,
                ParameterName = "Credito",
                Value = t.Credito
            };

            comando.Parameters.Add(ParNombreCompania);
            comando.Parameters.Add(ParNoRuc);
            comando.Parameters.Add(ParTelefono);
            comando.Parameters.Add(ParCorreo);
            comando.Parameters.Add(ParCredito);

            comando.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            MessageBox.Show("Error: " + e.Message, "Ingresar Proveedor",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static void Actualizar_Proveedor(int id, Proveedor t)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandText = "Actualizar_Proveedor",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter ParIdProveedor = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "IdProveedor",
                Value = id
            };

            SqlParameter ParNombreCompania = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "NombreCompañia",
                Value = t.NombreCompañia
            };

            SqlParameter ParNoRuc = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "Ruc",
                Value = t.RUC
            };

            SqlParameter ParTelefono = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "Telefono",
                Value = t.Telefono
            };

            SqlParameter ParCorreo = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "Correo",
                Value = t.Correo
            };

            SqlParameter ParCredito = new SqlParameter()
            {
                SqlDbType = SqlDbType.Money,
                Size = 50,
                ParameterName = "Credito",
                Value = t.Credito
            };


            comando.Parameters.Add(ParIdProveedor);
            comando.Parameters.Add(ParNombreCompania);
            comando.Parameters.Add(ParNoRuc);
            comando.Parameters.Add(ParTelefono);
            comando.Parameters.Add(ParCorreo);
            comando.Parameters.Add(ParCredito);

            comando.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            MessageBox.Show("Error: " + e.Message, "Actualizar Proveedor",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}