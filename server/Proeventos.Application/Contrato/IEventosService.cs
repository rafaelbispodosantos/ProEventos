using System.Threading.Tasks;
using ProEventos.Application.Dtos;


namespace Proeventos.Application.Contratos
{
    public interface IEventosService
    {
        Task<EventoDto> AddEventos(EventoDto model); 
        Task<EventoDto> UpdateEvento(int eventoId, EventoDto model); 
        Task<bool> DeleteEvento(int eventoId); 

        
         Task<EventoDto[]> GetAllEventosAsync( bool incluePalestrantes = false);
         Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool incluePalestrantes = false);       
         Task<EventoDto> GetEventoByAsync(int EventoId , bool incluePalestrantes = false);

    }
}