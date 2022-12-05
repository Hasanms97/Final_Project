using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Core.Services
{
    public  interface ILikeDisLikeServices
    {
        bool CreateNewLikeDisLike(LikeDislike like);
        bool UpdateLikeDisLike(LikeDislike like);
        bool DeleteLikeDisLike(int id);
        int GetNumberOfLike(int newsId);
        int GetNumberOfDisLike(int newsId);

        LikeDislike GetLikeById(int id);
        string CheckUserLikeOrDisLike(int newsId, int userId);
        List<LikeDislike> GetAllUserLikeDislike(int userId);


    }
}
