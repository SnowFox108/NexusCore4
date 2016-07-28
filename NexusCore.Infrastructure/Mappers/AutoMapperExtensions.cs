using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NexusCore.Infrastructure.Data;

namespace NexusCore.Infrastructure.Mappers
{
    public static class AutoMapperExtensions
    {
        public static TTarget MapTo<TTarget>(this IEntity item) where TTarget : class, IDto, new()
        {
            var adapter = AutoMapperAdapterFactory.Instance.Create();
            return adapter.Adapt<TTarget>(item);
        }

        public static List<TTarget> MapTo<TTarget>(this IEnumerable<IEntity> items)
            where TTarget : class, IDto, new()
        {
            var adapter = AutoMapperAdapterFactory.Instance.Create();
            return adapter.Adapt<List<TTarget>>(items);
        }

        public static TTarget MapTo<TTarget>(this IDto item) where TTarget : class, IEntity, new()
        {
            var adapter = AutoMapperAdapterFactory.Instance.Create();
            return adapter.Adapt<TTarget>(item);
        }

        public static List<TTarget> MapTo<TTarget>(this IEnumerable<IDto> items)
            where TTarget : class, IEntity, new()
        {
            var adapter = AutoMapperAdapterFactory.Instance.Create();
            return adapter.Adapt<List<TTarget>>(items);
        }


        public static IMappingExpression<TSource, TTarget> IgnoreAllMissingInTarget<TSource, TTarget>(this IMappingExpression<TSource, TTarget> expression)
        {
            var sourceProperties = typeof(TSource).GetProperties().Select(s => s.Name);
            var targetProperties = typeof(TTarget).GetProperties().Select(t => t.Name);
            foreach (var prop in targetProperties.Where(t => sourceProperties.All(s => s != t)))
                expression.ForMember(prop, opt => opt.Ignore());
            return expression;
        }

    }
}
