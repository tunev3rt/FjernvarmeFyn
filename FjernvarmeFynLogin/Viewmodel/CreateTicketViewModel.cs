using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FjernvarmeFynLogin.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FjernvarmeFynLogin.Command;


namespace FjernvarmeFynLogin.Viewmodel
{
    public class CreateTicketViewModel : INotifyPropertyChanged
    {
        private FeedbackRepository feedbackRepositoryInst = new FeedbackRepository();
        private Feedback feedbackInst;

        //Properties til DataBinding
        public string FeedbackTypeProp { get; set; }

        public DateTime FormattedDateProp { get; set; } = DateTime.Now;

        private int _priorityLevelProp;
        public int PriorityLevelProp
        {
            get { return _priorityLevelProp; }
            set
            {
                _priorityLevelProp = value;
                OnPropertyChanged(nameof(PriorityLevelProp));
            }
        }

        private int _internalSystemProp;
        public int InternalSystemProp
        {
            get => _internalSystemProp;
            set
            {
                _internalSystemProp = value;
                OnPropertyChanged(nameof(InternalSystemProp));
            }
        }

        private string _descriptiveTextProp;
        public string DescriptiveTextProp
        {
            get { return _descriptiveTextProp; }
            set { _descriptiveTextProp = value; }
        }

        public string FeedbackStatusProp { get; set; } = "Unanswered";

        //-------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------

        //Command-instanser som bliver sat til selve commanden inde i Command-mappen
        public ICommand AddTicketCommand { get; set; } = new AddTicketCommand();


        public void AddTicket(Feedback feedback)
        {
            feedbackRepositoryInst.Add(feedback);
        }



        //-------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------

        //PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));



        //Bare en liste til valg af system der vises i "vælg pågældende system"
        public ObservableCollection<int> ExampleSystemNumbers { get; set; }
        public CreateTicketViewModel()
        {
            ExampleSystemNumbers = new ObservableCollection<int>();
            for (int i = 1; i <= 10; i++)
            {
                ExampleSystemNumbers.Add(i);
            }
                InternalSystemProp = 1;
        }




















    }
}
