using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Validaciones
{
    public class FormatoString
    {
        public static double QuitarFormato(string cadena,params string[] formatos)
        {
            double valor = 0;

            foreach(string c in formatos)
            {
                cadena = cadena.Replace(c,"");
            }

            if (!double.TryParse(cadena, out valor))
            {
                valor = -1;
            }

            return valor;
        }

        public static double QuitarFormatoNic(string cadena)
        {
            double valor = 0;
            string[] formatos = { "C$", "," };

            foreach (string c in formatos)
            {
                cadena = cadena.Replace(c, "");
            }

            if (!double.TryParse(cadena, out valor))
            {
                valor = -1;
            }

            return valor;
        }

        public static string AgregarFormato(double numero)
        {
            NumberFormatInfo formato = new CultureInfo("es-NI").NumberFormat;
            formato.NumberGroupSeparator = ",";
            formato.NumberDecimalSeparator = ".";

            numero = Math.Round(numero,2);
            return numero.ToString("C",formato);
        }
    }
}
