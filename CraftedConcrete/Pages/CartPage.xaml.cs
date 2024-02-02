namespace CraftedConcrete.Pages;

public partial class CartPage : ContentPage
{
	private readonly CartViewModel _cartViewModel;
	public CartPage(CartViewModel cartViewModel)
	{
		_cartViewModel = cartViewModel;
		InitializeComponent();
		BindingContext = _cartViewModel;
	}
}