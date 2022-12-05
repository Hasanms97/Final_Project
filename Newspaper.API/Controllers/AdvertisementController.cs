using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementServices _advertisementServices;

        public AdvertisementController(IAdvertisementServices advertisementServices)
        {
            _advertisementServices = advertisementServices;
        }


        [HttpGet("GetAllAdvertisement")]
        public Task<List<User>> GetAllAdvertisement()
        {
            return _advertisementServices.GetAllAdvertisement();
        }

        [HttpGet("GetAdvertisementById/{id}")]
        public Task<List<User>> GetAdvertisementById(int id)
        {
            return _advertisementServices.GetAdvertisementById(id);
        }

        [HttpGet("GetAdvertisementByUserId/{id}")]
        public Task<List<User>> GetAdvertisementByUserId(int id)
        {
            return _advertisementServices.GetAdvertisementByUserId(id);
        }

        [HttpGet("GetAdvertisementByNeedToApproveTheAds")]
        public Task<List<User>> GetAdvertisementByNeedToApproveTheAds()
        {
            return _advertisementServices.GetAdvertisementByNeedToApproveTheAds();
        }

        [HttpGet("GetAdvertisementByNeedToApprovalToPay")]
        public Task<List<User>> GetAdvertisementByNeedToApprovalToPay()
        {
            return _advertisementServices.GetAdvertisementByNeedToApprovalToPay();
        }

        [HttpGet("GetAdvertisementEffectiveAds")]
        public Task<List<User>> GetAdvertisementEffectiveAds()
        {
            return _advertisementServices.GetAdvertisementEffectiveAds();
        }

        [HttpGet("GetAdvertisementByYear/{year}")]
        public Task<List<User>> GetAdvertisementByYear(int year)
        {
            return _advertisementServices.GetAdvertisementByYear(year);
        }

        [HttpGet("GetAdvertisementByMonth/{date}")]
        public Task<List<User>> GetAdvertisementByMonth(DateTime date)
        {
            return _advertisementServices.GetAdvertisementByMonth(date);
        }

        [HttpPost("GetAllAdvertisementBySearchBetweenTwoDates")]
        public Task<List<User>> GetAllAdvertisementBySearchBetweenTwoDates(SearchBetweenTwoDatesDTO searchBetweenTwoDatesDTO)
        {
            return _advertisementServices.GetAllAdvertisementBySearchBetweenTwoDates(searchBetweenTwoDatesDTO);
        }

        [HttpPost("CreateNewAdvertisement")]
        public bool CreateNewAdvertisement(Advertisement advertisement)
        {
            return _advertisementServices.CreateNewAdvertisement(advertisement);
        }

        [HttpPut("UpdateAdvertisement")]
        public bool UpdateAdvertisement(Advertisement advertisement)
        {
            return _advertisementServices.UpdateAdvertisement(advertisement);
        }

        [HttpDelete("DeleteAdvertisement/{id}")]
        public bool DeleteAdvertisement(int id)
        {
            return _advertisementServices.DeleteAdvertisement(id);
        }

        //P(Id,CheckAdminOnAds)
        [HttpPost("ApprovalOrRejectionCheckAdminOnAds")]
        public bool ApprovalOrRejectionCheckAdminOnAds(Advertisement advertisement)
        {
            return _advertisementServices.ApprovalOrRejectionCheckAdminOnAds(advertisement);
        }

        //P(Id,CheckAdminOnPay)
        [HttpPost("ApprovalOrRejectionCheckAdminOnPay")] 
        public bool ApprovalOrRejectionCheckAdminOnPay(Advertisement advertisement)
        {
            return _advertisementServices.ApprovalOrRejectionCheckAdminOnPay(advertisement);
        }

        [HttpPost("UploadImageAds")]
        public Advertisement UploadImageAds()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Files/Advertisement/Image/", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Advertisement ads = new Advertisement();
            ads.Imagepath = fileName;
            return ads;
        }

        [HttpPost("UploadVideoAds")]
        public Advertisement UploadVideoAds()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Files/Advertisement/Video/", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Advertisement ads = new Advertisement();
            ads.Videopath = fileName;
            return ads;
        }

    }
}
