namespace Muleki.Service.DTO
{
    public class ScoreDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Attribute { get; set; }
        public decimal Note { get; set; }
        public long Quantity { get; set; }
        public decimal Total { get; set; }
        public long PlayerFootballId { get; set; }
    }
}