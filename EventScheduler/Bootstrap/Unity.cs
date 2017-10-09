using Microsoft.Practices.Unity;

namespace EventScheduler
{
    public class Container
    {

        public static IUnityContainer LoadContainer()
        {
            var container = new UnityContainer();

            //Register types
            container.RegisterType<IScheduler, Scheduler>();
            container.RegisterType<ISchedulePrinter, ConsolePrinter>();
            container.RegisterType<IRunContext, RunContext>();
            container.RegisterType<IRepositoryCollection, RepositoryCollection>();
            container.RegisterType<IRepository<TeamDetail>, TeamRepository>();
            container.RegisterType<IRepository<FixtureSettings>, RuleRepository>();
            container.RegisterType<IRuleFactory, RuleFactory>();
            return container;
        }
    }
}
