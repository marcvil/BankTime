﻿using BankTimeApp.FrontEnd.ViewModels;
using System.Windows.Controls;

namespace BankTimeApp.FrontEnd.Pages
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }
}
