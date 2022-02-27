using FluentValidation.Results;
using Muleki.Common.Exceptions;
using Muleki.Domain.Validators;

namespace Muleki.Domain.Entities
{
    public class PlayerFootball : BaseEntity
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int FootballId { get; set; }
        public Football Football { get; set; }

        // Entity Framework Core
        public PlayerFootball() { }
        
        public override bool Validate()
        {
            PlayerFootballValidator validator = new PlayerFootballValidator();
            ValidationResult result = validator.Validate(this);

            if (!result.IsValid)
            {
                result.Errors.ForEach(error => _errors.Add(error.ErrorMessage));
                throw new DomainException("Campos inválidos", _errors);
            }

            return true;
        }
    }
}