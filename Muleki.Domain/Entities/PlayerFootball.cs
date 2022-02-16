namespace Muleki.Domain.Entities
{
    public class PlayerFooteball : BaseEntity
    {
        public Player Player { get; set; }
        public Football Football { get; set; }

        // Entity Framework Core
        public PlayerFootball() { }
        
        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}