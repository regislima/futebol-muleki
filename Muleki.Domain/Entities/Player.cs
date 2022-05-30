using FluentValidation.Results;
using Muleki.Domain.Validators;
using Muleki.Exceptions;

namespace Muleki.Domain.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public string? Nick { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Level Role { get; set; }

        #region OneToMany
        public List<PlayerFootball> PlayerFootball { get; set; }
        #endregion

        // Entity Framework Core
        public Player() { }

        public Player(long id, string name, string nick, string email, string passwordHash, string passwordSalt, Level role)
        {
            Id = id;
            Name = name;
            Nick = nick;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
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