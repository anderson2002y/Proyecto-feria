using Poco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo.Operaciones
{
    public class Dventa
    {
        public static void Registrar_Venta(int IdCliente, int IdEmpleado)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection.cn);
                conexion.Open();

                SqlCommand comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandText = "Registrar_Venta",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdCliente = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "IdCliente",
                    Value = IdCliente
                };

                SqlParameter ParIdEmpleado = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "IdEmpleado",
                    Value = IdEmpleado
                };


                comando.Parameters.Add(ParIdCliente);
                comando.Parameters.Add(ParIdEmpleado);

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Ingresar Venta",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Registrar_DetVenta(ProductoVenta t)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection.cn);
                conexion.Open();

                SqlCommand comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandText = "Registrar_DetVenta",
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


                comando.Parameters.Add(ParIdProducto);
                comando.Parameters.Add(ParCantidad);
                comando.Parameters.Add(ParDescuento);

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Ingresar detalle de venta",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataTable Visualizar_Ventas()
        {
            DataTable DtResultado = new DataTable("Visualizar_Ventas");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {

                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "Visualizar_Ventas",
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

        public static DataTable Visualizar_VentasPeriodo(DateTime fechaInicial, DateTime fechaFinal)
        {
            DataTable DtResultado = new DataTable("Visualizar_VentasPeriodo");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {

                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "Visualizar_VentasPeriodo",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parInicial = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Date,
                    SqlValue = fechaInicial.Date,
                    ParameterName = "FechaInicial"
                };

                SqlParameter parFinal = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Date,
                    SqlValue = fechaFinal.Date,
                    ParameterName = "FechaFinal"
                };

                sqlCmd.Parameters.Add(parInicial);
                sqlCmd.Parameters.Add(parFinal);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        public static DataTable Visualizar_DetVentas(int id)
        {
            DataTable DtResultado = new DataTable("Det_Ventas");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {

                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "Visualizar_DetVenta",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parIdVenta = new SqlParameter()
                {
                    ParameterName = "IdVenta",
                    Value = id,
                    SqlDbType = SqlDbType.Int
                };

                sqlCmd.Parameters.Add(parIdVenta);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;
        }
    }
}
