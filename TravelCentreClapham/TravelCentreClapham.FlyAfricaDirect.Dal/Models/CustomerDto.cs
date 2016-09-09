using System.Runtime.Serialization;
using NexusCore.Infrastructure.Data;

namespace TravelCentreClapham.FlyAfricaDirect.Dal.Models
{
    [DataContract]
    public class EnquiryForm01Dto : IDto
    {
        [DataMember]
        public PromotionGroupType PromotionGroupType { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string PreferredDestination { get; set; }
        [DataMember]
        public string MobilePhoneNumber { get; set; }
        [DataMember]
        public string Email { get; set; }

    }
}
