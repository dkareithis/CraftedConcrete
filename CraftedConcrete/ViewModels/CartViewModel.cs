
namespace CraftedConcrete.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        public event EventHandler<Concrete> CartItemRemoved;
        public event EventHandler<Concrete> CartItemUpdated;
        public event EventHandler CartCleared;
        public ObservableCollection<Concrete> Items { get; set; } = new();

        [ObservableProperty]
        private double _totalAmount;

        private void RecalculateTotalAmount() => TotalAmount = Items.Sum(i => i.Amount);

        [RelayCommand]
        private void UpdateCartItem(Concrete concrete)
        {
            var item = Items.FirstOrDefault(i=> i.Name == concrete.Name);
            if (item != null)
            {
                item.CartQuantity = concrete.CartQuantity;
            }
            else
            {
                Items.Add(concrete.Clone());
            }
            RecalculateTotalAmount();
        }

        [RelayCommand]
        private async void RemoveCartItem(string name) 
        {
            var item = Items.FirstOrDefault(i => i.Name == name);
            if (item != null)
            {
                Items.Remove(item);
                RecalculateTotalAmount();

                CartItemRemoved?.Invoke(this, item);

                var snackbarOptions = new SnackbarOptions
                {
                    CornerRadius = 10,
                    BackgroundColor = Colors.AntiqueWhite
                };
                var snackbar = Snackbar.Make($"'{item.Name}' removed from cart",
                    () =>
                    {
                        Items.Add(item);
                        RecalculateTotalAmount();
                        CartItemUpdated?.Invoke(this, item);
                    }, "Undo", TimeSpan.FromSeconds(5), snackbarOptions);

                await snackbar.Show();
            }
        }

        [RelayCommand]
        private async void ClearCart()
        {
            if (await Shell.Current.DisplayAlert("Confirm clear cart?", "Are you sure you want to clear the cart?", "Yes", "No"))
            {
                Items.Clear();
                RecalculateTotalAmount();
                CartCleared?.Invoke(this, EventArgs.Empty);
                await Toast.Make("Cart Cleared", ToastDuration.Short).Show();
            }
        }

        [RelayCommand]
        private async Task PlaceOrder()
        {
            Items.Clear();
            CartCleared?.Invoke(this, EventArgs.Empty);
            RecalculateTotalAmount();
            await Shell.Current.GoToAsync(nameof(CheckoutPage), animate: true);
        }
    }

}
