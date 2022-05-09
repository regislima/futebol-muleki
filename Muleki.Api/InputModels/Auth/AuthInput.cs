using System.ComponentModel.DataAnnotations;

namespace Muleki.Api.InputModels.Auth
{
    public class AuthInput
    {
        [Required(ErrorMessage = "O email é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
        [EmailAddress(ErrorMessage = "O email é inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O senha é obrigatório.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        [MaxLength(15, ErrorMessage = "O email deve ter no máximo 15 caracteres.")]
        public string Password { get; set; }
    }
}