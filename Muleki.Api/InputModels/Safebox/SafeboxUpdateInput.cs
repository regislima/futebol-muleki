using System.ComponentModel.DataAnnotations;

namespace Muleki.Api.InputModels.Safebox
{
    public class SafeboxUpdateInput
    {
        [Required(ErrorMessage = "O Id é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "O Id deve ser maior ou igual a {1}")]
        public long Id { get; set; }
        
        [Range(0, 200, ErrorMessage = "O Tipo deve ser maior que {1}")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "O Fotebol é obrigatório")]
        public long FootballId { get; set; }

        [Required(ErrorMessage = "O Tipo é obrigatório")]
        [Range(0, 1, ErrorMessage = "O Tipo deve estar entre {1} e {2}")]
        public int Type { get; set; }
    }
}