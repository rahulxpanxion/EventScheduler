using System.Collections.Generic;
using System.Linq;

namespace EventScheduler
{
    public class TestDatabase
    {
        const int TwoMatchesPerDay = 2;
        const int TwoClashes = 2;
        public static IQueryable<TeamDetail> TeamDetails => new List<TeamDetail>
        {
            new TeamDetail(Enums.Team.ChennaiRiders, Enums.Ground.ChinnaSwami),
            new TeamDetail(Enums.Team.MumbaiRiders, Enums.Ground.Shivaji),
            new TeamDetail(Enums.Team.KolkataRiders, Enums.Ground.Eden),
            new TeamDetail(Enums.Team.DelhiRiders, Enums.Ground.FirozShah),
        }.AsQueryable();

        /// <summary>
        /// Gets the get rules.
        /// </summary>
        /// <value>
        /// The get rules.
        /// </value>
        public static IQueryable<FixtureSettings> GetRules => new List<FixtureSettings>
        {
            new FixtureSettings(Enums.RuleType.TwoMatchHomeAwayRule,TwoClashes ,TwoMatchesPerDay),
        }.AsQueryable();
    }
}
