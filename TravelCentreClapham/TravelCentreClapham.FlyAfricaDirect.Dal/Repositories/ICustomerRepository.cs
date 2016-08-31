using NexusCore.Infrastructure.Data.EntityFramework;
using TravelCentreClapham.FlyAfricaDirect.Dal.Entities;

namespace TravelCentreClapham.FlyAfricaDirect.Dal.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetCustomerByEmail(string email, PromotionGroupType promotionGroupType);
        void UpdateCustomerOptStatus(string email, PromotionGroupType promotionGroupType, bool optStatus);
    }
}
