using NexusCore.Infrastructure.Data;

namespace TravelCentreClapham.FlyAfricaDirect.Dal.Entities
{
    public class Customer : LogableEntity
    {
        public PromotionGroupType PromotionGroupType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredDestination { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
