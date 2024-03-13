
namespace CraftedConcrete.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private UserInfo userInfo;
        [ObservableProperty]
        public bool isAuthenticated;
        [ObservableProperty]
        public string userName;
    }
}
