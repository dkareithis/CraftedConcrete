
namespace CraftedConcrete.ViewModels
{
    [QueryProperty(nameof(FromSearch), nameof(FromSearch))]
    public partial class AllConcreteViewModel : ObservableObject
    {
        private readonly ConcreteService _concreteService;
        public AllConcreteViewModel(ConcreteService concreteService)
        {
            _concreteService = concreteService;
            Concretes = new(_concreteService.GetAllConcretes());
        }
        public ObservableCollection<Concrete> Concretes { get; set; }

        [ObservableProperty]
        private bool _fromSearch;

        [ObservableProperty]
        private bool _searching;

        [RelayCommand]
        private async Task SearchConcrete(string searchTerm)
        {
            Concretes.Clear();
            Searching = true;
            await Task.Delay(1000);
            foreach (var concrete in _concreteService.SearchConcretes(searchTerm))
            {
                Concretes.Add(concrete);
            }
            Searching = false;
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
