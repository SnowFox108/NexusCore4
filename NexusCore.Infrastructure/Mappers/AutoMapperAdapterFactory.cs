using System;
using System.Linq;
using AutoMapper;

namespace NexusCore.Infrastructure.Mappers
{
    public class AutoMapperAdapterFactory
    {
        private static readonly Lazy<AutoMapperAdapterFactory> Lazy =
            new Lazy<AutoMapperAdapterFactory>(() => new AutoMapperAdapterFactory());

        public static AutoMapperAdapterFactory Instance => Lazy.Value;

        private AutoMapperAdapterFactory()
        {
            //scan all assemblies finding Automapper Profile
            var profiles = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.BaseType == typeof (Profile));

            Mapper.Initialize(cfg =>
            {
                foreach (var item in profiles)
                {
                    if (item.FullName != "AutoMapper.SelfProfiler`2")
                        cfg.AddProfile(Activator.CreateInstance(item) as Profile);
                }
            });

#if DEBUG
            Mapper.AssertConfigurationIsValid();
#endif
        }

        public IMapperAdapter Create()
        {
            return new AutoMapperAdapter();
        }
    }
}
