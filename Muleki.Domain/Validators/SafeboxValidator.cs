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
            
            RuleFor(safebox => safebox.IncomeValue)
                .NotEmpty()
                .WithMessage("Receita não pode ser nulo ou vazio.")

                .GreaterThan(0)
                .WithMessage("Receita não pode ser negativo");
            
            RuleFor(safebox => safebox.ExpenseValue)
                .NotEmpty()
                .WithMessage("Despesa não pode ser nulo ou vazio.")

                .GreaterThan(0)
                .WithMessage("Despesa não pode ser negativo");
            
            RuleFor(safebox => safebox.FootballId)
                .NotNull()
                .WithMessage("Futebol ('racha') deve ser informado.");
        }
    }
}