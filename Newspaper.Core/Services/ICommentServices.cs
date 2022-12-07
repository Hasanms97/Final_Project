using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Core.Services
{
    public interface ICommentServices
    {
        bool CreateNewComment(Commentt comment);
        bool UpdateComment(Commentt comment);
        bool DeleteComment(int id);


        int GetAllNumberOfComments(int newsId);
        News GetCommentById(int id);
        Task<List<Commentt>> GetAllNewsComments(int id);
        List<Commentt> GetAllUsersComments(int userId);
    }
}
