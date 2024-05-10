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

public class DEmpleado
{
    public static DataTable Mostrar_Empleado()
    {
        DataTable DtResultado = new DataTable("Mostrar_Empleado");
        SqlConnection sqlCon = new SqlConnection(Connection.cn);

        try
        {

            SqlCommand sqlCmd = new SqlCommand()
            {
                Connection = sqlCon,
                CommandText = "Mostrar_Empleado",
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

    public static DataTable Buscar_Empleado(string dato)
    {

        DataTable DtResultado = new DataTable("Buscar_Empleado");

        SqlConnection sqlCon = new SqlConnection();

        try
        {
            sqlCon.ConnectionString = Connection.cn;

            SqlCommand sqlCmd = new SqlCommand
            {
                Connection = sqlCon,
                CommandText = "Buscar_Empleado",
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

    public static void Cambiar_EstadoEmpleado(int Id)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Cambiar_EstadoEmpleado"
            };

            SqlParameter parIdEmpleado = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                Value = Id,
                ParameterName = "IdEmpleado"
            };

            comando.Parameters.Add(parIdEmpleado);

            comando.ExecuteNonQuery();
        }
        catch (Exception e)
        {
        }
    }

    public static void Insertar_Empleado(Empleado t)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandText = "Insertar_Empleado",
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

            SqlParameter ParCargo = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "Cargo",
                Value = t.Cargo
            };

            SqlParameter ParSalario = new SqlParameter()
            {
                SqlDbType = SqlDbType.Decimal,
                ParameterName = "Salario",
                Value = t.Salario
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
            comando.Parameters.Add(ParCargo);
            comando.Parameters.Add(ParSalario);
            comando.Parameters.Add(ParDireccion);
            comando.Parameters.Add(ParTelefono);
            comando.Parameters.Add(ParCorreo);

            comando.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            MessageBox.Show("Error: " + e.Message, "Ingresar empleado",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static void Actualizar_Empleado(int id, Empleado t)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandText = "Actualizar_Empleado",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter ParIdEmpleado = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "IdEmpleado",
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

            SqlParameter ParCargo = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                ParameterName = "Cargo",
                Value = t.Cargo
            };

            SqlParameter ParSalario = new SqlParameter()
            {
                SqlDbType = SqlDbType.Decimal,
                ParameterName = "Salario",
                Value = t.Salario
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

            comando.Parameters.Add(ParIdEmpleado);
            comando.Parameters.Add(ParPrimerNombre);
            comando.Parameters.Add(ParSegundoNombre);
            comando.Parameters.Add(ParPrimerApellido);
            comando.Parameters.Add(ParSegundoApellido);
            comando.Parameters.Add(ParCargo);
            comando.Parameters.Add(ParSalario);
            comando.Parameters.Add(ParDireccion);
            comando.Parameters.Add(ParTelefono);
            comando.Parameters.Add(ParCorreo);

            comando.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            MessageBox.Show("Error: " + e.Message, "Actualizar empleado",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

