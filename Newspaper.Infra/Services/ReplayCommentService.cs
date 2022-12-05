using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;

namespace Newspaper.Infra.Services
{
    public class ReplayCommentService : IReplayCommentService
    {
        private readonly IReplayCommentRepository replayCommentRepository;

        public ReplayCommentService(IReplayCommentRepository replayCommentRepository)
        {
            this.replayCommentRepository = replayCommentRepository;
        }

        public bool CreateNewReplayComment(Replycommentt replycommentt)
        {
            return replayCommentRepository.CreateNewReplayComment(replycommentt);
        }

        public bool DeleteReplayComment(int id)
        {
            return replayCommentRepository.DeleteReplayComment(id);
        }

        public List<Replycommentt> GetAllReplayComment()
        {
            return replayCommentRepository.GetAllReplayComment();
        }

        public List<Replycommentt> GetAllReplayCommentOnComment(int id)
        {
            return replayCommentRepository.GetAllReplayCommentOnComment(id);
        }

        public Replycommentt GetReplayCommentById(int id)
        {
            return replayCommentRepository.GetReplayCommentById(id);
        }

        public bool UpdateReplayComment(Replycommentt replycommentt)
        {
            return replayCommentRepository.UpdateReplayComment(replycommentt);
        }
    }
}

