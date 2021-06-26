using System;
using System.Threading.Tasks;
using AutoMapper;
using Proeventos.Application.Contratos;
using ProEventos.Application.Dtos;
using ProEventos.Damain;
using ProEventos.Persistence.Contratos;

namespace Proeventos.Application
{
  public class EventoService : IEventosService
  {
    private readonly IGeralPersistence _geralPersistence;
    private readonly IEventoPersistence _eventoPersistence;
    private readonly IMapper _mapper;
    public EventoService(IGeralPersistence geralPersistence,
                          IEventoPersistence eventoPersistence,
                          IMapper mapper)
    {
      
      _eventoPersistence = eventoPersistence;
      _geralPersistence = geralPersistence;
      _mapper = mapper;

    }
  public async Task<EventoDto> AddEventos(EventoDto model)
  {
    
    try
    {
      var evento = _mapper.Map<Evento>(model);
      _geralPersistence.Add<Evento>(evento);
      if (await _geralPersistence.SaveChangesAsync())
      {
        var eventoRetorno = await _eventoPersistence.GetEventoByAsync(evento.Id, false);
        return _mapper.Map<EventoDto>(eventoRetorno);
      }
      return null;
    }
    catch (Exception ex)
    {

      throw new Exception(ex.Message);
    }
  }

  public async Task<EventoDto> UpdateEvento (int eventoId, EventoDto model)
  {
     try
    {
      var evento = await _eventoPersistence.GetEventoByAsync(eventoId, false);
      if (evento == null)  return null;

      model.Id = evento.Id;
      _mapper.Map(model, evento);

      _geralPersistence.Update<Evento>(evento);

      if (await _geralPersistence.SaveChangesAsync())
      {
        var eventoRetorno = await _eventoPersistence.GetEventoByAsync(evento.Id, false);

        return _mapper.Map<EventoDto>(eventoRetorno);
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

  public async Task<EventoDto[]> GetAllEventosAsync(bool incluePalestrantes = false)
  {
    try
    {
      var eventos = await _eventoPersistence.GetAllEventosAsync(incluePalestrantes);
      if (eventos == null) return null;

      var resultado = _mapper.Map<EventoDto[]>(eventos);

      return resultado;
    }
    catch (Exception ex)
    {

      throw new Exception(ex.Message);
    }
  }

  public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool incluePalestrantes = false)
  {
    try
    {
      var eventos = await _eventoPersistence.GetAllEventosByTemaAsync(tema, incluePalestrantes);
      if (eventos == null) return null;

       var resultado = _mapper.Map<EventoDto[]>(eventos);

      return resultado;

     
    }
    catch (Exception ex)
    {

      throw new Exception(ex.Message);
    }
  }

  public async Task<EventoDto> GetEventoByAsync(int eventoId, bool incluePalestrantes = false)
  {
    try
    {
      var evento = await _eventoPersistence.GetEventoByAsync(eventoId, incluePalestrantes);
      if (evento == null) return null;

      var resultado = _mapper.Map<EventoDto>(evento);
      return resultado;

      // var eventoRetorno = new EventoDto()
      // {
      //   Id = evento.Id,
      //   Local = evento.Local,
      //   DataEvento = evento.DataEvento.ToString(),
      //   Tema = evento.Tema,
      //   QtdPessoas = evento.QtdPessoas,
      //   ImagemURL = evento.ImagemUrl,
      //   Telefone = evento.Telefone,
      //   Email = evento.Email

      // };

    }
    catch (Exception ex)
    {

      throw new Exception(ex.Message);
    }
  }

  // public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto model)
  // {
  //   try
  //   {
  //     var evento = await _eventoPersistence.GetEventoByAsync(eventoId, false);
  //     if (evento == null) return null;

  //     model.Id = evento.Id;

  //     _geralPersistence.Update(model);
  //     if (await _geralPersistence.SaveChangesAsync())
  //     {
  //       // return await _eventoPersistence.GetEventoByAsync(model.Id, false);
  //     }
  //     return null;

  //   }
  //   catch (Exception ex)
  //   {

  //     throw new Exception(ex.Message);
  //   }
  // }
}


}