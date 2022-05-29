using FluentValidation;
using Muleki.Domain.Entities;

namespace Muleki.Domain.Validators
{
    public class SafeboxValidator : AbstractValidator<Safebox>
    {
        public SafeboxValidator()
        {
            RuleFor(safebox => safebox)
                .NotNull()
                .WithMessage("Cofre não pode ser nulo.");
            
            RuleFor(safebox => safebox.Type)
                .NotEmpty()
                .IsInEnum()
                .WithMessage("Tipo não pode ser nulo.");
            
            RuleFor(safebox => safebox.Value)
                .NotEmpty()
                .WithMessage("Valor não pode ser nulo ou vazio.")

                .GreaterThan(0)
                .WithMessage("Valor não pode ser negativo");
            
            RuleFor(safebox => safebox.FootballId)
                .NotNull()
                .WithMessage("Futebol ('racha') deve ser informado.");
        }
    }
}