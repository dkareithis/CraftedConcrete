
namespace CraftedConcrete.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly ConcreteService _concreteService;
        private readonly AuthService _authService;
        public HomeViewModel(ConcreteService concreteService, AuthService authService) 
        {
            _concreteService = concreteService;
            _authService = authService;
            Concretes = new(_concreteService.GetPopularConcretes());
        }

        public ObservableCollection<Concrete> Concretes { get; set; }

        [RelayCommand]
        private async Task GoToAllConcretePage(bool fromSearch = false)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(AllConcreteViewModel.FromSearch)] = fromSearch
            };
            await Shell.Current.GoToAsync(nameof(AllConcretePage), animate: true, parameters);
        }

        [RelayCommand]
        private async Task GoToDetailsPage(Concrete concrete)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(DetailsViewModel.Concrete)] = concrete
            };
        await Shell.Current.GoToAsync(nameof(DetailPage), animate: true, parameters);
    }
}
}
