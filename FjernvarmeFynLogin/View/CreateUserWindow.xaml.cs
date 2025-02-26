using System;
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
using System.Windows.Shapes;

namespace FjernvarmeFynLogin.View
{
    /// <summary>
    /// Interaction logic for CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        public CreateUserWindow()
        {
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (createPassPB.Password == confirmPassPB.Password)
            {
                MessageBoxResult result = MessageBox.Show("Bruger oprettet i systemet");
                if (result == MessageBoxResult.OK)
                DialogResult = true;
            }
            else
                MessageBox.Show("De indtastede passwords matcher ikke. Prøv igen");
        }

        public string Name
        {
            get { return fullNameTB.Text; }
        }
        public string Department
        {
            get { return departmentTB.Text; }
        }
        public string Email
        {
            get { return emailTB.Text; }
        }
        public string Password
        {
            get { return createPassPB.Password; }
        }

        private void confirmPassPB_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (fullNameTB.Text.Length > 0 && departmentTB.Text.Length > 0 && emailTB.Text.Length > 0 && createPassPB.Password.Length > 0 && confirmPassPB.Password.Length > 0)
            {
                confirmBtn.IsEnabled = true;
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
