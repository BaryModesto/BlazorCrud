using BlazorCrud.Data;
using BlazorCrud.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace BlazorCrud.Repositorio
{
    public class Repositorio : IRepositorio
    {
        AplicationDbContext bd;
        ILogger<Repositorio> log;
        public Repositorio(AplicationDbContext _bd,ILogger<Repositorio> _log)
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
            var result = await bd.Libro.AnyAsync(x=> x.titulo== _libro.titulo || x.descripcion == _libro.descripcion);
            if (_libro == null )
            {
                log.LogError($"El parametro _libro es null\n");
                return new Libro();
            }
            if (result)
            {                   
                log.LogError($"El libro que se quiere crear ya existe: {_libro} \n");
                return new Libro();
            }


            _libro.fecha_creacion = DateTime.Now;
            try
            {
               var realizado = await bd.Libro.AddAsync(_libro);

            }
            catch (OperationCanceledException ex)
            {
               log.LogError(ex.Message,ex);
            }
            try
            {
                await bd.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message, ex);
            }
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
