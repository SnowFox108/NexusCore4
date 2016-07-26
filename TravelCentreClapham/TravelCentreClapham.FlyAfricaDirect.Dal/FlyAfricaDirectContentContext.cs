using System.Data.Entity;
using NexusCore.Infrastructure.Data.EntityFramework;
using TravelCentreClapham.FlyAfricaDirect.Dal.Entities;

namespace TravelCentreClapham.FlyAfricaDirect.Dal
{
    public class FlyAfricaDirectContentContext : ContentContext
    {
        public FlyAfricaDirectContentContext(string database) : base(database)
        {
        }

        public IDbSet<Customer> Customers { get; set; }
    }
}
