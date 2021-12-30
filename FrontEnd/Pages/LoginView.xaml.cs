using BankTimeApp.Domain.Entities;
using BankTimeApp.FrontEnd.ViewModels;
using BankTimeApp.Infrastructure.Persistence.Services;
using BankTimeApp.Infrastructure.Shared.StructuralImplementations;
using System.Windows;
using System.Windows.Controls;

namespace BankTimeApp.FrontEnd.Pages
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
          
        }

        private void btn_Click(object sender, RoutedEventArgs e)
{
            var category = new Category()
            {
                Name = "Category2"
            };

        }
        private void btn_Click2(object sender, RoutedEventArgs e)
        {


        }

        private void btn_ToLogin(object sender, RoutedEventArgs e)
        {

        }
    }
}
