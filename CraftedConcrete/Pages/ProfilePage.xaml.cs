namespace CraftedConcrete.Pages;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
		if(App.UserInfo != null)
		{
			lblUserName.Text = "Logged in as: " + App.UserInfo.Username;
			lblUserEmail.Text = App.UserInfo.Email;
		}
	}

	[RelayCommand]

	async void SignOut()
	{
		if(Preferences.ContainsKey(nameof(App.UserInfo)))
		{
			Preferences.Remove(nameof(App.UserInfo));
		}
		await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
	}
}