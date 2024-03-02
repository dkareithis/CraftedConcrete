using CraftedConcrete.Models;

namespace CraftedConcrete.Services
{
    public interface ILoginRepository
    {
        Task<UserInfo> Login(string username, string password);
    }
}
