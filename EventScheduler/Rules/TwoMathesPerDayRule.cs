using System;
using System.Collections.Generic;

namespace EventScheduler
{
    public class TwoMathesPerDayRule : IRuleEngine
    {
        /// <summary>
        /// Buils the schedule.
        /// </summary>
        /// <param name="schedule">The schedule.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        IList<Schedule> IRuleEngine.BuilSchedule(IList<Schedule> schedule)
        {
            throw new NotImplementedException();
        }
    }
}
