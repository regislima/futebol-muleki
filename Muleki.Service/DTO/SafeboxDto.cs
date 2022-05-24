using Muleki.Domain.Entities;

namespace Muleki.Service.Dto
{
    public class SafeboxDto
    {
        public long Id { get; set; }
        public SafeboxType Type { get; set; }
        public decimal Value { get; set; }
        public long FootballId { get; set; }
    }
}