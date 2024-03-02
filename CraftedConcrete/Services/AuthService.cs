using CraftedConcrete.Models;
using System.Net.Http.Json;

namespace CraftedConcrete.Services
{
    public class AuthService : ILoginRepository
    {
        public async Task<UserInfo> Login(string username, string password)
        {
            try
            {
                if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                 {
                    var userInfo = new UserInfo();
                    var client = new HttpClient();
                    string url = "https://192.168.16.119:46795/api/UserInfoes/LoginUser/"+username+"/"+password;
                    client.BaseAddress = new Uri(url);
                    HttpResponseMessage response = await client.GetAsync("");
                    if (response.IsSuccessStatusCode)
                    {
                        userInfo = await response.Content.ReadFromJsonAsync<UserInfo>();
                        return await Task.FromResult(userInfo);
                    }
                    else
                    {
                        return null;
                    }
                }
                else 
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
