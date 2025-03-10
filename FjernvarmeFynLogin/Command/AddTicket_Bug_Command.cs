using FjernvarmeFynLogin.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FjernvarmeFynLogin.Model;

namespace FjernvarmeFynLogin.Command
{
    public class AddTicket_Bug_Command : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }



        public bool CanExecute(object? parameter)
        {
            bool result = false;
            if (parameter is CreateTicketViewModel ctvm)
            {
                if (!string.IsNullOrEmpty(ctvm.DescriptiveTextProp))
                {
                    if (ctvm.PriorityLevelProp > 0 && ctvm.PriorityLevelProp <= 3 &&
                        ctvm.InternalSystemProp != 0)
                    {
                        result = true;
                    }
                }
                
            }
            return result;
        }



        public void Execute(object? parameter)
        {
            if (parameter is CreateTicketViewModel ctvm)
            {
                Feedback feedback = new Feedback
                {
                    FeedbackType = ctvm.FeedbackTypeProp_Bug,
                    FormattedDate = ctvm.FormattedDateProp,
                    PriorityLevel = ctvm.PriorityLevelProp,
                    InternalSystem = ctvm.InternalSystemProp,
                    DescriptiveText = ctvm.DescriptiveTextProp,
                    FeedbackStatus = ctvm.FeedbackStatusProp
                };
                ctvm.AddTicket(feedback);

            }
        }


    }
}
