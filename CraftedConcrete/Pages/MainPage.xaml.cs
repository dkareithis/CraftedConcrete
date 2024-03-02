namespace CraftedConcrete.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void TapGestureRecognizer_Tapped(object sender, 
            Microsoft.Maui.Controls.TappedEventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
