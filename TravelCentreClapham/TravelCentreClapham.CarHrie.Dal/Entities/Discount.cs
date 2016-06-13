using NexusCore.Infrastructure.Data;

namespace TravelCentreClapham.CarHrie.Dal.Entities
{
    public class Discount : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public DiscountGroupType DiscountGroupType { get; set; }
        public DiscountValueGroupType DiscountValueGroupType { get; set; }

    }
}
