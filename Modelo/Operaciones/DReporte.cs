using Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Operaciones
{
    public class DReporte
    {
        public static DataTable Reporte_Cuentas_por_pagar_proveedor()
        {
            DataTable DtResultado = new DataTable("Reporte_Cuentas_por_pagar_proveedor");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {

                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "Reporte_Cuentas_por_pagar_proveedor",
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

        public static DataTable Reporte_Devolucion_Compra_Por_Estado(string Estado)
        {
            DataTable DtResultado = new DataTable("Reporte_Devolucion_Compra_Por_Estado");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {

                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "Reporte_Devolucion_Compra_Por_Estado",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parEstado = new SqlParameter()
                {
                    ParameterName = "@Estado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 8,
                    Value = Estado

                };

                sqlCmd.Parameters.Add(parEstado);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;

        }

        public static DataTable Reporte_Devolucion_Venta_Por_Estado(string Estado)
        {
            DataTable DtResultado = new DataTable("Reporte_Devolucion_Venta_Por_Estado");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {

                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "Reporte_Devolucion_Venta_Por_Estado",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parEstado = new SqlParameter()
                {
                    ParameterName = "@Estado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 11,
                    Value = Estado

                };

                sqlCmd.Parameters.Add(parEstado);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;

        }

        public static DataTable Top10_Productos_Mas_Vendido(DateTime desde, DateTime hasta)
        {
            DataTable DtResultado = new DataTable("Top10_Productos_Mas_Vendido");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {

                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "Top10_Productos_Mas_Vendido",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parDesde = new SqlParameter()
                {
                    ParameterName = "@desde",
                    SqlDbType = SqlDbType.Date,
                    Value = desde

                };

                SqlParameter parHasta = new SqlParameter()
                {
                    ParameterName = "@hasta",
                    SqlDbType = SqlDbType.Date,
                    Value = hasta

                };

                sqlCmd.Parameters.Add(parDesde);
                sqlCmd.Parameters.Add(parHasta);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;

        }

        public static DataTable Reporte_Compra_entre_Fechas(DateTime desde, DateTime hasta)
        {
            DataTable DtResultado = new DataTable("Reporte_Compra_entre_Fechas");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {

                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "Reporte_Compra_entre_Fechas",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parDesde = new SqlParameter()
                {
                    ParameterName = "@desde",
                    SqlDbType = SqlDbType.Date,
                    Value = desde

                };

                SqlParameter parHasta = new SqlParameter()
                {
                    ParameterName = "@hasta",
                    SqlDbType = SqlDbType.Date,
                    Value = hasta

                };

                sqlCmd.Parameters.Add(parDesde);
                sqlCmd.Parameters.Add(parHasta);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;

        }

        public static DataTable Reporte_Productos_Mayor_Recaudacion(DateTime desde, DateTime hasta)
        {
            DataTable DtResultado = new DataTable("Reporte_Productos_Mayor_Recaudacion");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {

                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "Reporte_Productos_Mayor_Recaudacion",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parDesde = new SqlParameter()
                {
                    ParameterName = "@desde",
                    SqlDbType = SqlDbType.Date,
                    Value = desde

                };

                SqlParameter parHasta = new SqlParameter()
                {
                    ParameterName = "@hasta",
                    SqlDbType = SqlDbType.Date,
                    Value = hasta

                };

                sqlCmd.Parameters.Add(parDesde);
                sqlCmd.Parameters.Add(parHasta);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;

        }

        public static DataTable Reporte_Ingresos_Por_Cliente(DateTime desde, DateTime hasta)
        {
            DataTable DtResultado = new DataTable("Reporte_Ingresos_Por_Cliente");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {

                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "Reporte_Ingresos_Por_Cliente",
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
    }
}