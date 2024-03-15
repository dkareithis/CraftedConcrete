using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using CraftedConcrete.Services;
using CraftedConcrete.ViewModels;
using CraftedConcrete.Pages;

namespace CraftedConcrete
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();
            
            builder.Services.AddSingleton<IPlatformHttpMessageHandler>(sp =>
            { 
#if ANDROID
            return new AndroidHttpMessageHandler();
#else
            return null;
#endif
        });

            builder.Services.AddHttpClient("custom-httpclient", httpClient =>
            {
                //                var baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7136" : "https://localhost:7136";
                var baseAddress = "https://api.escuelajs.co";
                httpClient.BaseAddress = new Uri(baseAddress);
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


            });
                /*.ConfigureHttpMessageHandlerBuilder(configBuilder =>
            {
                var platformMessageHandler = configBuilder.Services.GetRequiredService<IPlatformHttpMessageHandler>();
                configBuilder.PrimaryHandler = platformMessageHandler.GetHttpMessageHandler();
            });*/

#if DEBUG
            builder.Logging.AddDebug();
#endif
            AddConcreteServices(builder.Services);
            builder.Services.AddSingleton<AuthService, AuthService>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddTransient<ProfilePage>();


            return builder.Build();
        }

        private static IServiceCollection 
            AddConcreteServices(IServiceCollection services)
        {
            services.AddSingleton<ConcreteService>();

            services.AddSingleton<HomePage>()
                .AddSingleton<HomeViewModel>();

            services.AddTransientWithShellRoute<AllConcretePage,
                AllConcreteViewModel>(nameof(AllConcretePage));
            
            services.AddTransientWithShellRoute<DetailPage,
                DetailsViewModel>(nameof(DetailPage));
            
            services.AddSingleton<CartViewModel>();
            services.AddTransient<CartPage>();
            return services;
        }
    }
}
