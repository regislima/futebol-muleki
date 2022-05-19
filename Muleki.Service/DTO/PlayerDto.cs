using System.Text.Json.Serialization;

namespace Muleki.Service.Dto
{
    public class PlayerDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Nick { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public int Role { get; set; }
    }
}