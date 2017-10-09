using System;
using static EventScheduler.Enums;

namespace EventScheduler
{
    public class TimeSlot
    {
        public TimeSlot(TimeSpan startTime, TimeSpan endTime, Ground ground)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Ground = ground;
        }

        public TimeSpan StartTime { get; }

        public TimeSpan EndTime { get; }

        public Ground Ground { get; }
    }
}
