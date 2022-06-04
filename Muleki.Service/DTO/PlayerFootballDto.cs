namespace Muleki.Service.Dto
{
    public class PlayerFootballDto
    {
        public long Id { get; set; }
        public List<PlayerDto> Players { get; set; }
        public FootballDto Football { get; set; }
    }
}