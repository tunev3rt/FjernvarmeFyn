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
    /// Interaction logic for TicketConfirmationWindow.xaml
    /// </summary>
    public partial class TicketConfirmationWindow : Window
    {
        
        public TicketConfirmationWindow(FeedbackViewModel feedbackVM)
        {
            InitializeComponent();
            DataContext = feedbackVM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
