using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
using BankTimeApp.ApplicationLayer.Interfaces.StructuralServices;
using BankTimeApp.FrontEnd.Commands;
using BankTimeApp.FrontEnd.Pages;
using BankTimeApp.FrontEnd.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BankTimeApp.FrontEnd.ViewModels
{
    public class LoginViewModel :ViewModelBase
    {
        private ICategoryService service ;

        public LoginViewModel(ICategoryService service)
        {
            this.service = service;

            LoginButtonCommand = new RouteCommand(Login);
          
        }

        #region Properties
        private string UserNameVM;
        public string userNameVM { get { return UserNameVM; } set { UserNameVM = value; OnPropertyChanged(); } }


        private string PasswordVM;
        public string passwordVM { get { return PasswordVM; } set { PasswordVM = value; OnPropertyChanged(); } }

        #endregion

        #region Commands
        public ICommand LoginButtonCommand { get; set; }

        public void Login()
        {
         
        }
        #endregion

    }
}
