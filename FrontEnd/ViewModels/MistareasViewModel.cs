using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
using BankTimeApp.Domain.DTOs;
using BankTimeApp.Domain.Entities;
using BankTimeApp.FrontEnd.Commands;
using BankTimeApp.FrontEnd.ViewModels.Base;
using BankTimeApp.Infrastructure.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using static BankTimeApp.Domain.Enums.Enums;

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

        private List<ExchangeListDTO> ExchangeListVM;
        public List<ExchangeListDTO> exchangeListVM { get { return ExchangeListVM; } set { ExchangeListVM = value; OnPropertyChanged(); } }

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
                notifier.ShowError(exchangeList.Errors.First());
                return;
            }
            exchangeListVM = exchangeList.Data.Select(x => new ExchangeListDTO { Id= x.Id,Hours = x.TimeToCompleteTask, UserCreated = x.UserCreated, UserAsigned = x.UserAssigned, IdTareaRelacionada = x.Task.Id, TareaRelacionadaName= x.Task.Name }).ToList();
        }

        public ICommand AsignarTareaCommand { get; set; }

        public void AsignarTarea()
        {
            var idExchange = exchangeService.GetById(idTareaAsignarVM);
            if (!idExchange.Succeeded)
            {
                notifier.ShowError(idExchange.Errors.First());
                return;
            }

            var exchange = idExchange.Data;
            var task = exchange.Task;
            exchange.UserAssigned = UsuarioAsignarVM;
            task.State = (int)TaskState.InProcess;

            exchangeService.Update(exchange);
            taskService.Update(task);
            notifier.ShowSuccess("Tarea asignada");
        }

        public ICommand CerrarTareaCommand { get; set; }

        public void CerrarTarea()
        {
            var idExchange = exchangeService.GetById(idTareaCerrarVM);
            if (!idExchange.Succeeded)
            {
                notifier.ShowError(idExchange.Errors.First());
                return;
            }

            var exchange = idExchange.Data;
            var task = exchange.Task;
            task.State = (int)TaskState.Completed;

            taskService.Update(task);
            notifier.ShowSuccess("Tarea cerrada correctamente");
        }

        public ICommand BuscarUserBalanceCommand { get; set; }

        public void BuscarUserBalance()
        {
            var exchangeList = exchangeService.GetAll();
            if (exchangeList.Succeeded == false)
            {
                return;
            }

            var horasfavorList = exchangeList.Data.Where(x => x.UserAssigned == UsuarioBuscarVM && x.Task.State == (int)TaskState.Completed).ToList();
            var horasContraList = exchangeList.Data.Where(x => x.UserCreated == UsuarioBuscarVM && x.Task.State == (int)TaskState.Completed).ToList();

            int horasFavor = 0;
            foreach (var exchange in horasfavorList)
            {
                horasFavor += exchange.TimeToCompleteTask;
            }

            int horasContra = 0;
            foreach (var exchange in horasContraList)
            {
                horasContra += exchange.TimeToCompleteTask;
            }

            int BalanceTotal = horasFavor - horasContra;

            horasFavorVM = horasFavor.ToString();
            horasContraVM = horasContra.ToString();
            balanceTotalVM = BalanceTotal.ToString();
        }
        #endregion

        #region Notifications
        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });
        #endregion
    }


}
