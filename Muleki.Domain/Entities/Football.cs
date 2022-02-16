namespace Muleki.Domain.Entities
{
    public class Football : BaseEntity
    {
        public DateTime Date { get; set; }

        // Entity Framework Core
        public Football() { }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}