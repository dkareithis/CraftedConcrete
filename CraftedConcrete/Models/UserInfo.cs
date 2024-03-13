
namespace CraftedConcrete.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
}
