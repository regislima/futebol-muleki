using System.Text.Json.Serialization;

namespace Muleki.Service.DTO
{
    public class AuthDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Token { get; set; }
        public PlayerDto PlayerDto { get; set; }
    }
}