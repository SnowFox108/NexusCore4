using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusCore.Infrastructure.Data;

namespace TravelCentreClapham.CarHrie.Dal.Entities
{
    public class Order : TrackableEntity
    {
        public Deal Deal { get; set; }
        public Customer Customer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Location PickUpLocation { get; set; }
        public Location DropOffLocation { get; set; }
        public IEnumerable<OrderDealExtra> DealExtras { get; set; }
        public IEnumerable<OrderDiscount> Discounts { get; set; }
        public IEnumerable<OrderProgress> OrderProgresses { get; set; }
        public IEnumerable<OrderTransaction> Transactions { get; set; }
        public string Note { get; set; }
    }
}
