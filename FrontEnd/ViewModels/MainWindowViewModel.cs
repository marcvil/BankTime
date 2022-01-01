using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
using BankTimeApp.FrontEnd.Commands;
using BankTimeApp.FrontEnd.Navigation;
using BankTimeApp.FrontEnd.ViewModels.Base;
using System.Windows.Input;

namespace BankTimeApp.FrontEnd.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ICategoryService service;

        public MainWindowViewModel(ICategoryService service)
        {
            this.service = service;



            ChangeToSchoolNewsEVCommand = new RouteCommand(ChangeToSchoolNewsViewEV);
            ChangeToNewsEVCommand = new RouteCommand(ChangeToNewsViewEV);
           
        }

        private ApplicationMainUserControl CurrentMainUserControlEVM = ApplicationMainUserControl.Main;
        public ApplicationMainUserControl currentMainUserControlEVM
        {
            get
            {
                return CurrentMainUserControlEVM;
            }
            set
            {
                CurrentMainUserControlEVM = value;
                OnPropertyChanged();
            }
        }

        private bool ButtonVisibilityVM;
        public bool buttonVisibilityVM { get { return ButtonVisibilityVM; } set { ButtonVisibilityVM = value; OnPropertyChanged(); } }

        public ICommand ChangeToSchoolNewsEVCommand { get; set; }

        public void ChangeToSchoolNewsViewEV()
        {

            var x = service.GetById(1);
            currentMainUserControlEVM = ApplicationMainUserControl.MainView;
            


        }
        public ICommand ChangeToNewsEVCommand { get; set; }
        public void ChangeToNewsViewEV()
        {
            currentMainUserControlEVM = ApplicationMainUserControl.Login;
            buttonVisibilityVM = true;
      


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
