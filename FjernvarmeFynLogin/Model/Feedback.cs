using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FjernvarmeFynLogin.Model
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public string FeedbackType { get; set; }
        public DateTime FormattedDate { get; set; }
        public int PriorityLevel { get; set; }
        public int InternalSystem { get; set; }
        public string DescriptiveText { get; set; }
        public string FeedbackStatus { get; set; } = "Unanswered";
        public SolidColorBrush PriorityColor => GetPriorityColor();

        public Feedback() 
        {
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
}
