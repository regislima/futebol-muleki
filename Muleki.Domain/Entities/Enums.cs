using System.ComponentModel;

namespace Muleki.Domain.Entities
{
    public enum Level
    {
        [Description("Administrador")]
        ADMINISTRATOR = 1,

        [Description("Jogador")]
        PLAYER = 2
    }

    public enum SafeboxType
    {
        [Description("Receita")]
        INCOME = 1,

        [Description("Despesa")]
        EXPENSE = 2
    }

    public enum ScoreAttribute
    {
        [Description("Gol")]
        GOAL = 1,

        [Description("Assistência")]
        ASSISTENCE = 2,

        [Description("Chute na Trave")]
        KICK_ON_THE_BEAM = 3,

        [Description("Gol Perdido")]
        GOAL_LOST = 4,

        [Description("Desarme")]
        DISARM = 5,

        [Description("Cartão Amarelo")]
        YELLOW_CARD = 6,

        [Description("Cartão Vermelho")]
        RED_CARD = 7,

        [Description("Defesa Difícil")]
        HARD_DEFENSE = 8
    }
}