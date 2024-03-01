using CraftedConcrete.Models;

namespace CraftedConcrete
{
    public partial class App : Application
    {
        public static UserInfo UserInfo;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
