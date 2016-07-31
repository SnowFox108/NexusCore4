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
        protected readonly IContentContext ContentContext;

        public Repository(IContentContext contentContext)
        {
            ContentContext = contentContext;
        }

        public void Dispose()
        {
            ContentContext?.Dispose();
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

                    ContentContext.CreateSet<TEntity>().Add(item);
                }
                else
                {
                    //TODO create null error log later
                }
            }
            ContentContext.SaveChanges();
        }

        public virtual void Delete(params object[] ids)
        {
            foreach (var id in ids)
                Delete(ContentContext.CreateSet<TEntity>().Find(id));
        }

        public virtual void Delete(TEntity item)
        {
            if (item != null)
            {
                ContentContext.Attach(item);
                ContentContext.CreateSet<TEntity>().Remove(item);
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
                ContentContext.SetModified(item);

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
                ContentContext.Attach(item);
            else
            {
                //TODO create null error log
            }
        }

        public virtual void Merge(TEntity persisted, TEntity current)
        {
            ContentContext.ApplyCurrentValues(persisted, current);
        }

        public virtual TEntity GetById(params object[] id)
        {
            if (id != null)
                return ContentContext.CreateSet<TEntity>().Find(id);
            return null;
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, EntityPager<TEntity> pager = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = ContentContext.CreateSet<TEntity>();

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
