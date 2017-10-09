using System.Collections.Generic;

namespace EventScheduler
{
    public interface IScheduler
    {
        IList<Fixture> GetSchedule();
    }
}
