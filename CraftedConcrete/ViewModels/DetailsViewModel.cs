using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftedConcrete.ViewModels
{
    [QueryProperty(nameof(Concrete), nameof(Concrete))]
    public partial class DetailsViewModel : ObservableObject, IDisposable
    {
        private readonly CartViewModel _cartViewModel;
        public DetailsViewModel(CartViewModel cartViewModel) 
        {
            _cartViewModel = cartViewModel;

            _cartViewModel.CartCleared += OnCartCleared;
            _cartViewModel.CartItemRemoved += OnCartItemRemoved;
            _cartViewModel.CartItemUpdated += OnCartItemUpdated;
        }

        private void OnCartCleared(object? _, EventArgs e) => Concrete.CartQuantity = 0;
        private void OnCartItemRemoved(object? _, Concrete c) =>
            OnCartItemChanged(c, 0);

        private void OnCartItemUpdated(object? _, Concrete c) =>
            OnCartItemChanged(c, 0);

        private void OnCartItemChanged(Concrete c, int quantity)
        {
            if(c.Name == Concrete.Name)
            {
                Concrete.CartQuantity = quantity;
            }
        }
        [ObservableProperty]
        private Concrete _concrete;

        [RelayCommand]
        private void AddToCart()
        {
            Concrete.CartQuantity++;
            _cartViewModel.UpdateCartItemCommand.Execute(Concrete);
        }
        [RelayCommand]
        private void RemoveFromCart()
        {
            if (Concrete.CartQuantity > 0)
                Concrete.CartQuantity--;
            _cartViewModel.UpdateCartItemCommand.Execute(Concrete);
        }

        [RelayCommand]
        private async Task ViewCart()
        {
            if(Concrete.CartQuantity > 0)
            {
                await Shell.Current.GoToAsync(nameof(CartPage), animate: true);
            }
            else
            {
                await Toast.Make("Please select the quantity using the plus (+) button", ToastDuration.Short)
                    .Show();
            }
        }

        public void Dispose()
        {
            _cartViewModel.CartCleared -= OnCartCleared;
            _cartViewModel.CartItemRemoved -= OnCartItemRemoved;
            _cartViewModel.CartItemUpdated -= OnCartItemUpdated;

        }
    }
}
