using Modelo.Operaciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Operaciones
{
    public class CDepartamento
    {
        public static DataTable Mostrar_Departamentos()
        {
            return DDepartamento.Mostrar_Departamento();
        }
    }
}
