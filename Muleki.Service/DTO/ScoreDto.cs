namespace Muleki.Service.Dto
{
    public class ScoreDto
    {
        public long Id { get; set; }
        public int Attribute { get; set; }
        public decimal Note { get; set; }
        public long Quantity { get; set; }
        public decimal Total { get; set; }
        public long PlayerFootballId { get; set; }
    }
}