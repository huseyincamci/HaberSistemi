using Autofac;
using Autofac.Integration.Mvc;
using HaberSistemi.Core.Infrastructure;
using HaberSistemi.Core.Repository;
using System.Web.Mvc;

namespace HaberSistemi.Admin.Class
{
    public class BootStrapper
    {
        public static void RunConfig()
        {
            BuildAutoFact();
        }

        private static void BuildAutoFact()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<HaberRepository>().As<IHaberRepository>();
            builder.RegisterType<ResimRepository>().As<IResimRepository>();
            builder.RegisterType<KullaniciRepository>().As<IKullaniciRepository>();
            builder.RegisterType<RolRepository>().As<IRolRepository>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}