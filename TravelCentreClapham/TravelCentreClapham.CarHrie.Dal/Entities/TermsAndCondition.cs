using System.Collections.Generic;
using NexusCore.Infrastructure.Data;

namespace TravelCentreClapham.CarHrie.Dal.Entities
{
    public class TermsAndCondition : Entity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public IEnumerable<Deal> Deals { get; set; }
    }
}
