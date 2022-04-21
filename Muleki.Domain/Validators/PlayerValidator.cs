using FluentValidation;
using Muleki.Domain.Entities;

namespace Muleki.Domain.Validators
{
    public class PlayerValidator : AbstractValidator<Player>
    {
        public PlayerValidator()
        {
            RuleFor(player => player)
                .NotNull()
                .WithMessage("Jogador não pode ser nulo");
            
            RuleFor(player => player.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome não pode ser nulo ou vazio")

                .MinimumLength(2)
                .WithMessage("Nome deve ter no mínimo 2 caracteres")
                
                .MaximumLength(50)
                .WithMessage("Nome deve ter no máximo 50 caracteres");

            RuleFor(player => player.Nick)
                .NotEmpty()
                .WithMessage("Apelido não pode ser vazio")
                
                .MinimumLength(2)
                .WithMessage("Apelido deve ter no mínimo 2 caracteres")
                
                .MaximumLength(50)
                .WithMessage("Apelido deve ter no máximo 50 caracteres");
            
            RuleFor(player => player.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome não pode ser nulo ou vazio")

                .EmailAddress()
                .WithMessage("Email inválido");
            
            RuleFor(player => player.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Senha não pode ser nulo ou vazio")

                .MinimumLength(6)
                .WithMessage("Senha deve ter mínimo de 6 caracteres")
                
                .MaximumLength(200)
                .WithMessage("Senha deve ter máximo de 15 caracteres");

            RuleFor(player => player.Role)
                .NotNull()
                .IsInEnum()
                .WithMessage("O usuário deve ter um nível de acesso");
        }
    }
}