using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Infra.Services
{
    public class FeedbackServices : IFeedbackServices
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackServices(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public List<Feedback> GetAllFeedback() { return _feedbackRepository.GetAllFeedback(); }
        public Feedback GetFeedbackById(int id) { return _feedbackRepository.GetFeedbackById(id); }
        public bool CreateNewFeedback(Feedback feedback) { return _feedbackRepository.CreateNewFeedback(feedback); }
        public bool UpdateFeedback(Feedback feedback) { return _feedbackRepository.UpdateFeedback(feedback); }
        public bool DeleteFeedback(int id) { return _feedbackRepository.DeleteFeedback(id); }
        public List<Feedback> GetAllFeedbackUnderStudyOfAdmin() { return _feedbackRepository.GetAllFeedbackUnderStudyOfAdmin(); }
        public bool ApproveRejectFeedback(Feedback feedback) { return _feedbackRepository.ApproveRejectFeedback(feedback); }
    }
}
