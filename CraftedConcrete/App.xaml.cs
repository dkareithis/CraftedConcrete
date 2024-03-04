using Serilog;
using Serilog.Events;
using Serilog.Sinks.File;

namespace CraftedConcrete
{
    public partial class App : Application
    {
        public static UserInfo UserInfo;
        public App()
        {
            //Create a logger configuration.
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("concrete.txt")
                .MinimumLevel.Information()
                .CreateLogger();
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
