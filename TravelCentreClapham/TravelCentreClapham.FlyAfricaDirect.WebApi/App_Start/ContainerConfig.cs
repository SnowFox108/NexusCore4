using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using NexusCore.Infrastructure.Data.EntityFramework;
using NexusCore.Infrastructure.Messager;
using TravelCentreClapham.FlyAfricaDirect.Dal;
using TravelCentreClapham.FlyAfricaDirect.Dal.Repositories;
using TravelCentreClapham.FlyAfricaDirect.Main.Services;

namespace TravelCentreClapham.FlyAfricaDirect.WebApi.App_Start
{
    public class ContainerConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            ServiceInstaller(builder);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void ServiceInstaller(ContainerBuilder builder)
        {
            //        builder.Register(c => new LoggingActionFilter(c.Resolve<ILogger>()))
            //.AsWebApiActionFilterFor<ValuesController>(c => c.Get(default(int)))
            //.InstancePerApiRequest();

            //builder.RegisterType<FlyAfricaDirectContentContext>()
            //    .As<IContentContext>()
            //    .WithParameter("database", "FlyAfricaDirect")
            //    .InstancePerLifetimeScope();
            
            // base
            builder.RegisterType<EmailSender>().As<IEmailSender>().InstancePerLifetimeScope();

            builder.RegisterType<FlyAfricaDirectContentContext>().As<IContentContext>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EmailTemplateRepository>().As<IEmailTemplateRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EnquiryFormService>().As<IEnquiryFormService>().InstancePerLifetimeScope();
        }
    }
}