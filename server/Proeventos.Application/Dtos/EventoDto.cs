using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Proeventos.Application.Dtos;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
      public int    Id { get; set; }
      public string Local { get; set; }
      public string DataEvento { get; set; }
      [Required(ErrorMessage = "O Campo {0} é obrigatorio")]   
      [MinLength(3, ErrorMessage = "O {0} deve ter no minimo 4 caracteres.")]   
      [MaxLength(50, ErrorMessage = "O {0} deve ter no maximo 50 caracteres.")]   
      public string Tema { get; set; }
      [Display(Name="Quantidade de Pessoas")]
      [Range(1,12000, ErrorMessage = "{0} não pode ser menor que 1 e maior que 120.000")]
      public int QtdPessoas { get; set; }
      
      [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$",ErrorMessage = "Não é uma imagem válida. (gif, jpg, apeg, bmp ou png)")]
      public string ImagemURL { get; set; }

      [Required(ErrorMessage = "O Campo {0} é obrigatorio ")]
      [Phone(ErrorMessage="o campo{0} está com número inválido")]
      public string Telefone { get; set; }
      [Display(Name = "e-mail")]
      [EmailAddress(ErrorMessage = "O campo {0} não é um {0} valido")]
      public string Email { get; set; }

      public IEnumerable<LoteDto> Lotes { get; set; }

      public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
      public IEnumerable<PalestranteDto> PalestrantesEventos { get; set; }

        
    }
}