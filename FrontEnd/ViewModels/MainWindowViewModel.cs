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
        public SignInManager<ApplicationUser> UserManager { get; }
        public MainWindowViewModel(SignInManager<ApplicationUser> userManager)
        {

            ChangeToBancoTiempoCommand = new RouteCommand(ChangeToBancoTiempoView);
            ChangeToMisTareasCommand = new RouteCommand(ChangeToMisTareasView);
            RegisterButtonCommand = new RouteCommand(Register);
            LoginButtonCommand = new RouteCommand(Login);
            UserManager = userManager;
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
        private bool BancoTiempoButtonVisibilityVM;
        public bool bancoTiempoButtonVisibilityVM { get { return BancoTiempoButtonVisibilityVM; } set { BancoTiempoButtonVisibilityVM = value; OnPropertyChanged(); } }

        private bool MisTareasButtonVisibilityVM;
        public bool misTareasButtonVisibilityVM { get { return MisTareasButtonVisibilityVM; } set { MisTareasButtonVisibilityVM = value; OnPropertyChanged(); } }
       
        #endregion
        #region Navigation
        public ICommand ChangeToBancoTiempoCommand { get; set; }

        public void ChangeToBancoTiempoView() { currentMainUserControl = ApplicationMainUserControl.BancoTiempo; }
        
        public ICommand ChangeToMisTareasCommand { get; set; }
        public void ChangeToMisTareasView() { currentMainUserControl = ApplicationMainUserControl.MisTareas; }

        #endregion

        #region Properties
        private string UserNameVM;
        public string userNameVM { get { return UserNameVM; } set { UserNameVM = value; OnPropertyChanged(); } }


        private string PasswordVM;
        public string passwordVM { get { return PasswordVM; } set { PasswordVM = value; OnPropertyChanged(); } }


        private string TestVM = "HIII";
        public string testVM { get { return TestVM; } set { testVM = value; OnPropertyChanged(); } }
        #endregion

        #region Commands
        public ICommand LoginButtonCommand { get; set; }

        public void Login()
        {

           using(var db = new ApplicationDbContextFactory().CreateDbContext()) {
            
    
            }
            Thread.Sleep(3000);
        }

        public ICommand RegisterButtonCommand { get; set; }


        public void Register()
        {

        }
        #endregion


    }

}
