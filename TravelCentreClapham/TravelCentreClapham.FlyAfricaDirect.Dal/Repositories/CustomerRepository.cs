using System.Linq;
using NexusCore.Infrastructure.Data.EntityFramework;
using TravelCentreClapham.FlyAfricaDirect.Dal.Entities;

namespace TravelCentreClapham.FlyAfricaDirect.Dal.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IContentContext contentContext) : base(contentContext)
        {
        }

        public Customer GetCustomerByEmail(string email, PromotionGroupType promotionGroupType)
        {
            return Get(c => c.Email == email && c.PromotionGroupType == promotionGroupType).FirstOrDefault();
        }

        public void UpdateCustomerOptStatus(string email, PromotionGroupType promotionGroupType, bool optStatus)
        {
            var customer = GetCustomerByEmail(email, promotionGroupType);
            customer.IsReceiveEmail = optStatus;
            Update(customer);
        }
    }
}
