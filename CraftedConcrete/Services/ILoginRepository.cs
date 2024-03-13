
namespace CraftedConcrete.Services
{
    public interface ILoginRepository
    {
        Task<UserInfo> Login(string username, string password);
//        Task<UserInfo> Register(string username, string password);
    }
}
