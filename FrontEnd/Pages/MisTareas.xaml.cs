using BankTimeApp.FrontEnd.ViewModels;
using BankTimeApp.Infrastructure.Persistence.Context;
using BankTimeApp.Infrastructure.Persistence.Services;
using BankTimeApp.Infrastructure.Shared.StructuralImplementations;
using System.Windows.Controls;

namespace BankTimeApp.FrontEnd.Pages
{
    /// <summary>
    /// Interaction logic for MisTareas.xaml
    /// </summary>
    public partial class MisTareas : UserControl
    {
        public MisTareas()
        {
            InitializeComponent();
            var taskService = new TasksService(new ApplicationDbContextFactory(), new UnitOfWork());
            var categoryService = new CategoryService(new ApplicationDbContextFactory(), new UnitOfWork());
            var exchangesService = new ExchangesService(new ApplicationDbContextFactory(), new UnitOfWork());
            this.DataContext = new MistareasViewModel(taskService,categoryService,exchangesService);
        }
    }
}
