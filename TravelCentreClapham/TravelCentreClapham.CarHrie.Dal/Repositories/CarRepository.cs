using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusCore.Infrastructure.Data.EntityFramework;
using TravelCentreClapham.CarHrie.Dal.Entities;

namespace TravelCentreClapham.CarHrie.Dal.Repositories
{
    public class CarRepository: Repository<Car>, ICarRepository
    {
        public CarRepository(IContentContext contentContext) : base(contentContext)
        {
        }
    }
}
