using BlazorCrud.Modelo;

namespace BlazorCrud.Repositorio
{
    public interface IRepositorio
    {
        public Task<List<Libro>> Get_Libros();
        public Task<Libro> Get_Libro(int _id);
        public Task<Libro> Crear_Libro(Libro _libro);
        public Task<Libro> Actualizar_Libro(int _id,Libro _libro);
        public Task Borrar_Libro(int _id);
    }
}
 