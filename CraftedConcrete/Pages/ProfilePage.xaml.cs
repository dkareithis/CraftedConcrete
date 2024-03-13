namespace CraftedConcrete.Pages;

public partial class ProfilePage : ContentPage
{
    private readonly LoginPageViewModel _loginPageViewModel;

    public ProfilePage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
        _loginPageViewModel = loginPageViewModel;
        BindingContext = _loginPageViewModel;
    }

}