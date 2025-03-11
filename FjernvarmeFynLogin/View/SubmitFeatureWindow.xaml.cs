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
    /// Interaction logic for SubmitFeatureWindow.xaml
    /// </summary>
    public partial class SubmitFeatureWindow : Window
    {
        CreateTicketViewModel ctvm = new CreateTicketViewModel();
        public SubmitFeatureWindow()
        {
            InitializeComponent();
            DataContext = ctvm;
            ctvm.FeedbackTypeProp = "Feature";
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
    }
}
