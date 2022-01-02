using BankTimeApp.FrontEnd.ViewModels;
using BankTimeApp.Infrastructure.Persistence.Context;
using BankTimeApp.Infrastructure.Persistence.Services;
using BankTimeApp.Infrastructure.Shared.StructuralImplementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankTimeApp.FrontEnd.Pages
{
    /// <summary>
    /// Interaction logic for BancoTiempo.xaml
    /// </summary>
    public partial class BancoTiempo : UserControl
    {
        public BancoTiempo()
        {
            InitializeComponent();
            var taskService = new TasksService(new ApplicationDbContextFactory(), new UnitOfWork());
            var categoryService = new CategoryService(new ApplicationDbContextFactory(), new UnitOfWork());
            var exchangesService = new ExchangesService(new ApplicationDbContextFactory(), new UnitOfWork());
            this.DataContext = new BancoTiempoViewModel(taskService, categoryService, exchangesService);
        }
    }
}
