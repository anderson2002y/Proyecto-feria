using System;

namespace Poco

{
    public abstract class Transaccion
    {
        public int Id { get; set; }
        public double Descuento { get; set; }
        public string EstadoTransaccion { get; set; }
        public DateTime Fecha { get; set; }
        public string NoFactura { get; set; }
        public double Subtotal { get; set; }
        public double Total { get; set; }
    }
}
