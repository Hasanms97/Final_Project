using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Core.Repository
{
    public interface IAdvertisementRepository
    {
        Task<List<User>> GetAllAdvertisement();
        Task<List<User>> GetAdvertisementById(int id);
        Task<List<User>> GetAdvertisementByUserId(int id);
        Task<List<User>> GetAdvertisementByNeedToApproveTheAds();
        Task<List<User>> GetAdvertisementByNeedToApprovalToPay();
        Task<List<User>> GetAdvertisementEffectiveAds();

        Task<List<User>> GetAdvertisementByYear(int year);
        Task<List<User>> GetAdvertisementByMonth(DateTime date);
        Task<List<User>> GetAllAdvertisementBySearchBetweenTwoDates(SearchBetweenTwoDatesDTO searchBetweenTwoDatesDTO);

        bool CreateNewAdvertisement(Advertisement advertisement);

        bool UpdateAdvertisement(Advertisement advertisement);
        bool DeleteAdvertisement(int id);
        bool ApprovalOrRejectionCheckAdminOnAds(Advertisement advertisement);
        bool ApprovalOrRejectionCheckAdminOnPay(Advertisement advertisement);
    }
}
