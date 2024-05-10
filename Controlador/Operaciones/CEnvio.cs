using Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Operaciones
{
    public class CEnvio
    {
        public static DataTable Visualizar_Envios()
        {
            return DEnvio.Visualizar_Envíos();
        }

        public static DataTable Buscar_Envios(string dato)
        {
            return DEnvio.Buscar_Envios(dato);
        }

        public static void Registrar_Envio(Envio e)
        {
            DEnvio.Registrar_Envio(e);
        }

        public static DataTable Buscar_Envio(int idEnvio)
        {
            return DEnvio.Buscar_Envios(idEnvio);
        }
    }
}
