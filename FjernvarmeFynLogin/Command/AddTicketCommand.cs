using FjernvarmeFynLogin.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FjernvarmeFynLogin.Model;
using System.Windows;
using FjernvarmeFynLogin.View;

namespace FjernvarmeFynLogin.Command
{
    public class AddTicketCommand : ICommand
    {
        private readonly Action closeWindowAction;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public AddTicketCommand(Action closeWindowAction)
        {
            this.closeWindowAction = closeWindowAction;
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
                MessageBoxResult result = MessageBox.Show(
                "Er du helt sikker på at fortsætte og oprette ticket?",
                "Bekræft handling",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    Feedback feedback = new Feedback
                    {
                        FeedbackType = ctvm.FeedbackTypeProp,
                        FormattedDate = ctvm.FormattedDateProp,
                        PriorityLevel = ctvm.PriorityLevelProp,
                        InternalSystem = ctvm.InternalSystemProp,
                        DescriptiveText = ctvm.DescriptiveTextProp,
                        FeedbackStatus = ctvm.FeedbackStatusProp,
                        EmployeeEmail = ctvm.EmployeeEmailProp
                    };
                    ctvm.AddTicket(feedback);
                    TicketConfirmationWindow ticketConfirmInst = new TicketConfirmationWindow(new FeedbackViewModel { FeedbackId=feedback.FeedbackId});
                    ticketConfirmInst.ShowDialog();
                    closeWindowAction?.Invoke();
                }
            }
        }
    }
}
