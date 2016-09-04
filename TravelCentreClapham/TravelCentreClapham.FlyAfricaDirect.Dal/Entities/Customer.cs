using System;
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
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsReceiveEmail { get; set; }

    }
}
