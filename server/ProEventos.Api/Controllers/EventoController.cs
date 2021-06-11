﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Api.Data;
using ProEventos.Api.Models;

namespace ProEventos.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EventoController : ControllerBase
  {
    
    private readonly DataContext _context;
    public EventoController(DataContext context)
    {
      _context = context;
    }
    // Rota Get 
    [HttpGet]
    public IEnumerable<Evento> Get()
    {
      return _context.Eventos;
    }

    //rota por Id
    [HttpGet("{id}")]
    public Evento GetById(int id)
    {
      return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
    }
    [HttpPost]
    public string Post()
    {
      return "Exemplo de Post";
    }
    [HttpPut("{id}")]
    public string Put(int id)
    {
      return $"Exemplo de put com id = {id}";

    }
    [HttpDelete]
    public string Delete(int id)
    {
      return $"Exemplo de put com id = {id}";
    }
  }
}
