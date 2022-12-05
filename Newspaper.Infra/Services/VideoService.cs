using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;

namespace Newspaper.Infra.Services
{
	public class VideoService : IVideoService
	{
        private readonly IVideoRepository videoRepository;

		public VideoService(IVideoRepository videoRepository)
		{
            this.videoRepository = videoRepository;
        }

        public bool CreateNewVideo(Video video)
        {
            return videoRepository.CreateNewVideo(video);
        }

        public bool DeleteVideo(int id)
        {
            return videoRepository.DeleteVideo(id);
        }

        public List<Video> GetAllVideo()
        {
            return videoRepository.GetAllVideo();
        }

        public Video GetVideoById(int id)
        {
            return videoRepository.GetVideoById(id);
        }

        public List<Video> GetViedosByPageId(int id)
        {
            return videoRepository.GetViedosByPageId(id);
        }

        public bool UpdateVideo(Video video)
        {
            return videoRepository.UpdateVideo(video);
        }
    }
}

