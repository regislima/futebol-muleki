using FluentValidation.Results;
using Muleki.Common.Exceptions;
using Muleki.Domain.Validators;

namespace Muleki.Domain.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        // Entity Framework Core
        protected Player() { }

        public Player(long id, string name, string nick, string email, string password, Role role)
        {
            Id = id;
            Name = name;
            Nick = nick;
            Email = email;
            Password = password;
            Role = role;
        }

        public override bool Validate()
        {
            PlayerValidator validator = new PlayerValidator();
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