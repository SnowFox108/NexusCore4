using System.Data.Entity;
using NexusCore.Infrastructure.Data.EntityFramework;
using TravelCentreClapham.CarHrie.Dal.Entities;

namespace TravelCentreClapham.CarHrie.Dal
{
    public class CarHireContentContext : ContentContext
    {
        public CarHireContentContext() : base("CarHire")
        {
        }

        public virtual IDbSet<Car> Cars { get; set; }
        public virtual IDbSet<Currency> Currencies { get; set; }
        public virtual IDbSet<Customer> Customers { get; set; }
        public virtual IDbSet<Deal> Deals { get; set; }
        public virtual IDbSet<DealExtra> DealsExtras { get; set; }
        public virtual IDbSet<Discount> Discounts { get; set; }
        public virtual IDbSet<Location> Locations { get; set; }
        public virtual IDbSet<Maker> Makers { get; set; }
        public virtual IDbSet<Model> Models { get; set; }
        public virtual IDbSet<Order> Orders { get; set; }
        public virtual IDbSet<OrderDealExtra> OrderDealExtras { get; set; }
        public virtual IDbSet<OrderDiscount> OrderDiscounts { get; set; }
        public virtual IDbSet<OrderProgress> OrderProgresses { get; set; }
        public virtual IDbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual IDbSet<OrderTransaction> OrderTransactions { get; set; }
        public virtual IDbSet<TermsAndCondition> TermsAndConditions { get; set; }


    }
}
