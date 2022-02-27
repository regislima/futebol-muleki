using FluentValidation.Results;
using Muleki.Common.Exceptions;
using Muleki.Domain.Validators;

namespace Muleki.Domain.Entities
{
    public class Safebox : BaseEntity
    {
        public decimal Income { get; set; }
        public decimal Expense { get; set; }
        
        #region OneToOne
        public int FootballId { get; set; }
        public Football Football { get; set; }
        #endregion

        // Entity Framework Core
        public Safebox() { }

        public override bool Validate()
        {
            SafeboxValidator validator = new SafeboxValidator();
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