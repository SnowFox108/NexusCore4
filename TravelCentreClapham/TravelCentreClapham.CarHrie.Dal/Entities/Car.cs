using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusCore.Infrastructure.Data;

namespace TravelCentreClapham.CarHrie.Dal.Entities
{
    public class Car : Entity
    {
        public Model Model { get; set; }
        public CarGroupType GroupType { get; set; }
        public GearType GearType { get; set; }
        public FeulType FuelType { get; set; }
        public int EngineCapacity { get; set; }
        public int NumberOfSeats { get; set; }
        public int NumberOfSuitcases { get; set; }
        public int NumberOfDoors { get; set; }
        public bool AirCondition { get; set; }

    }
}
