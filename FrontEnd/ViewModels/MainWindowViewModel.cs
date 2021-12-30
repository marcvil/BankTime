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
           
        }

        private ApplicationMainUserControl CurrentMainUserControlEVM = ApplicationMainUserControl.Login;
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

        public ICommand ChangeToSchoolNewsEVCommand { get; set; }

        public void ChangeToSchoolNewsViewEV()
        {

            var x = service.GetById(1);
            currentMainUserControlEVM = ApplicationMainUserControl.MainView;


        }

      
    }

}
