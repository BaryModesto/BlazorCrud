using BlazorCrud.Data;
using BlazorCrud.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlazorCrud.Repositorio
{
    public class Repositorio : IRepositorio
    {
        AplicationDbContext bd;
        ILogger log;
        public Repositorio(AplicationDbContext _bd, ILogger _log)
        {
            bd = _bd;
            log = _log;
        }
        public async Task<Libro> Actualizar_Libro(int _id, Libro _libro)
        {
            
            var libro_act =await bd.Libro.FindAsync(_id);
            if (libro_act == null)
            {
                
            }
            libro_act.titulo = _libro.titulo;
            libro_act.autor= _libro.autor;
            libro_act.descripcion= _libro.descripcion;
            libro_act.precio= _libro.precio;
            libro_act.fecha_creacion = DateTime.Now;
            //---
            await bd.SaveChangesAsync();
            return libro_act;
        }

        public async Task Borrar_Libro(int _id)
        {
            var res = await bd.Libro.FindAsync(_id);
            if (res != null)
            {
                bd.Libro.Remove(res);
                await bd.SaveChangesAsync();
            }
        }

        public async Task<Libro> Crear_Libro(Libro _libro)
        {
            if (_libro == null)
            {
                return new Libro();
            }
            //var result = await bd.Libro.FindAsync(_libro);
            //if (result == null)
            //{
            //    return new Libro();
            //}
            _libro.fecha_creacion = DateTime.Now;
            try
            {
                await bd.Libro.AddAsync(_libro);

            }
            catch (OperationCanceledException ex)
            {
                ex.
            }
            await bd.SaveChangesAsync();
            return _libro;
        }

        public async Task<Libro> Get_Libro(int _id)
        {
            var res = await bd.Libro.FindAsync(_id);
            if (res != null)
            {
                return res;
            }
            //---
            return new Libro();
        }

        public Task<List<Libro>> Get_Libros()
        {            
            var lista_libros =  bd.Libro.ToListAsync();
            return lista_libros;
            
        }
    }
}
