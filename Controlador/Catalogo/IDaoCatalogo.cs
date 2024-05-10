using System.Data;

namespace Controlador.Catalogo
{
    public interface IDaoCatalogo<T>
    {
        void Agregar(T t);
        DataTable Visualizar();
        void Actualizar(int id, T t);
        void CambiarEstado(int id);
        DataTable Buscar(string busqueda);
    }
}