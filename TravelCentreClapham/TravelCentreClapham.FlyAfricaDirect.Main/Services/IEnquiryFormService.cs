using TravelCentreClapham.FlyAfricaDirect.Dal;
using TravelCentreClapham.FlyAfricaDirect.Dal.Models;

namespace TravelCentreClapham.FlyAfricaDirect.Main.Services
{
    public interface IEnquiryFormService
    {
        void Add(CustomerDto customer);
        bool CheckEmailExist(string email, PromotionGroupType promotionGroupType);
        void OptEmailOut(string email, PromotionGroupType promotionGroupType);
    }
}
