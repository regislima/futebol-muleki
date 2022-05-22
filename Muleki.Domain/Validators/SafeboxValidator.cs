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
                .WithMessage("Cofre não pode ser nulo");
            
            RuleFor(safebox => safebox.Type)
                .NotEmpty()
                .IsInEnum()
                .WithMessage("Receita não pode ser nulo ou vazio");
            
            RuleFor(safebox => safebox.Value)
                .NotEmpty()
                .WithMessage("Valor não pode ser nulo ou vazio")

                .LessThan(0)
                .WithMessage("Despesa não pode ser negativo");
            
            RuleFor(safebox => safebox.Football)
                .NotNull()
                .WithMessage("Futebol ('racha') deve ser informado");
        }
    }
}