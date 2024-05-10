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
public class DCompra
{
    public static DataTable Visualizar_Compras()
    {
        DataTable DtResultado = new DataTable("Visualizar_Compras");
        SqlConnection sqlCon = new SqlConnection(Connection.cn);

        try
        {

            SqlCommand sqlCmd = new SqlCommand()
            {
                Connection = sqlCon,
                CommandText = "Visualizar_Compras",
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

    public static DataTable Visualizar_Compras(DateTime fechaInicial,DateTime fechaFinal)
    {
        DataTable DtResultado = new DataTable("Visualizar_Compras");
        SqlConnection sqlCon = new SqlConnection(Connection.cn);

        try
        {

            SqlCommand sqlCmd = new SqlCommand()
            {
                Connection = sqlCon,
                CommandText = "Visualizar_ComprasPeriodo",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter parFechaInicial = new SqlParameter()
            {
                ParameterName = "FechaInicial",
                Value = fechaInicial,
                SqlDbType = SqlDbType.Date
            };

            SqlParameter parFechaFinal = new SqlParameter()
            {
                ParameterName = "FechaFinal",
                Value = fechaFinal,
                SqlDbType = SqlDbType.Date
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

    public static void Cambiar_EstadoCompra(int Id)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Cambiar_EstadoCompra"
            };

            SqlParameter parIdCompra = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                Value = Id,
                ParameterName = "IdCompra"
            };

            comando.Parameters.Add(parIdCompra);

            comando.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

    }

    public static double Precio_UltimaCompra(int idProducto)
    {
        double precio = 0;
        SqlConnection connection;
        try
        {
            connection = new SqlConnection(Connection.cn);
            connection.Open();

            SqlCommand comando = new SqlCommand()
            {
                CommandText = "Precio_Producto",
                Connection = connection,
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter parIdProducto = new SqlParameter()
            {
                ParameterName = "IdProducto",
                SqlDbType = SqlDbType.Int,
                Value = idProducto
            };

            comando.Parameters.Add(parIdProducto);

            if (comando.ExecuteScalar() == null)
            {
                precio = 0;
                return precio;
            }
            
            precio = double.Parse(comando.ExecuteScalar().ToString());

        }
        catch (SqlException sqlE)
        {
            MessageBox.Show(sqlE.Message);
            precio = -1;
        }

        return precio;
    }
    public static DataTable Visualizar_DetCompra(int idCompra)
    {
        DataTable DtResultado = new DataTable("Visualizar_DetCompras");
        SqlConnection sqlCon = new SqlConnection(Connection.cn);

        try
        {

            SqlCommand sqlCmd = new SqlCommand()
            {
                Connection = sqlCon,
                CommandText = "Visualizar_DetCompras",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter parIdCompra = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                Value = idCompra,
                ParameterName = "IdCompra"
            };

            sqlCmd.Parameters.Add(parIdCompra);

            SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
            sqlDat.Fill(DtResultado);

        }
        catch (Exception)
        {
            DtResultado = null;
        }

        return DtResultado;
    }

    public static void RegistrarCompra( int IdProveedor, Compra t )
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandText = "Registrar_Compra",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter ParIdProveedor = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "IdProveedor",
                Value = IdProveedor
            };

            SqlParameter ParEstado = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                ParameterName = "Tipo",
                Value = t.EstadoTransaccion
            };

            SqlParameter ParNoFactura = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                ParameterName = "NoFactura",
                Value = t.NoFactura
            };

            SqlParameter parFecha = new SqlParameter()
            {
                SqlDbType = SqlDbType.Date,
                ParameterName = "Fecha",
                Value = t.Fecha
            };

            comando.Parameters.Add(ParIdProveedor);
            comando.Parameters.Add(ParEstado);
            comando.Parameters.Add(ParNoFactura);
            comando.Parameters.Add(parFecha);

            comando.ExecuteNonQuery();

        }
        catch (Exception e)
        {

            MessageBox.Show("Error: " + e.Message + e.Source, "Ingresar Compra",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static bool Validar_Factura(int idProveedor,string factura)
    {
        SqlConnection connection;
        bool flag = false;

        try
        {
            connection = new SqlConnection(Connection.cn);
            connection.Open();
            SqlCommand comando = new SqlCommand()
            {
                CommandText = "Validar_Factura",
                CommandType = CommandType.StoredProcedure,
                Connection = connection
            };

            SqlParameter parFactura = new SqlParameter()
            {
                ParameterName = "factura",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Value = factura
            };

            SqlParameter parIdProveedor = new SqlParameter()
            {
                ParameterName = "IdProveedor",
                SqlDbType = SqlDbType.Int,
                Value = idProveedor
            };

            comando.Parameters.Add(parIdProveedor);
            comando.Parameters.Add(parFactura);

            if (comando.ExecuteScalar().ToString() == "1")
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }catch(SqlException sqlE)
        {
            MessageBox.Show(sqlE.Message);
        }

        return flag;
    }

    public static void Registrar_DetCompra(ProductoCompra t)
    {
        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandText = "Registrar_DetCompra",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter ParIdProducto = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "IdProducto",
                Value = t.Id
            };

            SqlParameter ParCantidad = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "Cantidad",
                Value = t.Cantidad
            };

            SqlParameter ParDescuento = new SqlParameter()
            {
                SqlDbType = SqlDbType.Money,
                ParameterName = "Descuento",
                Value = t.Descuento
            };

            SqlParameter ParPrecio = new SqlParameter()
            {
                SqlDbType = SqlDbType.Money,
                ParameterName = "Precio",
                Value = t.Costo
            };


            comando.Parameters.Add(ParIdProducto);
            comando.Parameters.Add(ParCantidad);
            comando.Parameters.Add(ParDescuento);
            comando.Parameters.Add(ParPrecio);

            comando.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            MessageBox.Show("Error: " + e.Message, "Ingresar detalle de Compra",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static DataTable Buscar_Compra(string dato)
    {
        DataTable dt = new DataTable("Buscar_Compra");

        try
        {
            SqlConnection conexion = new SqlConnection(Connection.cn);
            conexion.Open();

            SqlCommand comando = new SqlCommand()
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Buscar_Compra"
            };

            SqlParameter parBuscar = new SqlParameter()
            {
                SqlDbType = SqlDbType.VarChar,
                Value = dato,
                ParameterName = "Buscar",
                Size = 100
            };

            comando.Parameters.Add(parBuscar);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);


        }
        catch (Exception e)
        {

        }

        return dt;
    }
}