using System;
using System.Collections.Generic;

namespace EventScheduler
{
    public class NoConsecutiveMatchRule : IRuleEngine
    {
        IList<Schedule> IRuleEngine.BuilSchedule(IList<Schedule> schedule)
        {
            throw new NotImplementedException();
        }
    }
}