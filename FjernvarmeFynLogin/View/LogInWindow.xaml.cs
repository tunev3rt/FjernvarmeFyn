using FjernvarmeFynLogin.Model;
using FjernvarmeFynLogin.Viewmodel;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace FjernvarmeFynLogin.View
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        UserViewModel uvm = new UserViewModel();
        public LogInWindow()
        {
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            //Temporay:
            AdminMainWindow adminMainWindow = new AdminMainWindow();
            adminMainWindow.Show();
            this.Close();
            //if (File.Exists("Users.txt"))
            //    uvm.LogIn(emailTB.Text, passwordTB.Password);
            //else
            //    MessageBox.Show("Der er ingen registrerede brugere i systemet.\nOpret venligst en bruger");
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
