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
                .NotEmpty()
                .WithMessage("Nome não pode ser nulo ou vazio")

                .Length(2, 50)
                .WithMessage("Nome deve ter no mínimo 2 e no máximo 50 caracteres");

            RuleFor(player => player.Nick)                
                .Length(2, 50)
                .WithMessage("Nick deve ter no mínimo 2 e no máximo 50 caracteres");
            
            RuleFor(player => player.Email)
                .NotEmpty()
                .WithMessage("Nome não pode ser nulo ou vazio")

                .EmailAddress()
                .WithMessage("Email inválido");
            
            RuleFor(player => player.PasswordHash)
                .NotEmpty()
                .WithMessage("Senha não pode ser nula ou vazia");
            
            RuleFor(player => player.PasswordSalt)
                .NotEmpty()
                .WithMessage("Salt não pode ser nulo ou vazio");

            RuleFor(player => player.Role)
                .NotNull()
                .IsInEnum()
                .WithMessage("O usuário deve ter um nível de acesso");
        }
    }
}