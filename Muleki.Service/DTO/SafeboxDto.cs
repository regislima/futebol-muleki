using Muleki.Domain.Entities;

namespace Muleki.Service.Dto
{
    public class SafeboxDto
    {
        public long Id { get; set; }
        public decimal IncomeValue { get; set; }
        public decimal ExpenseValue { get; set; }
        public long FootballId { get; set; }
    }
}