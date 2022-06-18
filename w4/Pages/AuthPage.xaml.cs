﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace w4.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void BtUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserServicePage());
        }

        private void btPass_Click(object sender, RoutedEventArgs e)
        {
            if(textAdmin.Text == "0000")
            {
                NavigationService.Navigate(new ServiceAdminPage());
            }
            else
            {
                MessageBox.Show("неверный код доступа");
            }
        }
    }
}
