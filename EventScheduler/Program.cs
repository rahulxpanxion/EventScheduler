namespace EventScheduler
{
    using Microsoft.Practices.Unity;

    class Program
    {
        static void Main(string[] args)
        {
            using (var container = Container.LoadContainer())
            {
                var scheduler = container.Resolve<IScheduler>();
                scheduler.GetSchedule();
            };
        }
    }
}
