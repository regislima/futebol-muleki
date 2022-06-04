using FluentValidation.Results;
using Muleki.Domain.Validators;
using Muleki.Exceptions;

namespace Muleki.Domain.Entities
{
    public class Safebox : BaseEntity
    {
        public decimal IncomeValue { get; set; }
        public decimal ExpenseValue { get; set; }
        
        #region OneToOne
        public long FootballId { get; set; }
        public Football Football { get; set; }
        #endregion

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