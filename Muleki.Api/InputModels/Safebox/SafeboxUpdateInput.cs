using System.ComponentModel.DataAnnotations;
using Muleki.Domain.Entities;

namespace Muleki.Api.InputModels.Safebox
{
    public class SafeboxUpdateInput
    {
        [Required(ErrorMessage = "O Id é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "O Id deve ser maior ou igual a {1}")]
        public long Id { get; set; }
        
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