using FjernvarmeFynLogin.Viewmodel;
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
    /// Interaction logic for SubmitBugWindow.xaml
    /// </summary>
    public partial class SubmitBugWindow : Window
    {
        CreateTicketViewModel ctvm = new CreateTicketViewModel();
        public SubmitBugWindow(string currentUserEmail)
        {
            InitializeComponent();
            DataContext = ctvm;
            ctvm.FeedbackTypeProp = "Fejlmelding";
            ctvm.EmployeeEmailProp = currentUserEmail;
            ctvm.CloseWindowAction = () => this.Close();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void High_Checked(object sender, RoutedEventArgs e)
        {
            ctvm.PriorityLevelProp = 1;
        }

        private void Medium_Checked(object sender, RoutedEventArgs e)
        {
            ctvm.PriorityLevelProp = 2;
        }

        private void Low_Checked(object sender, RoutedEventArgs e)
        {
            ctvm.PriorityLevelProp = 3;
        }

        private void userInputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textLength.Content = $"{userInputTextBox.Text.Length.ToString()}/500";
        }
    }
}
