using FluentValidation;
using Muleki.Domain.Entities;

namespace Muleki.Domain.Validators
{
    public class FootballValidator : AbstractValidator<Football>
    {
        public FootballValidator()
        {
            RuleFor(football => football)
                .NotNull()
                .WithMessage("Futebol não pode ser nulo");
        }
    }
}