using System.Data.Entity;
using NexusCore.Infrastructure.Data.EntityFramework;
using TravelCentreClapham.FlyAfricaDirect.Dal.Entities;

namespace TravelCentreClapham.FlyAfricaDirect.Dal
{
    public class FlyAfricaDirectContentContext : ContentContext
    {
        public FlyAfricaDirectContentContext() : base("FlyAfricaDirect")
        {
        }

        public virtual IDbSet<Customer> Customers { get; set; }
    }
}
