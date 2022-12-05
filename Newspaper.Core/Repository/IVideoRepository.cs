using System;
using Newspaper.Core.Data;
using System.Collections.Generic;

namespace Newspaper.Core.Repository
{
	public interface IVideoRepository
	{
        List<Video> GetAllVideo();
        List<Video> GetViedosByPageId(int id);

        Video GetVideoById(int id);
        bool CreateNewVideo(Video video);
        bool UpdateVideo(Video video);
        bool DeleteVideo(int id);
    }
}

