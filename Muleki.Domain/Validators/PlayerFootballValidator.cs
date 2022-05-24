using FluentValidation;
using Muleki.Domain.Entities;

namespace Muleki.Domain.Validators
{
    public class PlayerFootballValidator : AbstractValidator<PlayerFootball>
    {
        public PlayerFootballValidator()
        {
            RuleFor(playerFootball => playerFootball)
                .NotNull()
                .WithMessage("Jogador-Futebol não pode ser nulo");
            
            RuleFor(playerFootball => playerFootball.PlayerId)
                .NotNull()
                .WithMessage("Jogador não pode ser nulo");
            
            RuleFor(playerFootball => playerFootball.FootballId)
                .NotNull()
                .WithMessage("Futebol não pode ser nulo");
        }
    }
}