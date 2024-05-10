using Modelo.Operaciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Operaciones
{
    public class CMunicipio
    {
        public static DataTable Mostrar_Municipio(int idD)
        {
            return DMunicipio.Mostrar_Municipio(idD);
        }
    }
}
