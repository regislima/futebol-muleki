using System.ComponentModel.DataAnnotations;

namespace Muleki.Api.InputModels.Football
{
    public class FootballUpdateInput
    {
        [Required(ErrorMessage = "O Id é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "O Id deve ser maior ou igual a {1}")]
        public long Id { get; set; }
    }
}