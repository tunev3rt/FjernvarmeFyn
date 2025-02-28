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
        public ObservableCollection<FeedbackItem> FeedbackItems { get; set; }
        public SolvedTicketsWindow()
        {
            InitializeComponent();
            FeedbackItems = new ObservableCollection<FeedbackItem>
            {
                new FeedbackItem(1001, 1, "System navn", DateTime.Parse("2025-02-19")),
                new FeedbackItem(2113, 2, "System navn", DateTime.Parse("2025-02-19")),
                new FeedbackItem(1320, 1, "System navn", DateTime.Parse("2025-02-18")),
                new FeedbackItem(3243, 3, "System navn", DateTime.Parse("2025-02-18")),
                new FeedbackItem(3076, 3, "System navn", DateTime.Parse("2025-02-14")),
                new FeedbackItem(2466, 2, "System navn", DateTime.Parse("2025-02-13")),
            };
            DataContext = this;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

public class FeedbackItem
{
    public int FeedbackId { get; set; }
    public int PriorityLevel { get; set; }
    public string SystemName { get; set; }
    public DateTime Date { get; set; }
    public string FormattedDate => Date.ToString("dd/MM - yyyy");
    public SolidColorBrush PriorityColor => GetPriorityColor();

    public FeedbackItem(int id, int priority, string system, DateTime date)
    {
        FeedbackId = id;
        PriorityLevel = priority;
        SystemName = system;
        Date = date;
    }

    private SolidColorBrush GetPriorityColor()
    {
        return PriorityLevel switch
        {
            1 => new SolidColorBrush(Colors.Red),
            2 => new SolidColorBrush(Colors.Orange),
            3 => new SolidColorBrush(Colors.Green),
            _ => new SolidColorBrush(Colors.Gray),
        };
    }
}