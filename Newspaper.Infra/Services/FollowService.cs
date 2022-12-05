using System;
using System.Collections.Generic;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;

namespace Newspaper.Infra.Services
{
	public class FollowService : IFollowService
	{
        private readonly IFollowRepository followRepository;

		public FollowService(IFollowRepository followRepository)
		{
            this.followRepository = followRepository;
		}
        

        public bool CheckFollowers(int p_UserID, int p_PressManID)
        {
            return followRepository.CheckFollowers(p_UserID, p_PressManID);
        }

        public bool CreateNewFollow(Follow follow)
        {
            return followRepository.CreateNewFollow(follow);
        }

        public bool DeleteFollow(int id)
        {
            return followRepository.DeleteFollow(id);
        }

        public List<Follow> GetAllFollow()
        {
            return followRepository.GetAllFollow();
        }

        public Follow GetFollowById(int id)
        {
            return followRepository.GetFollowById(id);
        }


        public int GetNumberOfFollowers(int p_PressManID)
        {
            return followRepository.GetNumberOfFollowers(p_PressManID);
        }

        public bool UpdateFollow(Follow follow)
        {
            return followRepository.UpdateFollow(follow);
        }
    }
}

