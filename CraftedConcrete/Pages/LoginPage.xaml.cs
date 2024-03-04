namespace CraftedConcrete.Pages;

public partial class LoginPage : ContentPage
{
    private LoginPageViewModel _loginPageViewModel;
    public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
        _loginPageViewModel = loginPageViewModel;
        BindingContext = _loginPageViewModel;
    }
}