using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
using BankTimeApp.ApplicationLayer.Interfaces.StructuralServices;
using BankTimeApp.FrontEnd.ViewModels;
using BankTimeApp.Infrastructure.Persistence.Context;
using BankTimeApp.Infrastructure.Persistence.Services;
using BankTimeApp.Infrastructure.Shared.StructuralImplementations;
using BankTimeApp.StartUp.ServiceCollection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;

namespace BankTimeApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Dependency injection de los servicios y configuracion de la app
        //https://marcominerva.wordpress.com/2019/03/06/using-net-core-3-0-dependency-injection-and-service-provider-with-wpf/
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            IServiceProvider serviceProvider = CreateServiceProvider();
            
            ICategoryService service = serviceProvider.GetRequiredService<ICategoryService>();
            Window window = new MainWindow();
            window.DataContext = serviceProvider.GetRequiredService<MainWindowViewModel>();
            window.Show();


        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationDatabase(Configuration);
            services.AddIdentityDatabase(Configuration);
 

            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
          


        }
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<ApplicationDbContextFactory>();

            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MainWindowViewModel>();
            services.AddScoped<LoginViewModel>();


            return services.BuildServiceProvider();


        }

    }
}
