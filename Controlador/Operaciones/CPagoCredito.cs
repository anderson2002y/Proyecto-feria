using Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Operaciones
{
    public class CPagoCredito
    {
        public static DataTable Visualizar_PagosCredito()
        {
            return DPagosCredito.Visualizar_PagosCredito();
        }

        public static DataTable Buscar_PagosCredito(string dato)
        {
            return DPagosCredito.Buscar_PagosCredito(dato);
        }

        public static void Registrar_PagoCredito(Pago p)
        {
            DPagosCredito.Registrar_PagoCredito(p);
        }
    }
}
