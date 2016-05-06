using System;
using System.Linq;

namespace NexusCore.Infrastructure.Data.EntityFramework
{
    public class EntityPager<TEntity> where TEntity : Entity
    {
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public EntityPager()
        {
            OrderBy = null;
            PageNumber = -1;
            PageSize = 10;
        }
    }
}
