using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using NexusCore.Infrastructure.Helpers;

namespace NexusCore.Infrastructure.Data.EntityFramework
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: Entity
    {
        private readonly IContentContext _contentContext;

        public Repository(IContentContext contentContext)
        {
            _contentContext = contentContext;
        }

        public void Dispose()
        {
            _contentContext?.Dispose();
        }

        public virtual void Insert(params TEntity[] items)
        {
            foreach (var item in items)
            {
                if (item != null)
                {
                    // generate new Id
                    item.GenerateNewIdentity();
                    // check trackable item for create
                    if (item.GetType().GetInterfaces().Contains(typeof (ILogable)))
                    {
                        var logger = (ILogable) item;
                        UpdateLogableItem(logger);
                    }

                    _contentContext.CreateSet<TEntity>().Add(item);
                }
                else
                {
                    //TODO create null error log later
                }
            }
        }

        public virtual void Delete(params object[] ids)
        {
            foreach (var id in ids)
                Delete(_contentContext.CreateSet<TEntity>().Find(id));
        }

        public virtual void Delete(TEntity item)
        {
            if (item != null)
            {
                _contentContext.Attach(item);
                _contentContext.CreateSet<TEntity>().Remove(item);
            }
            else
            {
                //TODO create null error log
            }
        }

        public virtual void Update(TEntity item)
        {
            if (item != null)
            {
                _contentContext.SetModified(item);

                // check trackable item for create
                if (item.GetType().GetInterfaces().Contains(typeof(ITrackable)))
                {
                    var tracker = (ITrackable)item;
                    //UpdateTrackableItem(tracker, false);
                }
            }
            else
            {
                //TODO create null error log
            }
        }

        public virtual void TrackItem(TEntity item)
        {
            if (item != null)
                _contentContext.Attach(item);
            else
            {
                //TODO create null error log
            }
        }

        public virtual void Merge(TEntity persisted, TEntity current)
        {
            _contentContext.ApplyCurrentValues(persisted, current);
        }

        public virtual TEntity GetById(params object[] id)
        {
            if (id != null)
                return _contentContext.CreateSet<TEntity>().Find(id);
            return null;
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, EntityPager<TEntity> pager = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _contentContext.CreateSet<TEntity>();

            if (filter != null)
                query = query.Where(filter);

            if (pager != null)
            {
                query = pager.OrderBy(query);
                if (pager.PageNumber > 0)
                    query = query.Skip((pager.PageNumber - 1)*pager.PageSize).Take(pager.PageSize);
            }

            if (!string.IsNullOrEmpty(includeProperties))
                query = includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

#if DEBUG
            Debug.WriteLine("Query Linq: " + query);
#endif
            return query;
        }

        private void UpdateLogableItem(ILogable logger)
        {
            var timeNow = DateFormater.DateTimeNow;
            if (logger.CreatedDate == default(DateTime))
                logger.CreatedDate = timeNow;
            //if (logger.CreatedBy == default(Guid))
                //logger.CreatedBy = EngineContext.Instance.CurrentUser.User.Id;
        }

    }
}
