using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class EventosPersistence : IEventosPersistence
    {
        private readonly DataContext _ctx;
        public EventosPersistence(DataContext context)
        {
            _ctx = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _ctx.Add(entity);

        }

        public void Update<T>(T entity) where T : class
        {
           _ctx.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _ctx.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
           _ctx.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {

            return (await _ctx.SaveChangesAsync()) > 0;
        
        }


        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
           IQueryable<Evento> query = _ctx.Eventos
           .Include(e => e.Lotes)
           .Include(e => e.RedesSociais);

           if(includePalestrantes){
               query = query.Include(e => e.PalestrantesEventos)
               .ThenInclude(pe => pe.Palestrante);
           }

            query = query.OrderBy(e => e.EventoId);

            return await query.ToArrayAsync();

        }

        public async Task<Evento> GetAllEventosByIdAsync(int EventoId, bool includePalestrantes)
        {
              IQueryable<Evento> query = _ctx.Eventos
           .Include(e => e.Lotes)
           .Include(e => e.RedesSociais);

           if(includePalestrantes){
               query = query.Include(e => e.PalestrantesEventos)
               .ThenInclude(pe => pe.Palestrante);
           }

            query = query.OrderBy(e => e.EventoId)
                .Where(e => e.EventoId == EventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
                 IQueryable<Evento> query = _ctx.Eventos
           .Include(e => e.Lotes)
           .Include(e => e.RedesSociais);

           if(includePalestrantes){
               query = query.Include(e => e.PalestrantesEventos)
               .ThenInclude(pe => pe.Palestrante);
           }

            query = query.OrderBy(e => e.EventoId)
                .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Palestrante> GetAllPalestrantesByIdAsync(int PalestranteId, bool includeEventos)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNameAsync(string nome, bool includeEventos)
        {
            throw new System.NotImplementedException();
        }


    }
}