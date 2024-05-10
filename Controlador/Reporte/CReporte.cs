using Modelo.Operaciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Reporte
{
    public class CReporte
    {
        public static DataTable Reporte_Cliente_Ingreso()
        {
            return DReporte.Reporte_Ingresos_Por_Cliente();
        }
    }
}
