using FjernvarmeFynLogin.Authentication;
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
            uvm.CloseWindowAction = () => this.Close();
            DataContext = uvm;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}