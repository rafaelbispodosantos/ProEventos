using System.Threading.Tasks;
using ProEventos.Damain;

namespace Proeventos.Application.Contratos
{
    public interface IEventosService
    {
        Task<Evento> AddEventos(Evento model); 
        Task<Evento> UpdateEvento(int eventoId, Evento model); 
        Task<bool> DeleteEvento(int eventoId); 

        
         Task<Evento[]> GetAllEventosAsync( bool incluePalestrantes = false);
         Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluePalestrantes = false);       
         Task<Evento> GetEventoByAsync(int EventoId , bool incluePalestrantes = false);

    }
}