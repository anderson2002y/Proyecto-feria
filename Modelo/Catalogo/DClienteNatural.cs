using Poco;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class DClienteNatural
{ 

    public static DataTable Buscar_ClienteNatural(string dato)
    {

        DataTable DtResultado = new DataTable("Buscar_ClienteNatural");

        SqlConnection sqlCon = new SqlConnection();

        try
        {
            sqlCon.ConnectionString = Connection.cn;

            SqlCommand sqlCmd = new SqlCommand
            {
                Connection = sqlCon,
                CommandText = "Buscar_ClienteNatural",
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

    public static void Insertar_ClienteNatural(ClienteNatural t)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandText = "Insertar_ClienteNatural",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter ParPrimerNombre = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "PrimerNombre",
                Value = t.PrimerNombre
            };

            SqlParameter ParSegundoNombre = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "SegundoNombre",
                Value = t.SegundoNombre
            };

            SqlParameter ParPrimerApellido = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "PrimerApellido",
                Value = t.PrimerApellido
            };

            SqlParameter ParSegundoApellido = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "SegundoApellido",
                Value = t.SegundoApellido
            };

            SqlParameter ParDireccion = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "Direccion",
                Value = t.Direccion
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

            comando.Parameters.Add(ParPrimerNombre);
            comando.Parameters.Add(ParSegundoNombre);
            comando.Parameters.Add(ParPrimerApellido);
            comando.Parameters.Add(ParSegundoApellido);
            comando.Parameters.Add(ParDireccion);
            comando.Parameters.Add(ParTelefono);
            comando.Parameters.Add(ParCorreo);


            comando.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            MessageBox.Show("Error: " + e.Message, "Ingresar cliente juridico",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static void Actualizar_ClienteNatural(int id, ClienteNatural t)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandText = "Actualizar_ClienteNatural",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter ParIdClienteNatural = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "IdCliente",
                Value = id
            };

            SqlParameter ParPrimerNombre = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "PrimerNombre",
                Value = t.PrimerNombre
            };

            SqlParameter ParSegundoNombre = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "SegundoNombre",
                Value = t.SegundoNombre
            };

            SqlParameter ParPrimerApellido = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "PrimerApellido",
                Value = t.PrimerApellido
            };

            SqlParameter ParSegundoApellido = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "SegundoApellido",
                Value = t.SegundoApellido
            };

            SqlParameter ParDireccion = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "Direccion",
                Value = t.Direccion
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

            comando.Parameters.Add(ParIdClienteNatural);
            comando.Parameters.Add(ParPrimerNombre);
            comando.Parameters.Add(ParSegundoNombre);
            comando.Parameters.Add(ParPrimerApellido);
            comando.Parameters.Add(ParSegundoApellido);
            comando.Parameters.Add(ParDireccion);
            comando.Parameters.Add(ParTelefono);
            comando.Parameters.Add(ParCorreo);

            comando.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            MessageBox.Show("Error: " + e.Message, "Actualizar cliente natural",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}