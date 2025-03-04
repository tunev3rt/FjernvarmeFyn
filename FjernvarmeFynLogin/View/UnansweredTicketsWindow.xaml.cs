using FjernvarmeFynLogin.Model;
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
    /// Interaction logic for UnansweredTicketsWindow.xaml
    /// </summary>
    public partial class UnansweredTicketsWindow : Window
    {
        public ObservableCollection<Feedback> FeedbackItems { get; set; }
        private List<Feedback> UnsortedFeedback;
        private FeedbackRepository feedbackRepository;
        public UnansweredTicketsWindow()
        {
            InitializeComponent();
            feedbackRepository = new FeedbackRepository();
            UnsortedFeedback = feedbackRepository.GetAll();
            FeedbackItems = new ObservableCollection<Feedback>(UnsortedFeedback.Where(f => f.FeedbackStatus == "Unanswered"));
            DataContext = this;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var selectedFeedback = (Feedback)e.AddedItems[0];
                var detailsWindow = new TicketDetailsWindow(selectedFeedback);
                detailsWindow.ShowDialog();
                if (detailsWindow.IsAccepted)
                {
                    feedbackRepository.Update(selectedFeedback);
                }
            }
        }
    }
}
