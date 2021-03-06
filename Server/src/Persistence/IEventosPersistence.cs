using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public interface IEventosPersistence
    {
        //GERAL 
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         void DeleteRange<T>(T[] entity) where T: class;
         Task<bool> SaveChangesAsync();

         // EVENTOS
         Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
         Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
         Task<Evento> GetAllEventosByIdAsync(int EventoId, bool includePalestrantes);
         
         // PALESTRANTES
         
         Task<Palestrante[]> GetAllPalestrantesByNameAsync(string nome, bool includeEventos);
         Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
         Task<Palestrante> GetAllPalestrantesByIdAsync(int PalestranteId, bool includeEventos);
    }
}