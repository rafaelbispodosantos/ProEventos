using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Damain;
using ProEventos.Persistence.Contexto;

namespace ProEventos.Persistence.Contratos
{
  public class EventoPersistence : IEventoPersistence
  {
    private readonly ProEventosContext _context;
    public EventoPersistence(ProEventosContext _context)
    {
      this._context = _context;
      //this._context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    }
    
    public async Task<Evento[]> GetAllEventosAsync( bool includePalestrantes = false)
    {
      IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes)
      .Include(e => e.RedesSociais);
      
      if (includePalestrantes)
      {
        query = query.Include(e => e.PalestrantesEventos)
        .ThenInclude( pe => pe.Palestrante);
      }

      query = query.AsNoTracking().OrderBy(e => e.Id);

      return await query.ToArrayAsync();
    }

    public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
    {
      IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes)
      .Include(e => e.RedesSociais);
      
      if (includePalestrantes)
      {
        query = query.Include(e => e.PalestrantesEventos)
        .ThenInclude( pe => pe.Palestrante);
      }

      query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

      return await query.ToArrayAsync();
    }
    public async Task<Evento> GetEventoByAsync(int eventoId, bool includePalestrantes)
    {
       IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes)
      .Include(e => e.RedesSociais);
      
      if (includePalestrantes)
      {
        query = query.Include(e => e.PalestrantesEventos)
        .ThenInclude( pe => pe.Palestrante);
      }

      query = query.AsNoTracking().OrderBy(e => e.Id)
      .Where(e => e.Id == eventoId);

      return await query.FirstOrDefaultAsync();
    }

    


  }
}