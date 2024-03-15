

namespace CraftedConcrete.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {

//        readonly ILoginRepository _loginRepository = new AuthService();

        private readonly AuthService _authService;

        public LoginPageViewModel(AuthService authService)
        {
            _authService = authService;
            LoginModel = new();
            IsAuthenticated = false;
            GetUserNameFromSecureStorage();
        }

        [RelayCommand]
        private async Task Register()
        {
            await _authService.Register(UserInfo);
        }

        [RelayCommand]
        public async Task Login()
        {
            await _authService.Login(LoginModel);
            GetUserNameFromSecureStorage();
        }

        [RelayCommand]
        public async Task Logout()
        {
            SecureStorage.Default.Remove("Authentication");
            IsAuthenticated = false;
            UserName = "Guest";
            await Shell.Current.GoToAsync($"//{nameof(ProfilePage)}");
        }
        private async void GetUserNameFromSecureStorage()
        {
            if (!string.IsNullOrEmpty(UserName) && userName! != "Guest")
            {
                IsAuthenticated = true;
                return;
            }
            var serializedLoginresponseInStorage = await SecureStorage.Default.GetAsync("Authentication");
            if (serializedLoginresponseInStorage != null)
            {
                UserName = JsonSerializer.Deserialize<UserInfo>(serializedLoginresponseInStorage)!.UserName!;
                IsAuthenticated = true;
                return;
            }
            UserName = "Guest";
            IsAuthenticated = false;
        }
    }
}
