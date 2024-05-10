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
    public class DDepartamento
    {
        public static DataTable Mostrar_Departamento()
        {
            DataTable DtResultado = new DataTable("Mostrar_Departamento");
            SqlConnection sqlCon = new SqlConnection(Connection.cn);

            try
            {

                SqlCommand sqlCmd = new SqlCommand()
                {
                    Connection = sqlCon,
                    CommandText = "Mostrar_Departamentos",
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
