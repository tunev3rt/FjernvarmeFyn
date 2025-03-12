using FjernvarmeFynLogin.Model;
using FjernvarmeFynLogin.Viewmodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SolvedTicketsWindow.xaml
    /// </summary>
    public partial class SolvedTicketsWindow : Window
    {
        FeedbackViewModel fvm = new FeedbackViewModel(3);
        public SolvedTicketsWindow()
        {
            InitializeComponent();
            DataContext = fvm;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AdminMainWindow adminMainWindow = new AdminMainWindow();
            adminMainWindow.Show();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var selectedFeedback = (FeedbackViewModel)e.AddedItems[0];
                var detailsWindow = new TicketDetailsWindow(selectedFeedback);
                detailsWindow.ShowDialog();
                if (detailsWindow.ToBeDeleted)
                {
                    fvm.FeedbackVM.Remove(selectedFeedback);
                    fvm.Delete(selectedFeedback);
                }
            }
        }
    }
}