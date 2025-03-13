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
    /// Interaction logic for UserTicketDetailsWindow.xaml
    /// </summary>
    public partial class UserTicketDetailsWindow : Window
    {
        public FeedbackViewModel CurrentTicket;
        public UserTicketDetailsWindow(FeedbackViewModel ticket)
        {
            InitializeComponent();
            CurrentTicket = ticket;
            DataContext = CurrentTicket;

            if (CurrentTicket.FeedbackStatus == "Unanswered")
            {
                ticketStatusLabel.Content = "Ubesvaret";
                ticketStatusLabel.Foreground = new SolidColorBrush(Colors.Red);
            }
            else if (CurrentTicket.FeedbackStatus == "Accepted")
            {
                ticketStatusLabel.Content = "Igangværende";
                ticketStatusLabel.Foreground = new SolidColorBrush(Colors.Yellow);
            }
            else if (CurrentTicket.FeedbackStatus == "Solved")
            {
                ticketStatusLabel.Content = "Løst";
                ticketStatusLabel.Foreground = new SolidColorBrush(Colors.Green);
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
