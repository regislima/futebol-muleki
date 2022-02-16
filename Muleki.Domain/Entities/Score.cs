namespace Muleki.Domain.Entities
{
    public class Score : BaseEntity
    {
        public DateTime Date { get; set; }
        public int Attribute { get; set; }
        public decimal Note { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public Player Player { get; set; }

        // Entity Framework Core
        public Score() { }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}