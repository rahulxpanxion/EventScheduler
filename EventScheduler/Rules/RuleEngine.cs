using System.Collections.Generic;
using System.Linq;

namespace EventScheduler
{
    public abstract class RuleEngine : IRuleEngine
    {
        /// <summary>
        /// The respository
        /// </summary>
        protected readonly IRepositoryCollection respository;

        /// <summary>
        /// The factory
        /// </summary>
        protected readonly IRuleFactory factory;

        /// <summary>
        /// Gets the team details.
        /// </summary>
        /// <value>
        /// The team details.
        /// </value>
        protected IList<TeamDetail> TeamDetails { get; private set; }

        /// <summary>
        /// Gets the fixture setting.
        /// </summary>
        /// <value>
        /// The fixture setting.
        /// </value>
        protected FixtureSettings FixtureSetting { get; private set; }

        protected int CurrentDay { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="RuleEngine"/> class.
        /// </summary>
        /// <param name="rules">The rules.</param>
        public RuleEngine(IRepositoryCollection repository, IRuleFactory ruleFactory)
        {
            if (repository == null)
            {
                throw new RuleException("Rule repository not initialized.");
            }

            if (ruleFactory == null)
            {
                throw new RuleException("Rule repository not initialized.");
            }

            this.respository = repository;
            this.factory = ruleFactory;
        }

        /// <summary>
        /// Filters the schedule based on rule.
        /// </summary>
        /// <param name="schedule">The schedule.</param>
        IList<Fixture> IRuleEngine.BuilSchedule()
        {
            var schedule = new List<Fixture>();
            var settings = this.respository.RuleRespository.Get();
            this.FixtureSetting = settings?.FirstOrDefault();
            if (FixtureSetting == null)
            {
                throw new RuleException("No setting found.");
            }

            this.TeamDetails = this.respository.TeamRepository.Get();

            if (this.TeamDetails == null || this.TeamDetails.Count < 2)
            {
                throw new RuleException("Minimum two teams required.");
            }

            return BuilScheduleCore();
        }

        /// <summary>
        /// Buils the schedule core.
        /// </summary>
        /// <returns></returns>
        protected abstract IList<Fixture> BuilScheduleCore();

        /// <summary>
        /// Gets the no of matches.
        /// </summary>
        /// <param name="totalTeams">The total teams.</param>
        /// <param name="noOfClashes">The no of clashes.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        int IRuleEngine.GetNoOfMatches(int totalTeams, int noOfClashes)
        {
            return this.GetNoOfMatches(totalTeams - 1) * noOfClashes;
        }

        /// <summary>
        /// Gets the no of matches.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        private int GetNoOfMatches(int count)
        {
            if (count == 1)
            {
                return 1;
            }
            else
            {
                return count * GetNoOfMatches(count - 1);
            }
        }
    }
}