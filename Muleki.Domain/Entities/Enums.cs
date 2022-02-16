using System.ComponentModel;

namespace Muleki.Domain.Entities
{
    public enum Role
    {
        [Description("Jogador")]
        PLAYER,

        [Description("Administrador")]
        ADMINISTRATOR
    }
}