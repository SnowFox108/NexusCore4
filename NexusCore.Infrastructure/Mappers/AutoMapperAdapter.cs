using AutoMapper;

namespace NexusCore.Infrastructure.Mappers
{
    public class AutoMapperAdapter : IMapperAdapter
    {
        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return Mapper.Map<TSource, TTarget>(source);
        }

        public TTarget Adapt<TTarget>(object source) where TTarget : class, new()
        {
            return Mapper.Map<TTarget>(source);
        }
    }
}
