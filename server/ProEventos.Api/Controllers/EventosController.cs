using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proeventos.Application.Contratos;
using Microsoft.AspNetCore.Http;
using ProEventos.Application.Dtos;

namespace ProEventos.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EventosController : ControllerBase
  {

    private readonly IEventosService _eventoService;

    public EventosController(IEventosService eventoService)
    {
      _eventoService = eventoService;

    }
    // Rota Get 
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
          var eventos = await _eventoService.GetAllEventosAsync(true);
          if(eventos == null) return NoContent();
          

          

          return Ok(eventos);
      }
      catch (Exception ex)
      {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, 
          $"Erro ao tentar recuperar eventos> Ero: {ex.Message}");
      }
    }

    //rota por Id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
       try
      {
          var evento = await _eventoService.GetEventoByAsync(id,true);
          if(evento == null) return  NoContent();

          return Ok(evento);
      }
      catch (Exception ex)
      {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, 
          $"Erro ao tentar recuperar eventos> Ero: {ex.Message}");
      }
    }

       [HttpGet("{tema}/tema")]
    public async Task<IActionResult> GetByTema(string tema)
    {
       try
      {
          var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
          if(evento == null) return  NoContent();

          return Ok(evento);
      }
      catch (Exception ex)
      {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, 
          $"Erro ao tentar recuperar eventos> Ero: {ex.Message}");
      }
    }
    [HttpPost]
    public async Task<IActionResult> Post(EventoDto model)
    {
       try
      {
          var evento = await _eventoService.AddEventos(model);
          if(evento == null) return  NoContent();

          return Ok(evento);
      }
      catch (Exception ex)
      {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, 
          $"Erro ao tentar Adicionar eventos> Ero: {ex.Message}");
      }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, EventoDto model)
    {
           try
      {
          var evento = await _eventoService.UpdateEvento(id, model);
          if(evento == null) return BadRequest("Erro ao tentar adicionar evento");

          return Ok(evento);
      }
      catch (Exception ex)
      {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, 
          $"Erro ao tentar Atualizar eventos> Ero: {ex.Message}");
      }

    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
            try
      {
         if( await _eventoService.DeleteEvento(id))
         return Ok("Deletado");
         else
         return BadRequest("Evento não deletado");
      
      }
      catch (Exception ex)
      {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, 
          $"Erro ao tentar Deletar eventos> Ero: {ex.Message}");
      }
    }
  }
}
