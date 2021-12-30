﻿using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
using BankTimeApp.ApplicationLayer.Interfaces.StructuralServices;
using BankTimeApp.FrontEnd.Pages;
using BankTimeApp.FrontEnd.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTimeApp.FrontEnd.ViewModels
{
    public class LoginViewModel :ViewModelBase
    {
        private ICategoryService service;
        public LoginViewModel(ICategoryService service)
        {
            this.service = service;
        }

     
    }
}