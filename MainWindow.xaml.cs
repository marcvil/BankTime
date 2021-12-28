using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
using BankTimeApp.ApplicationLayer.Interfaces.StructuralServices;
using BankTimeApp.Domain.Entities;
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
        private readonly ICategoryService categoryService;
        private readonly IUnitOfWork unitOfWork;

        public MainWindow(ICategoryService categoryService, IUnitOfWork unitOfWork)
        {
         
            InitializeComponent();
            this.categoryService = categoryService;
            this.unitOfWork = unitOfWork;

        }

       

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            
            var category = new Category()
            {
                Name = "Category1"
            };

            categoryService.Post(category);
            unitOfWork.CompleteAsync();




        }
        private void btn_Click2(object sender, RoutedEventArgs e)
        {

            var x = categoryService.GetById(1);
            Console.WriteLine("hi");
          




        }
    }
}
