using EventScheduler.Model;
using System.Collections.Generic;
using System.Linq;

namespace EventScheduler
{
    public class TwoMatchHomeAwayRule : RuleEngine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TwoMatchHomeAwayRule"/> class.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="ruleFactory"></param>
        public TwoMatchHomeAwayRule(IRepositoryCollection repository, IRuleFactory ruleFactory) : base(repository, ruleFactory)
        {
        }

        /// <summary>
        /// Buils the schedule core.
        /// </summary>
        /// <returns></returns>
        protected override IList<Fixture> BuilScheduleCore()
        {
            var fixtures = new List<Fixture>();
            var noOfClashes = this.FixtureSetting.NoOfClashes;
            var maxMatchesInEachDay = this.FixtureSetting.NoOfMatchesPerDay;
            var totalMatchedRequired = ((IRuleEngine)this).GetNoOfMatches(this.TeamDetails.Count, noOfClashes);

            var clashNumber = 0;

            for (var i = 0; i < this.TeamDetails.Count; i++)
            {
                for (var k = 0; k < this.TeamDetails.Count; k++)
                {
                    if (k > i)
                    {
                        var clash = new Clash(++clashNumber, this.TeamDetails[i], this.TeamDetails[k]);
                        BuildFixture(clash, fixtures, maxMatchesInEachDay);

                        var clash2 = new Clash(++clashNumber, this.TeamDetails[k], this.TeamDetails[i]);
                        BuildFixture(clash2, fixtures, maxMatchesInEachDay);
                    }
                }
            }

            var filterdFixtures = new List<Fixture>();
            var macthNumbner = 0;
            foreach (var fixture in fixtures)
            {
                if (fixture.Clash != null)
                {
                    fixture.MatchNumber = ++macthNumbner;
                    filterdFixtures.Add(fixture);
                }
            }

            return filterdFixtures;
        }

        private void BuildFixture(Clash clash, List<Fixture> fixtures, int matchesInEachDay)
        {
            // check if any of these slots can be assigned a clash
            bool added = false;
            for (var k = 0; k < fixtures.Count; k++)
            {
                var dayNo = fixtures[k].DayNo;
                if (fixtures[k].Clash == null && isFixtureAvailable(clash, dayNo, fixtures))
                {
                    fixtures[k].Clash = clash;
                    added = true;
                    break;
                }
            }

            if (!added)
            {
                while (!added)
                {
                    var fixtureSlot = Fixture.GetNewFixtureSlot(matchesInEachDay).ToArray();
                    var currentDayCount = fixtureSlot.FirstOrDefault().DayNo;

                    if (isFixtureAvailable(clash, currentDayCount, fixtures))
                    {
                        fixtureSlot[0].Clash = clash;
                        added = true;
                    }

                    fixtures.AddRange(fixtureSlot);
                }

            }
        }

        /// <summary>
        /// Determines whether [is fixture available] [the specified clash].
        /// </summary>
        /// <param name="clash">The clash.</param>
        /// <param name="dayNo">The day no.</param>
        /// <returns>
        ///   <c>true</c> if [is fixture available] [the specified clash]; otherwise, <c>false</c>.
        /// </returns>
        private bool isFixtureAvailable(Clash clash, int dayNo, IList<Fixture> fixtures)
        {
            var isAlreadyAssigned = fixtures.Where(x => (x.DayNo == dayNo || x.DayNo == dayNo - 1))
                .Where(x => x.Clash != null)
                .Where(x => x.Clash.TeamA == clash.TeamA || x.Clash.TeamA == clash.TeamB || x.Clash.TeamB == clash.TeamA || x.Clash.TeamB == clash.TeamB).Any();
            return !isAlreadyAssigned;
        }

        /// <summary>
        /// Gets the clash.
        /// </summary>
        /// <param name="fixtures">The fixtures.</param>
        /// <param name="clashes">The clashes.</param>
        /// <param name="dayNo">The day no.</param>
        /// <returns></returns>
        private Clash GetClash(IList<Fixture> fixtures, IList<Clash> clashes, int dayNo)
        {
            var notAvailableClashesQuery = from c in clashes
                                           join f in fixtures
                                           on c.ClashNumber equals f.Clash.ClashNumber
                                           where f.Clash != null && (f.DayNo == dayNo || f.DayNo == dayNo - 1)
                                           select f.Clash;

            var notAvailableClashes = notAvailableClashesQuery.ToList();
            return clashes.Except(notAvailableClashes).FirstOrDefault();
        }
    }
}