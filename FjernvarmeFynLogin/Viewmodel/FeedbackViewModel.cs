using FjernvarmeFynLogin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FjernvarmeFynLogin.Viewmodel
{
    public class FeedbackViewModel
    {
        public Feedback feedback;
        private FeedbackRepository feedbackRepo = new FeedbackRepository();
        public int UnansweredTickets { get; set; } = 0;
        public int OngoingTickets { get; set; } = 0;
        public int SolvedTickets { get; set; } = 0;
        public int FeedbackId { get; set; }
        public string FeedbackType { get; set; }
        public DateTime FormattedDate { get; set; }
        public int PriorityLevel { get; set; }
        public int InternalSystem { get; set; }
        public string DescriptiveText { get; set; }
        public string FeedbackStatus { get; set; }
        public string EmployeeEmail { get; set; }
        public SolidColorBrush PriorityColor => GetPriorityColor();
        public ObservableCollection<FeedbackViewModel> FeedbackVM { get; set; }
        public void Update(FeedbackViewModel feedbackViewModel)
        {
            feedback = new Feedback
            {
                FeedbackId = feedbackViewModel.FeedbackId,
                FeedbackType = feedbackViewModel.FeedbackType,
                FormattedDate = feedbackViewModel.FormattedDate,
                PriorityLevel = feedbackViewModel.PriorityLevel,
                InternalSystem = feedbackViewModel.InternalSystem,
                DescriptiveText = feedbackViewModel.DescriptiveText,
                FeedbackStatus = feedbackViewModel.FeedbackStatus,
                EmployeeEmail = feedbackViewModel.EmployeeEmail
            };
            feedbackRepo.Update(feedback);
        }

        public void Delete(FeedbackViewModel feedbackViewModel)
        {
            feedback = new Feedback
            {
                FeedbackId = feedbackViewModel.FeedbackId
            };
            feedbackRepo.Delete(feedback);
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
        public FeedbackViewModel()
        {
            UnansweredTickets = feedbackRepo.GetAllUnanswered().Count;
            OngoingTickets = feedbackRepo.GetAllAccepted().Count;
            SolvedTickets = feedbackRepo.GetAllSolved().Count;

        }
        public FeedbackViewModel(int window)
        {
            FeedbackVM = new ObservableCollection<FeedbackViewModel>();
            if (window == 1)
            {
                foreach (var feedback in feedbackRepo.GetAllUnanswered())
                {
                    FeedbackViewModel feedbackViewModel = new FeedbackViewModel(feedback);
                    FeedbackVM.Add(feedbackViewModel);
                }
            }
            if (window == 2)
            {
                foreach (var feedback in feedbackRepo.GetAllAccepted())
                {
                    FeedbackViewModel feedbackViewModel = new FeedbackViewModel(feedback);
                    FeedbackVM.Add(feedbackViewModel);
                }
            }
            if (window == 3)
            {
                foreach (var feedback in feedbackRepo.GetAllSolved())
                {
                    FeedbackViewModel feedbackViewModel = new FeedbackViewModel(feedback);
                    FeedbackVM.Add(feedbackViewModel);
                }
            }
        }
        public FeedbackViewModel(string email)
        {
            FeedbackVM = new ObservableCollection<FeedbackViewModel>();
            foreach (var feedback in feedbackRepo.GetAllBySpecificEmail(email))
            {
                FeedbackViewModel feedbackViewModel = new FeedbackViewModel(feedback);
                FeedbackVM.Add(feedbackViewModel);
            }
        }
        public FeedbackViewModel(Feedback feedback)
        {
            this.feedback = feedback;
            FeedbackId = feedback.FeedbackId;
            FeedbackType = feedback.FeedbackType;
            FormattedDate = feedback.FormattedDate;
            PriorityLevel = feedback.PriorityLevel;
            InternalSystem = feedback.InternalSystem;
            DescriptiveText = feedback.DescriptiveText;
            FeedbackStatus = feedback.FeedbackStatus;
            EmployeeEmail = feedback.EmployeeEmail;
        }
    }
}
