using Modelo;
using Modelo.Catalogo;
using Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Catalogo
{
    public class CCliente
    {
        public DataTable Visualizar()
        {
            return DCliente.Mostrar_Cliente();
        }

        public DataTable Buscar(string dato)
        {
            return DCliente.Buscar_Cliente(dato);
        }

        public static DataTable BuscarStatic(string dato)
        {
            return DCliente.Buscar_Cliente(dato);
        }

        public void AgregarCN(ClienteNatural cn)
        {
            DClienteNatural.Insertar_ClienteNatural(cn);
        }

        public void AgregarCJ(ClienteJuridico cj)
        {
            DClienteJuridico.Insertar_ClienteJuridico(cj);
        }

        public void ActualizarCN(int id, ClienteNatural cn)
        {
            DClienteNatural.Actualizar_ClienteNatural(id, cn);
        }

        public void ActualizarCJ(int id, ClienteJuridico cj)
        {
            DClienteJuridico.Actualizar_ClienteJuridico(id, cj);
        }

        public void CambiarEstado(int id)
        {
            DCliente.Cambiar_EstadoCliete(id);
        }

        public static DataTable Buscar_Cliente(int idCliente)
        {
            return DCliente.Buscar_Cliente(idCliente);
        }
    }
}