using SistemaFerretero.MenusEnum;
using SistemaFerretero.Forms.Menus;
using SistemaFerretero.Forms.Menus.Catalogo;
using SistemaFerretero.Forms.Menus.Operaciones;
using SistemaFerretero.Forms.Menus.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaFerretero.Forms.Menus.Reportes;
using Poco;

namespace SistemaFerretero.Forms.Fabrica
{
    public class FabricaForms
    {
        public static Form ObtenerFormulario(MnForm menu, Enum nombreForm,Usuario u)
        {
            switch (menu)
            {
                case MnForm.Catalogos:
                    return new FrmCatalogModel(nombreForm,u);

                case MnForm.Operaciones:
                    switch (nombreForm)
                    {
                        case EnumOperacion.Compras:
                            return new FrmCompras(u);
                        case EnumOperacion.Ventas:
                            return new FrmVentas(u);
                        case EnumOperacion.Dev_Ventas:
                            return new FrmDevolucionesVentas(u);
                        case EnumOperacion.Dev_Compras:
                            return new FrmDevolucionesCompra(u);
                    }
                    break;
                case MnForm.Reportes:
                    switch (nombreForm)
                    {
                        case EnumReporte.Compras:
                            return new Frm_Compras();
                        case EnumReporte.Ventas:
                            return new Frm_Ventas();

                        case EnumReporte.Dev_Compras:
                            return new FrmDevolucion_Compra();

                        case EnumReporte.Dev_Ventas:
                            return new FrmDevolucion_Venta();

                        case EnumReporte.Frecuencia_Clientes:
                            return new Frm_Clientes_Frecuencia(); 

                        case EnumReporte.Clientes_Recaudacion:
                            return new Frm_Ingresos_Por_Clientes();

                        case EnumReporte.Productos_Recaudacion:
                            return new Frm_Productos_Mayor_Recaudacion();

                        case EnumReporte.Productos_Vendidos:
                            return new Frm_Top_10_Productos_Vendidos();

                        case EnumReporte.Cuentas_Pagar:
                            return new FrmCuentas_por_pagar_proveedor();
                    }
                    break;

                case MnForm.Seguridad:
                    switch (nombreForm)
                    {
                        case EnumSeguridad.Usuarios:
                            return new FrmCatalogModel(EnumCatalogo.Usuarios, u);

                        case EnumSeguridad.Roles:
                            return new FrmGestionRoles();
                    }
                    break;
            }

            return new FrmHome();
        }
    }
}
