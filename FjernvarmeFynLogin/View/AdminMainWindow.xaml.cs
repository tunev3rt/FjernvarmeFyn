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
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        private FeedbackViewModel fvm;

        public AdminMainWindow()
        {
            InitializeComponent();
            fvm = new FeedbackViewModel();
            DataContext = fvm;
        }

        private void unansweredTickets_MouseDown(object sender, MouseButtonEventArgs e) // Åbner nyt vindue med ubesvarede tickets
        {
            new UnansweredTicketsWindow().Show();
        }

        private void ongoingTickets_MouseDown(object sender, MouseButtonEventArgs e) // Åbner nyt vindue med igangværende tickets
        {
            new OngoingTicketsWindow().Show();
        }

        private void solvedTickets_MouseDown(object sender, MouseButtonEventArgs e) // Åbner nyt vindue med løste tickets
        {
            new SolvedTicketsWindow().Show();
        }
    }
}
