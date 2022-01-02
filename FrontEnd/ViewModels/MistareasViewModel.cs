using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
using BankTimeApp.Domain.Entities;
using BankTimeApp.FrontEnd.Commands;
using BankTimeApp.FrontEnd.ViewModels.Base;
using BankTimeApp.Infrastructure.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace BankTimeApp.FrontEnd.ViewModels
{
    public class MistareasViewModel : ViewModelBase
    {
        private ITasksService taskService;
        private ICategoryService categoryService;
        private IExchangeService exchangeService;
        public MistareasViewModel(ITasksService taskService, ICategoryService categoryService, IExchangeService exchangeService)
        {
            this.taskService = taskService;
            this.categoryService = categoryService;
            this.exchangeService = exchangeService;



            GetExchangesCommand = new RouteCommand(GetAllExchanges);
            AsignarTareaCommand = new RouteCommand(AsignarTarea);
            CerrarTareaCommand = new RouteCommand(CerrarTarea);
            BuscarUserBalanceCommand = new RouteCommand(BuscarUserBalance);
          
        }

        #region Properties

        private List<Exchanges> ExchangeListVM;
        public List<Exchanges> exchangeListVM { get { return ExchangeListVM; } set { ExchangeListVM = value; OnPropertyChanged(); } }

        private int IdTareaAsignarVM;
        public int idTareaAsignarVM { get { return IdTareaAsignarVM; } set { IdTareaAsignarVM = value; OnPropertyChanged(); } }

        private string UsuarioAsignarVM;
        public string usuarioAsignarVM { get { return UsuarioAsignarVM; } set { UsuarioAsignarVM = value; OnPropertyChanged(); } }

        private int IdTareaCerrarVM;
        public int idTareaCerrarVM { get { return IdTareaCerrarVM; } set { IdTareaCerrarVM = value; OnPropertyChanged(); } }

        private string UsuarioBuscarVM;
        public string usuarioBuscarVM { get { return UsuarioBuscarVM; } set { UsuarioBuscarVM = value; OnPropertyChanged(); } }
        #endregion

        private string HorasFavorVM;
        public string horasFavorVM { get { return HorasFavorVM; } set { HorasFavorVM = value; OnPropertyChanged(); } }

        private string HorasContraVM;
        public string horasContraVM { get { return HorasContraVM; } set { HorasContraVM = value; OnPropertyChanged(); } }

        private string BalanceTotalVM;
        public string balanceTotalVM { get { return BalanceTotalVM; } set { BalanceTotalVM = value; OnPropertyChanged(); } }

        #region Commands
        public ICommand GetExchangesCommand { get; set; }

        public void GetAllExchanges()
        {
            var exchangeList = exchangeService.GetAll();
            if (exchangeList.Succeeded == false)
            {
                return;
            }
            //exchangeListVM = exchangeList.Data.Select(x => new TaskListDTO { Name = x.Name, CategoryName = x.CategoryId.ToString(), StateName = x.State.ToString() }).ToList();
        }

        public ICommand AsignarTareaCommand { get; set; }

        public void AsignarTarea()
        {
            //var taskList = taskService.GetAll();
            //if (taskList.Succeeded == false)
            //{
            //    return;
            //}
            //taskListVM = taskList.Data.Select(x => new TaskListDTO { Name = x.Name, CategoryName = x.CategoryId.ToString(), StateName = x.State.ToString() }).ToList();
        }

        public ICommand CerrarTareaCommand { get; set; }

        public void CerrarTarea()
        {
            //var taskList = taskService.GetAll();
            //if (taskList.Succeeded == false)
            //{
            //    return;
            //}
            //taskListVM = taskList.Data.Select(x => new TaskListDTO { Name = x.Name, CategoryName = x.CategoryId.ToString(), StateName = x.State.ToString() }).ToList();
        }

        public ICommand BuscarUserBalanceCommand { get; set; }

        public void BuscarUserBalance()
        {
            //var taskList = taskService.GetAll();
            //if (taskList.Succeeded == false)
            //{
            //    return;
            //}
            //taskListVM = taskList.Data.Select(x => new TaskListDTO { Name = x.Name, CategoryName = x.CategoryId.ToString(), StateName = x.State.ToString() }).ToList();
        }
        #endregion
    }


}
