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
            
            RuleFor(football => football.Date)
                .NotEmpty()
                .WithMessage("Data do futebol não pode ser nulo ou vazio");
        }
    }
}