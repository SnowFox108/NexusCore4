using NexusCore.Infrastructure.Data;

namespace TravelCentreClapham.CarHrie.Dal.Entities
{
    public class OrderProgress : LogableEntity
    {
        public Order Order { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Note { get; set; }
    }
}
