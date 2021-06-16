using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Damain;
using ProEventos.Persistence.Contexto;

namespace ProEventos.Persistence.Contratos
{
  public class PalestrantePersistence : IPalestrantePersistence
  {
    private readonly ProEventosContext _context;
    public PalestrantePersistence(ProEventosContext _context)
    {
      this._context = _context;

    }   


        public async Task<Palestrante[]> GetAllPalestrantesAsync( bool includeEventos = false)
    {
      IQueryable<Palestrante> query = _context.Palestrantes.Include(e => e.RedesSociais);
      
      if (includeEventos)
      {
        query = query
        .Include(p => p.PalestrantesEventos)
        .ThenInclude( pe => pe.Evento);
      }

      query = query.AsNoTracking().OrderBy(p => p.Id);

      return await query.ToArrayAsync();
    }

    public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
    {
      IQueryable<Palestrante> query = _context.Palestrantes.Include(e => e.RedesSociais);
      
      if (includeEventos)
      {
        query = query
        .Include(p => p.PalestrantesEventos)
        .ThenInclude( pe => pe.Evento);
      }

      query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

      return await query.ToArrayAsync();
    }



    public async Task<Palestrante> GetPalestranteByAsync(int palestranteId, bool includeEventos)
    {
      IQueryable<Palestrante> query = _context.Palestrantes.Include(e => e.RedesSociais);
      
      if (includeEventos)
      {
        query = query
        .Include(p => p.PalestrantesEventos)
        .ThenInclude( pe => pe.Evento);
      }

      query = query.AsNoTracking().OrderBy(p => p.Id)
      .Where(p => p.Id == palestranteId);

      return await query.FirstOrDefaultAsync();
    }


  }
}