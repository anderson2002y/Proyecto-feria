namespace Poco
{
	public class DevolucionVenta : Devolucion
	{
		public double Monto { get; set; }
		public string Estado{ get; set; }
		public int IdProducto { get; set; }
	}
}
