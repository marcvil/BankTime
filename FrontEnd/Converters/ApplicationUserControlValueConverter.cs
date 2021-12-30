﻿using BankTimeApp.FrontEnd.Navigation;
using BankTimeApp.FrontEnd.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace BankTimeApp.FrontEnd.Converters
{
    public class ApplicationUserControlValueConverter : BaseValueConverter<ApplicationUserControlValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationMainUserControl)value)
            {
                case ApplicationMainUserControl.Login:
                    return new LoginView();
                case ApplicationMainUserControl.MainView:
                    return new MainView();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}