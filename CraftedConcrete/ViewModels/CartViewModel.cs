using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftedConcrete.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
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
        private void RemoveCartItem(string name) 
        {
            var item = Items.FirstOrDefault(i => i.Name == name);
            if (item != null)
            {
                Items.Remove(item);
                RecalculateTotalAmount();
            }
        }

        [RelayCommand]
        private async void ClearCart()
        {
            if (await Shell.Current.DisplayAlert("Confirm clear cart?", "Are you sure you want to clear the cart?", "Yes", "No"))
            {
                Items.Clear();
                RecalculateTotalAmount();
                await Toast.Make("Cart Cleared", ToastDuration.Short).Show();
            }
        }

        [RelayCommand]
        private async Task PlaceOrder()
        {
            Items.Clear();
            RecalculateTotalAmount();
            //Go to checkout page
        }
    }

}
