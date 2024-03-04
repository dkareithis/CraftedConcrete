using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole;

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
                    var userInfo = new List<UserInfo>();
                    var client = new HttpClient();
                    string url = "https://fakestoreapi.com/auth/login/"+username+"/"+password;
                    client.BaseAddress = new Uri(url);
                    HttpResponseMessage response = await client.GetAsync("");
                    Log.Logger = new LoggerConfiguration()
                        .WriteTo.Console()
                        .CreateLogger();

                    Log.Information(response.ToString());
                    Log.CloseAndFlush();
                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;
                        userInfo = JsonConvert.DeserializeObject<List<UserInfo>>(content);
                        return await Task.FromResult(userInfo.FirstOrDefault());
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
