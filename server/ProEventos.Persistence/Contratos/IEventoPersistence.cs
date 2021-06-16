using System.Threading.Tasks;
using ProEventos.Damain;
namespace ProEventos.Persistence.Contratos
{
    public interface IEventoPersistence
    {
       

         Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluePalestrantes = false);
         Task<Evento[]> GetAllEventosAsync( bool incluePalestrantes = false);
         Task<Evento> GetEventoByAsync(int eventoId , bool incluePalestrantes = false);

        

    }
}