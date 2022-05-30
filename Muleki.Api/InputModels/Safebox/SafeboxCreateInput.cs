using System.ComponentModel.DataAnnotations;
using Muleki.Domain.Entities;

namespace Muleki.Api.InputModels.Safebox
{
    public class SafeboxCreateInput
    {
        [Required(ErrorMessage = "O Valor é obrigatório")]
        [Range(0, 200, ErrorMessage = "O Valor deve estar entre {1} e {2}")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "O Fotebol é obrigatório")]
        public long FootballId { get; set; }

        [Required(ErrorMessage = "O Tipo é obrigatório")]
        [Range((int)SafeboxType.INCOME, (int)SafeboxType.EXPENSE, ErrorMessage = "O Tipo deve estar entre {1} e {2}")]
        public int Type { get; set; }
    }
}