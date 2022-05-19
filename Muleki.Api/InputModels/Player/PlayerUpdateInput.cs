using System.ComponentModel.DataAnnotations;

namespace Muleki.Api.InputModels.Player
{
    public class PlayerUpdateInput
    {
        [Required(ErrorMessage = "O Id é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "O Id deve ser maior ou igual a {1}")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O Nome deve ter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "O Nome deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        [MinLength(2, ErrorMessage = "O Apelido deve ter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "O Apelido deve ter no máximo {1} caracteres")]
        public string? Nick { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        [MaxLength(180, ErrorMessage = "O Email deve ter no máximo {1} caracteres")]
        [EmailAddress(ErrorMessage = "O Email é inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Nível é obrigatório")]
        [Range(0, 1, ErrorMessage = "O Nível deve estar entre {1} e {2}")]
        public int Role { get; set; }
    }
}