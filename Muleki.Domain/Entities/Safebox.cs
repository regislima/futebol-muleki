namespace Muleki.Domain.Entities
{
    public class Safebox : BaseEntity
    {
        public decimal Income { get; set; }
        public decimal Expense { get; set; }
        public Football Football { get; set; }

        // Entity Framework Core
        public Safebox() { }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}