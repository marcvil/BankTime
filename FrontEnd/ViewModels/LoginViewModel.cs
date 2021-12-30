﻿using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
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
        private ICategoryService service;
        public LoginViewModel(ICategoryService service)
        {
            this.service = service;

            ChangeToNewsEVCommand = new RouteCommand(ChangeToNewsViewEV);
        }
        public ICommand ChangeToNewsEVCommand { get; set; }

        public void ChangeToNewsViewEV()
        {

            var x = service.GetById(1);
            var y = service.GetById(2);
            var z = service.GetById(3);


        }


    }
}
