using System.ComponentModel.DataAnnotations;

namespace Muleki.Api.InputModels.PlayerFootball
{
    public class PlayerFootballUpdateInput
    {
        [Required(ErrorMessage = "O Id é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "O Id deve ser maior ou igual a {1}")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O Jogador é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "Jogador inválido")]
        public long PlayerId { get; set; }

        [Required(ErrorMessage = "O Futebol é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "Futebol inválido")]
        public long FootballId { get; set; }
    }
}