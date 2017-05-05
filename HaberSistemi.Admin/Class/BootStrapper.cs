using Autofac;
using Autofac.Integration.Mvc;
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
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}