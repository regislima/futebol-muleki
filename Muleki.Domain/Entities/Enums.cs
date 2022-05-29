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

    public enum SafeboxType
    {
        [Description("Despesa")]
        EXPENSE,

        [Description("Receita")]
        INCOME
    }

    public enum ScoreAttribute
    {
        [Description("Gol")]
        GOAL,

        [Description("Assistência")]
        ASSISTENCE,

        [Description("Chute na Trave")]
        KICK_ON_THE_BEAM,

        [Description("Gol Perdido")]
        GOAL_LOST,

        [Description("Desarme")]
        DISARM,

        [Description("Cartão Amarelo")]
        YELLOW_CARD,

        [Description("Cartão Vermelho")]
        RED_CARD,

        [Description("Defesa Difícil")]
        HARD_DEFENSE
    }
}