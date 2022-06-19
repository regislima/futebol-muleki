using System.ComponentModel.DataAnnotations;

namespace Muleki.Api.InputModels.PlayerFootball
{
    public class PlayerFootballCreateInput
    {
        [Required(ErrorMessage = "O Jogador é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "Jogador inválido")]
        public long PlayerId { get; set; }

        [Required(ErrorMessage = "O Futebol é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "Futebol inválido")]
        public long FootballId { get; set; }
    }
}