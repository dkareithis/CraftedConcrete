
namespace CraftedConcrete.Services
{
    public class AuthService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public AuthService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task Register(UserInfo model)
        {
            var httpClient = httpClientFactory.CreateClient("custom-httpclient");
            var result = await httpClient.PostAsJsonAsync("/register", model);

            if (result.IsSuccessStatusCode)
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                await Toast.Make("Successfully Registered. Login to continue shopping", ToastDuration.Short)
                    .Show();
            }
            await Toast.Make($"'{result.ReasonPhrase}'", ToastDuration.Short)
                .Show();

        }
        public async Task Login(LoginModel model)
        {
            try
            {
                if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                 {
                    var httpClient = httpClientFactory.CreateClient("custom-httpclient");
                    var result = await httpClient.PostAsJsonAsync("/api/v1/auth/login", model);
                    var response = await result.Content.ReadFromJsonAsync<UserInfo>();
                    if (response is not null)
                    {
                        var serializeResponse = JsonSerializer.Serialize(new UserInfo()
                            {
                                AccessToken = response.AccessToken,
                                RefreshToken = response.RefreshToken,
                                UserName = model.Email
                            });
                        await SecureStorage.Default.SetAsync("Authentication", serializeResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
