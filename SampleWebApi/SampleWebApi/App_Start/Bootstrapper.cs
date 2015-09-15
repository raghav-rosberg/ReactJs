using System.Reflection;
using System.Web.Http;
using LightInject;
using SampleWebApi.Data.UnitOfWork;
using SampleWebApi.Data.Infrastructure;

namespace SampleWebApi
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetLightInjectContainer();
        }

        private static void SetLightInjectContainer()
        {
            var container = new LightInject.ServiceContainer();
            container.RegisterApiControllers(Assembly.GetExecutingAssembly());
            container.Register<IUnitOfWork, UnitOfWork>(new PerScopeLifetime());
            container.Register(typeof(RepositoryBase<>), typeof(IRepository<>));
            container.EnableWebApi(new HttpConfiguration());
        }
    }
}