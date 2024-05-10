using System;

namespace Poco
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Peso { get; set; }
        public string Contenido { get; set; }
        public double Costo { get; set; }
        public double  Precio { get; set; }
        public int UnidadesDisponibles { get; set; }
        public int UnidadesOrdenadas { get; set; }
        public int UnidadesRequeridas { get; set; }

        public object[] toArray(string precio)
        {
            object[] obj = new object[7];
            obj[0] = Id;
            obj[1] = Nombre + ' ' + Marca + ' ' + Modelo;
            obj[2] = precio;
            obj[3] = 1;
            obj[4] = 0;
            obj[5] = precio;
            obj[6] = UnidadesDisponibles;

            return obj;
        }

        public object[] toArray(string precio,string descuento)
        {
            object[] obj = new object[7];
            obj[0] = Id;
            obj[1] = Nombre + ' ' + Marca + ' ' + Modelo;
            obj[2] = precio;
            obj[3] = 1;
            obj[4] = descuento;
            obj[5] = precio;
            obj[6] = UnidadesDisponibles;

            return obj;
        }

        public object[] toArrayCompra(string precioCompra)
        {
            object[] obj = new object[12];
            obj[0] = Id;
            obj[1] = Nombre;
            obj[2] = Marca;
            obj[3] = Modelo;
            obj[4] = Peso;
            obj[5] = Contenido;
            obj[6] = precioCompra;
            obj[7] = 1;
            obj[8] = 0;
            obj[9] = 0;
            obj[10] = 0;
            obj[11] = 0;

            return obj;
        }
    }
}