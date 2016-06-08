using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusCore.Infrastructure.Data;

namespace TravelCentreClapham.CarHrie.Dal.Entities
{
    public class Model : Entity
    {
        public string Name { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
