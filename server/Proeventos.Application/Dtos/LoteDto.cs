using ProEventos.Application.Dtos;

namespace Proeventos.Application.Dtos
{
    public class LoteDto
    {
        
      public int Id { get; set; }
      public string Name { get; set; }
      public decimal Preco { get; set; }
      public string DateInicio { get; set; }
      public string DataFim { get; set; }
      public int Quantidade { get; set; }
      public int EventoId { get; set; }

      public EventoDto Evento { get; set; }
    }
}