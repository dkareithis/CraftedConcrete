
namespace CraftedConcrete.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private LoginModel loginModel;
        [ObservableProperty]
        private UserInfo userInfo;

        [ObservableProperty]
        public string userName;
        [ObservableProperty]
        public bool isAuthenticated;
    }
}
