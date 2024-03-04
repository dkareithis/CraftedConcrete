

namespace CraftedConcrete.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string? _username;

        [ObservableProperty]
        private string? _password;

        readonly ILoginRepository _loginRepository = new AuthService();

        [RelayCommand]
        public async Task Login()
        {
            if(!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password)) 
            {
                UserInfo userInfo = await _loginRepository.Login(Username, Password);

                if(Preferences.ContainsKey(nameof(App.UserInfo)))
                {
                    Preferences.Remove(nameof(App.UserInfo));
                }
                    string userDetails = JsonConvert.SerializeObject(userInfo);
                    Preferences.Set(nameof(App.UserInfo), userDetails);
                    App.UserInfo = userInfo;
//                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");

                if(userInfo != null) 
                {
                    await Toast.Make("Username and Password is incorrect.", ToastDuration.Short)
                        .Show();
                }
            }
            else
            {
                await Toast.Make("Username and Password cannot be blank.", ToastDuration.Short)
                    .Show();
            }

        }
    }
}
