using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftedConcrete.ViewModels
{
    [QueryProperty(nameof(Concrete), nameof(Concrete))]
    public partial class DetailsViewModel : ObservableObject
    {
        private readonly CartViewModel _cartViewModel;
        public DetailsViewModel(CartViewModel cartViewModel) 
        {
            _cartViewModel = cartViewModel;
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
    }
}
