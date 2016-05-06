using System;
using System.Linq;
using System.Linq.Expressions;

namespace NexusCore.Infrastructure.Data.EntityFramework
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Insert(params TEntity[] items);
        void Delete(params object[] id);
        void Delete(TEntity items);
        void Update(TEntity item);
        void TrackItem(TEntity item);
        void Merge(TEntity persisted, TEntity current);
        TEntity GetById(params object[] id);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            EntityPager<TEntity> pager = null,
            string includeProperties = "");

    }
}
