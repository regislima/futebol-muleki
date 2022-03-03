using FluentValidation.Results;
using Muleki.Common.Exceptions;
using Muleki.Domain.Validators;

namespace Muleki.Domain.Entities
{
    public class Score : BaseEntity
    {
        public DateTime Date { get; set; }
        public ScoreAttribute Attribute { get; set; }
        public decimal Note { get; set; }
        public long Quantity { get; set; }
        public decimal Total { get; set; }
        
        #region ManyToOne
        public long PlayerFootballId { get; set; }
        public PlayerFootball PlayerFootball { get; set; }
        #endregion

        // Entity Framework Core
        public Score() { }

        public override bool Validate()
        {
            ScoreValidator validator = new ScoreValidator();
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