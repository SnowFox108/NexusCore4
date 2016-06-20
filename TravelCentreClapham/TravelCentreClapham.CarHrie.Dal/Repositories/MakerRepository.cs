using NexusCore.Infrastructure.Data.EntityFramework;
using TravelCentreClapham.CarHrie.Dal.Entities;

namespace TravelCentreClapham.CarHrie.Dal.Repositories
{
    public class MakerRepository : Repository<Maker>, IMakerRepository
    {
        public MakerRepository(IContentContext contentContext) : base(contentContext)
        {
        }
    }
}
