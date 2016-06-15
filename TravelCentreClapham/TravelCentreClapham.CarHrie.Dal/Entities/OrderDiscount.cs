using NexusCore.Infrastructure.Data;

namespace TravelCentreClapham.CarHrie.Dal.Entities
{
    public class OrderDiscount : Entity
    {
        public Order Order { get; set; }
        public Discount Discount { get; set; }
        public decimal Value { get; set; }
    }
}
