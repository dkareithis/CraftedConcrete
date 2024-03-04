
namespace CraftedConcrete.Models
{
    public partial class Concrete : ObservableObject
    {
        public string? Name { get; set; }
        public string? Image {  get; set; }
        public double Price {  get; set; }

        [ObservableProperty,
        NotifyPropertyChangedFor(nameof(Amount))]
        private int _cartQuantity;
        public double Amount => CartQuantity * Price;
        public Concrete Clone() => MemberwiseClone() as Concrete;
    }
}
