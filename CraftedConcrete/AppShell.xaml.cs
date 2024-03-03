namespace CraftedConcrete
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            this.BindingContext = new ProfilePage();
            Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
            Routing.RegisterRoute(nameof(CheckoutPage), typeof(CheckoutPage));  
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));  
        }
    }
}
