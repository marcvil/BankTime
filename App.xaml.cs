using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
using BankTimeApp.ApplicationLayer.Interfaces.StructuralServices;
using BankTimeApp.FrontEnd.Pages;
using BankTimeApp.FrontEnd.ViewModels;
using BankTimeApp.Infrastructure.Identity;
using BankTimeApp.Infrastructure.Identity.Context;
using BankTimeApp.Infrastructure.Persistence.Context;
using BankTimeApp.Infrastructure.Persistence.Services;
using BankTimeApp.Infrastructure.Shared.StructuralImplementations;
using BankTimeApp.StartUp.ServiceCollection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.DataContext = serviceProvider.GetRequiredService<MainWindowViewModel>();
            window.Show();


        }

     
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
       
            services.AddSingleton<ApplicationDbContextFactory>();
            services.AddSingleton<IdentitytDbContextFactory>();
            services
              .AddIdentity<ApplicationUser, IdentityRole>(options =>
              {
                  // Password settings.  TODO - Change Settings for more robust security
                  options.Password.RequireDigit = false;
                  options.Password.RequireLowercase = false;
                  options.Password.RequireNonAlphanumeric = false;
                  options.Password.RequireUppercase = false;
                  options.Password.RequiredLength = 4;

              })
              .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddSignInManager<SignInManager<ApplicationUser>>()
               .AddDefaultTokenProviders(); 

            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MainWindowViewModel>();
            services.AddScoped<LoginViewModel>();

    


            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowViewModel>()));
          




            return services.BuildServiceProvider();


        }

    }
}
