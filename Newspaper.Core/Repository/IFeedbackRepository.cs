using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Core.Repository
{
    public interface IFeedbackRepository
    {
        List<Feedback> GetAllFeedback();
        Feedback GetFeedbackById(int id);
        bool CreateNewFeedback(Feedback feedback);
        bool UpdateFeedback(Feedback feedback);
        bool DeleteFeedback(int id);
        List<Feedback> GetAllFeedbackUnderStudyOfAdmin();
        bool ApproveRejectFeedback(Feedback feedback);
    }
}
