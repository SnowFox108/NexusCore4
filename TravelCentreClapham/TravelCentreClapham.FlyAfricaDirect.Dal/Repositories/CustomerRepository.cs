using NexusCore.Infrastructure.Data.EntityFramework;
using TravelCentreClapham.FlyAfricaDirect.Dal.Entities;

namespace TravelCentreClapham.FlyAfricaDirect.Dal.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IContentContext contentContext) : base(contentContext)
        {
        }
    }
}
