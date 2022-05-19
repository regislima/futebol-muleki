using FluentValidation;
using Muleki.Domain.Entities;

namespace Muleki.Domain.Validators
{
    public class ScoreValidator : AbstractValidator<Score>
    {
        public ScoreValidator()
        {
            RuleFor(score => score)
                .NotNull()
                .WithMessage("Pontuação não pode ser nula");
            
            RuleFor(score => score.Attribute)
                .NotNull()
                .IsInEnum()
                .WithMessage("Atributo deve ser informado");

            RuleFor(score => score.Note)
                .NotEmpty()
                .WithMessage("Nota não pode nulo ou vazio");
            
            RuleFor(score => score.Quantity)
                .NotEmpty()
                .WithMessage("Nome não pode ser nulo ou vazio")

                .LessThan(0)
                .WithMessage("Quantidade não pode ser negativo");
            
            RuleFor(score => score.Total)
                .NotEmpty()
                .WithMessage("Total não pode ser nulo ou vazio");
            
            RuleFor(score => score.PlayerFootball)
                .NotNull()
                .WithMessage("Jogador deve ser informado");
        }
    }
}