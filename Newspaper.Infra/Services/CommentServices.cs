using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using Newspaper.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Infra.Services
{
    public class CommentServices : ICommentServices
    {

        private readonly ICommentRepository commentRepository;

        public CommentServices(ICommentRepository _commentRepository)
        {
            commentRepository = _commentRepository;
        }


        public bool CreateNewComment(Commentt comment)
        {
            return commentRepository.CreateNewComment(comment);
        }
        public bool UpdateComment(Commentt comment)
        {
            return commentRepository.UpdateComment(comment);
        }
        public bool DeleteComment(int id)
        {
            return commentRepository.DeleteComment(id);
        }


        public int GetAllNumberOfComments(int id)
        {
            return commentRepository.GetAllNumberOfComments(id);

        }
        public News GetCommentById(int id)
        {

            return commentRepository.GetCommentById(id);
        }
        public Task<List<Commentt>> GetAllNewsComments(int id)
        {
            return commentRepository.GetAllNewsComments(id);
        }
        public List<Commentt> GetAllUsersComments(int userId)
        {
            return commentRepository.GetAllUsersComments(userId);
        }

    }
}
