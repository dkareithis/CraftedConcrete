using CraftedConcrete.Models;

namespace CraftedConcrete.Services
{
    public class ConcreteService
    {
        private readonly static IEnumerable<Concrete> _concretes = new
            List<Concrete>
        {
            new Concrete
            {
                Name = "Excavator",
                Image = "excavator",
                Price = 10000000,
            },
            new Concrete
            {
                Name = "Helmet",
                Image = "helmet",
                Price = 6000,
            },
            new Concrete
            {
                Name = "Brick And Shovel",
                Image = "brickwall",
                Price = 10000,
            },
            new Concrete
            {
                Name = "Engineer",
                Image = "engineering",
                Price = 10000,
            },
            new Concrete
            {
                Name = "Architect",
                Image = "architect",
                Price = 10000,
            },
            new Concrete
            {
                Name = "Cogs",
                Image = "customersupport",
                Price = 10000,
            },
            new Concrete
            {
                Name = "Fundi",
                Image = "worker",
                Price = 10000,
            },
            new Concrete
            {
                Name = "Notice of Work",
                Image = "workinprogress",
                Price = 10000,
            }
        };
        public IEnumerable<Concrete> GetAllConcretes() => _concretes;
        public IEnumerable<Concrete> GetPopularConcretes(int count = 6) =>
            _concretes.OrderBy(p=> Guid.NewGuid())
            .Take(count);

        public IEnumerable<Concrete> SearchConcretes(string searchTerm) =>
            string.IsNullOrWhiteSpace(searchTerm)
            ? _concretes
            : _concretes.Where(p => p.Name.Contains(searchTerm,
                StringComparison.OrdinalIgnoreCase));
    }
}
