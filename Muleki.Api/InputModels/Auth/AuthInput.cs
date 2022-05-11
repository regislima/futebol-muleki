using System.ComponentModel.DataAnnotations;

namespace Muleki.Api.InputModels.Auth
{
    public class AuthInput
    {
        [Required(ErrorMessage = "O Email é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O Email deve ter no máximo {1} caracteres.")]
        [EmailAddress(ErrorMessage = "O Email é inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O senha é obrigatório.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo {1} caracteres.")]
        [MaxLength(15, ErrorMessage = "O email deve ter no máximo {1} caracteres.")]
        public string Password { get; set; }
    }
}