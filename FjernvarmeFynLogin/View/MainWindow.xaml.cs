﻿using FjernvarmeFynLogin.View;
using FjernvarmeFynLogin.Viewmodel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FjernvarmeFynLogin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mvm = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void createUserBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateUserWindow createUserWindow = new CreateUserWindow();
            if (createUserWindow.ShowDialog() == true)
            {
                mvm.AddUser(createUserWindow.Name, createUserWindow.Department, createUserWindow.Email, createUserWindow.Password);
            }
        }

        private void logInBtn_Click(object sender, RoutedEventArgs e)
        {
            LogInWindow logInWindow = new LogInWindow();
            logInWindow.Show();
        }
    }
}