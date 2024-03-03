
namespace CraftedConcrete.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _password;

        readonly ILoginRepository loginRepository = new AuthService();

        [RelayCommand]
        public async void Login()
        {
            if(!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password)) 
            {
                UserInfo userInfo = await loginRepository.Login(UserName, Password);

                if(Preferences.ContainsKey(nameof(App.UserInfo)))
                {
                    Preferences.Remove(nameof(App.UserInfo));
                }

                string userDetails=JsonConvert.SerializeObject(userInfo);
                Preferences.Set(nameof(App.UserInfo),userDetails);
                App.UserInfo = userInfo;

                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }

        }
    }
}
