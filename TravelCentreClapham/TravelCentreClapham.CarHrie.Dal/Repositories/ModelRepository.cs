using NexusCore.Infrastructure.Data.EntityFramework;
using TravelCentreClapham.CarHrie.Dal.Entities;

namespace TravelCentreClapham.CarHrie.Dal.Repositories
{
    public class ModelRepository : Repository<Model>, IModelRepository
    {
        public ModelRepository(IContentContext contentContext) : base(contentContext)
        {
        }
    }
}
