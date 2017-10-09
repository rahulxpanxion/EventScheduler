using System.Collections.Generic;

namespace EventScheduler
{
    public interface IRuleEngine
    {
        /// <summary>
        /// Buils the schedule.
        /// </summary>
        /// <param name="schedule">The schedule.</param>
        /// <returns></returns>
        IList<Fixture> BuilSchedule();

        /// <summary>
        /// Gets the no of matches.
        /// </summary>
        /// <param name="totalTeams">The total teams.</param>
        /// <param name="noOfClashes">The no of clashes.</param>
        /// <returns></returns>
        int GetNoOfMatches(int totalTeams, int noOfClashes);
    }
}
