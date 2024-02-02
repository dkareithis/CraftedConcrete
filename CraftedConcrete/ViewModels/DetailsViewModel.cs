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
        public DetailsViewModel() 
        {

        }
        [ObservableProperty]
        private Concrete _concrete;
    }
}
