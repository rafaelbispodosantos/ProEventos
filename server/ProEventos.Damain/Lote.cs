using System;
using ProEventos.Damain;
namespace ProEventos.Damain
{
    public class Lote
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public decimal Preco { get; set; }
      public DateTime DateInicio { get; set; }
      public DateTime DataFim { get; set; }
      public int Quantidade { get; set; }
      public int EventoId { get; set; }
      public Evento Evento { get; set; }


        
    }
}