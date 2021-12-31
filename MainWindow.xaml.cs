using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
using BankTimeApp.ApplicationLayer.Interfaces.StructuralServices;
using BankTimeApp.Domain.Entities;
using BankTimeApp.FrontEnd.Pages;
using BankTimeApp.FrontEnd.ViewModels;
using BankTimeApp.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankTimeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow(object dataContext)
        {
            InitializeComponent();
            this.DataContext = dataContext;
        }

       
    }
}
