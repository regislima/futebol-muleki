using FluentValidation.Results;
using Muleki.Common.Exceptions;
using Muleki.Domain.Validators;

namespace Muleki.Domain.Entities
{
    public class Football : BaseEntity
    {
        public DateTime Date { get; set; }
        public List<PlayerFootball> PlayerFootball { get; set; }

        // Entity Framework Core
        public Football() { }

        public override bool Validate()
        {
            FootballValidator validator = new FootballValidator();
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