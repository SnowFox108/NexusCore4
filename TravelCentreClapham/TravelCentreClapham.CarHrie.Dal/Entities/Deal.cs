using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusCore.Infrastructure.Data;

namespace TravelCentreClapham.CarHrie.Dal.Entities
{
    public class Deal : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Car Car { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public TermsAndCondition TermsAndCondition { get; set; }
        public DealGroupType DealGroupType { get; set; }

    }
}
