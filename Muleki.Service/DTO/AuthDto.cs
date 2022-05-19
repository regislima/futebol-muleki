using System.Text.Json.Serialization;

namespace Muleki.Service.Dto
{
    public class AuthDto
    {
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Token { get; set; }
        public PlayerDto Player { get; set; }
    }
}