using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
using BankTimeApp.FrontEnd.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTimeApp.FrontEnd.ViewModels
{
    class MainViewModel
    {
        private MainView mainView;
        private ICategoryService categoryService;

        public MainViewModel(MainView mainView, ICategoryService categoryService)
        {
            this.mainView = mainView;
            this.categoryService = categoryService;
        }
    }

}
