using System.Collections.Generic;

namespace EventScheduler
{
    public interface ISchedulePrinter
    {
        void PrintSchedule(IList<Fixture> Schedule);
    }
}