using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
using BankTimeApp.FrontEnd.Commands;
using BankTimeApp.FrontEnd.Navigation;
using BankTimeApp.FrontEnd.ViewModels.Base;
using BankTimeApp.Infrastructure.Identity;
using BankTimeApp.Infrastructure.Identity.Context;
using BankTimeApp.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading;
using System.Windows.Input;

namespace BankTimeApp.FrontEnd.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {

            ChangeToBancoTiempoCommand = new RouteCommand(ChangeToBancoTiempoView);
            ChangeToMisTareasCommand = new RouteCommand(ChangeToMisTareasView);
            RegisterButtonCommand = new RouteCommand(Register);
            LoginButtonCommand = new RouteCommand(Login);
         
        }

        #region MainUser COntrol
        private ApplicationMainUserControl CurrentMainUserControl = ApplicationMainUserControl.Main;
        public ApplicationMainUserControl currentMainUserControl
        {
            get
            {
                return CurrentMainUserControl;
            }
            set
            {
                CurrentMainUserControl = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Visibility
        private bool BancoTiempoButtonVisibilityVM = false;
        public bool bancoTiempoButtonVisibilityVM { get { return BancoTiempoButtonVisibilityVM; } set { BancoTiempoButtonVisibilityVM = value; OnPropertyChanged(); } }

        private bool MisTareasButtonVisibilityVM = false;
        public bool misTareasButtonVisibilityVM { get { return MisTareasButtonVisibilityVM; } set { MisTareasButtonVisibilityVM = value; OnPropertyChanged(); } }
       
        #endregion
        #region Navigation
        public ICommand ChangeToBancoTiempoCommand { get; set; }

        public void ChangeToBancoTiempoView() { currentMainUserControl = ApplicationMainUserControl.BancoTiempo; }
        
        public ICommand ChangeToMisTareasCommand { get; set; }
        public void ChangeToMisTareasView() { currentMainUserControl = ApplicationMainUserControl.MisTareas; }

        #endregion

        #region Properties
        private string UserNameLoginVM;
        public string userNameLoginVM { get { return UserNameLoginVM; } set { UserNameLoginVM = value; OnPropertyChanged(); } }


        private string PasswordLoginVM;
        public string passwordLoginVM { get { return PasswordLoginVM; } set { PasswordLoginVM = value; OnPropertyChanged(); } }

        private string UserNameRegisterVM;
        public string userNameRegisterVM { get { return UserNameRegisterVM; } set { UserNameRegisterVM = value; OnPropertyChanged(); } }


        private string PasswordRegisterVM;
        public string passwordRegisterVM { get { return PasswordRegisterVM; } set { PasswordRegisterVM = value; OnPropertyChanged(); } }



        #endregion

        #region Commands
        public ICommand LoginButtonCommand { get; set; }

        public void Login()
        {
            bancoTiempoButtonVisibilityVM = true;
            misTareasButtonVisibilityVM = true;
            currentMainUserControl = ApplicationMainUserControl.BancoTiempo;
        }

        public ICommand RegisterButtonCommand { get; set; }


        public void Register()
        {

        }
        #endregion


    }

}
