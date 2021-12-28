using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
using BankTimeApp.ApplicationLayer.Interfaces.StructuralServices;
using BankTimeApp.Domain.Entities;
using BankTimeApp.Infrastructure.Persistence.Context;
using BankTimeApp.Infrastructure.Persistence.Repositories;
using BankTimeApp.Infrastructure.Shared.StructuralImplementations;
using BankTimeApp.StartUp.ServiceCollection;
using Microsoft.EntityFrameworkCore;
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
            var directory = "C:\\Users\\MarcVilà\\source\\repos\\BankTime";
            var builder = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();


        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationDatabase(Configuration);
            services.AddIdentityDatabase(Configuration);

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(MainWindow));

        
        }

    }
}
