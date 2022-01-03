using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
using BankTimeApp.Domain.DTOs;
using BankTimeApp.Domain.Entities;
using BankTimeApp.FrontEnd.Commands;
using BankTimeApp.FrontEnd.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using static BankTimeApp.Domain.Enums.Enums;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using System.Windows;
using ToastNotifications.Messages;

namespace BankTimeApp.FrontEnd.ViewModels
{
    public class BancoTiempoViewModel : ViewModelBase
    {
        private ITasksService taskService;
        private ICategoryService categoryService;
        private IExchangeService exchangeService;

        public BancoTiempoViewModel(ITasksService taskService, ICategoryService categoryService, IExchangeService exchangeService)
        {
            this.taskService = taskService;
            this.categoryService = categoryService;
            this.exchangeService = exchangeService;
            
            GetTasksCommand = new RouteCommand(GetAllTasks);
            InsertTaskCommand = new RouteCommand(InsertTask);
            GetCategoriesCommand = new RouteCommand(GetAllCategories);
            InsertCategoryCommand = new RouteCommand(InsertCategory);
  
        }


        #region Properties

        private string TaskNameVM;
        public string taskNameVM { get { return TaskNameVM; } set { TaskNameVM = value; OnPropertyChanged(); } }

        private string TaskUserCreatedVM;
        public string taskUserCreatedVM { get { return TaskUserCreatedVM; } set { TaskUserCreatedVM = value; OnPropertyChanged(); } }

      
        private int HoursExpectedVM;
        public int hoursExpectedVM { get { return HoursExpectedVM; } set { HoursExpectedVM = value; OnPropertyChanged(); } }


        private List<TaskListDTO> TasksListVM;
        public List<TaskListDTO> taskListVM { get { return TasksListVM; } set { TasksListVM = value; OnPropertyChanged(); } }


        private string CategoriaNameVM;
        public string categoriaNameVM { get { return CategoriaNameVM; } set { CategoriaNameVM = value; OnPropertyChanged(); } }

        private string CategoriaTaskNameVM;
        public string categoriaTaskNameVM { get { return CategoriaTaskNameVM; } set { CategoriaTaskNameVM = value; OnPropertyChanged(); } }

        private string CategoriaDescriptionVM;
        public string categoriaDescriptionVM { get { return CategoriaDescriptionVM; } set { CategoriaDescriptionVM = value; OnPropertyChanged(); } }

        private List<Category> CategoriaListVM;
        public List<Category> categoriaListVM { get { return CategoriaListVM; } set { CategoriaListVM = value; OnPropertyChanged(); } }
        #endregion

        #region Commands
        public ICommand GetTasksCommand { get; set; }

        public void GetAllTasks()
        {
            var taskList = taskService.GetAll();
            if(taskList.Succeeded == false)
            {
                notifier.ShowError(taskList.Message);

                return;
            }
            taskListVM = taskList.Data.Select(x=> new TaskListDTO { Id = x.Id, Name = x.Name, Hours = x.Exchange.TimeToCompleteTask, CategoryName= x.CategoryId.ToString(), StateName= x.State.ToString(),UserCreated = x.Exchange.UserCreated, UserAssigned = x.Exchange.UserAssigned }).ToList();
           
        }

        public ICommand InsertTaskCommand { get; set; }

        public void InsertTask()
        {
            var category = categoryService.GetByName(categoriaTaskNameVM);
            if (!category.Succeeded)
            {
                notifier.ShowError(category.Errors.First());
                return;
            }
              
            var newTask = new Tasks()
            {
                Name = taskNameVM,
                State = (int)TaskState.Open,
                CategoryId = category.Data.Id
            };
     
            var newExchange = new Exchanges()
            {
                TimeToCompleteTask = hoursExpectedVM,
                UserCreated = taskUserCreatedVM
            };

            var createTask = taskService.Post(newTask);
            var task = taskService.GetById(newTask.Id);
            newExchange.TaskId = newTask.Id;
            var createExchange = exchangeService.Post(newExchange);

            if (!createTask.Succeeded || !createExchange.Succeeded)
            {

                notifier.ShowError("Error al crear el elemento");
              
                return;
            }

            taskNameVM = String.Empty;
            hoursExpectedVM = 0;
            taskUserCreatedVM = String.Empty;
            notifier.ShowSuccess("Elemento creado correctamente");
            GetAllTasks();
            return;
        }


        public ICommand GetCategoriesCommand { get; set; }

        public void GetAllCategories()
        {
            var categoriesList = categoryService.GetAll();
            if (categoriesList.Succeeded == false)
            {
                notifier.ShowError(categoriesList.Errors.First());
                return;
            }
            categoriaListVM = categoriesList.Data;
        }

        public ICommand InsertCategoryCommand { get; set; }
        public void InsertCategory()
        {
            var category = new Category()
            {
                Name = categoriaNameVM,
                Description = categoriaDescriptionVM
            };
            var createcategory = categoryService.Post(category);

            if (createcategory.Succeeded)
            {
                categoriaNameVM = String.Empty;
                notifier.ShowSuccess("Elemento creado correctamente");
                GetAllCategories();
                return;
            }
            notifier.ShowError(createcategory.Errors.First());
            return;
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
