using NexusCore.Infrastructure.Data;

namespace TravelCentreClapham.CarHrie.Dal.Entities
{
    public class OrderDealExtra : Entity
    {
        public Order Order { get; set; }
        public DealExtra DealExtra { get; set; }
        public decimal Value { get; set; }
    }
}
