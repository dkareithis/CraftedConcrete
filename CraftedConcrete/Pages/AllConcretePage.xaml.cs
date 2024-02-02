namespace CraftedConcrete.Pages;

public partial class AllConcretePage : ContentPage
{
	private readonly AllConcreteViewModel _allConcreteViewModel;
	public AllConcretePage(AllConcreteViewModel allConcreteViewModel)
	{
		InitializeComponent();
		_allConcreteViewModel = allConcreteViewModel;
		BindingContext = _allConcreteViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		if (_allConcreteViewModel.FromSearch) 
		{
			await Task.Delay(100);
			searchBar.Focus();
		}
    }
    void searchBar_TextChanged(object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
		if (!string.IsNullOrEmpty(e.OldTextValue)
			&& string.IsNullOrEmpty(e.NewTextValue)) 
		{
			_allConcreteViewModel.SearchConcreteCommand.Execute(null);
		}
    }
}