using System;
using System.Threading.Tasks;
using Proeventos.Application.Contratos;
using ProEventos.Damain;
using ProEventos.Persistence.Contratos;

namespace Proeventos.Application
{
  public class EventoService : IEventosService
  {
    private readonly IGeralPersistence _geralPersistence;
    private readonly IEventoPersistence _eventoPersistence;
    public EventoService(IGeralPersistence geralPersistence, IEventoPersistence eventoPersistence)
    {
      _eventoPersistence = eventoPersistence;
      _geralPersistence = geralPersistence;

    }
    public async Task<Evento> AddEventos(Evento model)
    {
      try
{
    _geralPersistence.Add<Evento>(model);
    if( await _geralPersistence.SaveChangesAsync())
    {
      return await _eventoPersistence.GetEventoByAsync(model.Id, false);
    }
    return null;
}
catch (Exception ex)
{
    
    throw new Exception(ex.Message);
}
    }


    public async Task<bool> DeleteEvento(int eventoId)
    {
      try
     {
         var evento = await _eventoPersistence.GetEventoByAsync(eventoId, false);
         if (evento == null) throw new Exception("Evento para delete não encontrado");

        

         _geralPersistence.Delete<Evento>(evento);
      return await _geralPersistence.SaveChangesAsync();   
    

     }
     catch (Exception ex)
     {
         
         throw new Exception(ex.Message);
     }
     
    }

    public async Task<Evento[]> GetAllEventosAsync(bool incluePalestrantes = false)
    {
      try
      {
          var eventos = await _eventoPersistence.GetAllEventosAsync(incluePalestrantes); 
          if (eventos == null) return null;

          return eventos;
      }
      catch (Exception ex)
      {
          
          throw new Exception(ex.Message);
      }
    }

    public async  Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluePalestrantes = false)
    {
       try
      {
          var eventos = await _eventoPersistence.GetAllEventosByTemaAsync(tema, incluePalestrantes); 
          if (eventos == null) return null;

          return eventos;
      }
      catch (Exception ex)
      {
          
          throw new Exception(ex.Message);
      }
    }

    public async Task<Evento> GetEventoByAsync(int eventoId, bool incluePalestrantes = false)
    {
      try
      {
          var eventos = await _eventoPersistence.GetEventoByAsync(eventoId, incluePalestrantes); 
          if (eventos == null) return null;

          return eventos;
      }
      catch (Exception ex)
      {
          
          throw new Exception(ex.Message);
      }
    }

    public async Task<Evento> UpdateEvento(int eventoId, Evento model)
    {
     try
     {
         var evento = await _eventoPersistence.GetEventoByAsync(eventoId, false);
         if (evento == null) return null;

         model.Id = evento.Id;

         _geralPersistence.Update(model);
     if( await _geralPersistence.SaveChangesAsync())
    {
      return await _eventoPersistence.GetEventoByAsync(model.Id, false);
    }
    return null;

     }
     catch (Exception ex)
     {
         
         throw new Exception(ex.Message);
     }
    }
  }


}