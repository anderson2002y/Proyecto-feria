using Poco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Operaciones
{
    public  class DMunicipio
    {
        public static DataTable Mostrar_Municipio(int IdDepartamento)
        {
            DataTable DtResultado = new DataTable("Mostrar_Municipio");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {

                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "Mostrar_Municipios",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parameter = new SqlParameter()
                {
                    ParameterName = "IdDepartamento",
                    Value = IdDepartamento,
                    SqlDbType = SqlDbType.Int
                };

                sqlCmd.Parameters.Add(parameter);

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
