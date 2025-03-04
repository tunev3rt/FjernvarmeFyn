using FjernvarmeFynLogin.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for TicketDetailsWindow.xaml
    /// </summary>
    public partial class TicketDetailsWindow : Window
    {
        public Feedback CurrentTicket { get; set; }
        public bool IsAccepted { get; set; } = false;
        public bool ToBeDeleted { get; set; } = false;
        public TicketDetailsWindow(Feedback ticket)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            CurrentTicket = ticket;
            DataContext = CurrentTicket;
            if (CurrentTicket.FeedbackStatus == "Accepted")
            {
                acceptBtn.Content = "Færdig";
            }
            else if (CurrentTicket.FeedbackStatus == "Solved")
            {
                acceptBtn.IsEnabled = false;
            }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTicket.FeedbackStatus == "Accepted")
            {
                CurrentTicket.FeedbackStatus = "Solved";
                IsAccepted = true;
                this.Close();
            }
            else if (CurrentTicket.FeedbackStatus == "Unanswered")
            {
                CurrentTicket.FeedbackStatus = "Accepted";
                IsAccepted = true;
                this.Close();
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ToBeDeleted = true;
            this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
