using System.ComponentModel.DataAnnotations;
using Muleki.Domain.Entities;

namespace Muleki.Api.InputModels.Safebox
{
    public class SafeboxCreateInput
    {
        [Required(ErrorMessage = "A Receita é obrigatório")]
        [Range(0, 200, ErrorMessage = "A Receita deve estar entre {1} e {2}")]
        public decimal IncomeValue { get; set; }

        [Required(ErrorMessage = "A Despesa é obrigatório")]
        [Range(0, 200, ErrorMessage = "A Despesa deve estar entre {1} e {2}")]
        public decimal ExpenseValue { get; set; }

        [Required(ErrorMessage = "O Fotebol é obrigatório")]
        public long FootballId { get; set; }
    }
}