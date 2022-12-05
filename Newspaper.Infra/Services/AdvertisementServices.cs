using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Infra.Services
{
    public class AdvertisementServices : IAdvertisementServices
    {
        private readonly IAdvertisementRepository _advertisementRepository;

        public AdvertisementServices(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }


        public Task<List<User>> GetAllAdvertisement()
        {
            return _advertisementRepository.GetAllAdvertisement();
        }

        public Task<List<User>> GetAdvertisementById(int id)
        {
            return _advertisementRepository.GetAdvertisementById(id);
        }

        public Task<List<User>> GetAdvertisementByUserId(int id)
        {
            return _advertisementRepository.GetAdvertisementByUserId(id);
        }
        public Task<List<User>> GetAdvertisementByNeedToApproveTheAds()
        {
            return _advertisementRepository.GetAdvertisementByNeedToApproveTheAds();
        }
        public Task<List<User>> GetAdvertisementByNeedToApprovalToPay()
        {
            return _advertisementRepository.GetAdvertisementByNeedToApprovalToPay();
        }
        public Task<List<User>> GetAdvertisementEffectiveAds()
        {
            return _advertisementRepository.GetAdvertisementEffectiveAds();
        }
        public Task<List<User>> GetAdvertisementByYear(int year)
        {
            return _advertisementRepository.GetAdvertisementByYear(year);
        }
        public Task<List<User>> GetAdvertisementByMonth(DateTime date)
        {
            return _advertisementRepository.GetAdvertisementByMonth(date);
        }
        public Task<List<User>> GetAllAdvertisementBySearchBetweenTwoDates(SearchBetweenTwoDatesDTO searchBetweenTwoDatesDTO)
        {
            return _advertisementRepository.GetAllAdvertisementBySearchBetweenTwoDates(searchBetweenTwoDatesDTO);
        }
        public bool CreateNewAdvertisement(Advertisement advertisement)
        {
            return _advertisementRepository.CreateNewAdvertisement(advertisement);
        }

        public bool UpdateAdvertisement(Advertisement advertisement)
        {
            return _advertisementRepository.UpdateAdvertisement(advertisement);
        }

        public bool DeleteAdvertisement(int id)
        {
            return _advertisementRepository.DeleteAdvertisement(id);
        }

        public bool ApprovalOrRejectionCheckAdminOnAds(Advertisement advertisement)
        {
            return _advertisementRepository.ApprovalOrRejectionCheckAdminOnAds(advertisement);
        }

        public bool ApprovalOrRejectionCheckAdminOnPay(Advertisement advertisement)
        {
            return _advertisementRepository.ApprovalOrRejectionCheckAdminOnPay(advertisement);
        }
    }
}
