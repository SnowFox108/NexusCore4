using System.Data.Entity;

namespace NexusCore.Infrastructure.Data.EntityFramework
{
    public class ContentContext : DbContext, IContentContext
    {
        public ContentContext(string database) : base(database)
        {
        }

        public virtual IDbSet<TEntity> CreateSet<TEntity>() where TEntity : Entity
        {
            return Set<TEntity>();
        }

        public virtual void Attach<TEntity>(TEntity entity) where TEntity : Entity
        {
            Entry(entity).State = EntityState.Unchanged;
        }

        public virtual void SetModified<TEntity>(TEntity entity) where TEntity : Entity
        {
            var entry = base.Entry(entity);

            var set = CreateSet<TEntity>();
            TEntity attachedEntity = set.Find(entity.Id);
            if (attachedEntity != null)
                ApplyCurrentValues(attachedEntity, entity);
            else
                entry.State = EntityState.Modified;
        }

        public virtual void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : Entity
        {
            Entry(original).CurrentValues.SetValues(current);
        }
    }
}
