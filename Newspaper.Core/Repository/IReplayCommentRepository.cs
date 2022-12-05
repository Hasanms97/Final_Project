using System;
using Newspaper.Core.Data;
using System.Collections.Generic;

namespace Newspaper.Core.Repository
{
	public interface IReplayCommentRepository
	{
        List<Replycommentt> GetAllReplayComment();
        Replycommentt GetReplayCommentById(int id);
        bool CreateNewReplayComment(Replycommentt replycommentt);
        bool UpdateReplayComment(Replycommentt replycommentt);
        bool DeleteReplayComment(int id);

        //for GetAllReplayCommentOnComment(p_ID in REPLYCOMMENTT.COMMENTTID%type)
        List<Replycommentt> GetAllReplayCommentOnComment(int id);
    }
}

