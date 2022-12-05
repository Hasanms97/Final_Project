using System;
using Newspaper.Core.Data;
using System.Collections.Generic;

namespace Newspaper.Core.Services
{
	public interface IFollowService
	{
        List<Follow> GetAllFollow();
        Follow GetFollowById(int id);
        bool CreateNewFollow(Follow follow);
        bool UpdateFollow(Follow follow);
        bool DeleteFollow(int id);
        bool CheckFollowers(int p_UserID, int p_PressManID);
        int GetNumberOfFollowers(int p_PressManID);
    }
}

