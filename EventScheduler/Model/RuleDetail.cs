using static EventScheduler.Enums;

namespace EventScheduler
{
    public class FixtureSettings
    {
        /// <summary>
        /// Gets the type of the rule.
        /// </summary>
        /// <value>
        /// The type of the rule.
        /// </value>
        public RuleType Rule { get; }

        /// <summary>
        /// Gets the no of clashes.
        /// </summary>
        /// <value>
        /// The no of clashes.
        /// </value>
        public int NoOfClashes { get; }

        /// <summary>
        /// Gets the no of matches per day.
        /// </summary>
        /// <value>
        /// The no of matches per day.
        /// </value>
        public int NoOfMatchesPerDay { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FixtureSettings"/> class.
        /// </summary>
        /// <param name="ruleType">Type of the rule.</param>
        public FixtureSettings(RuleType ruleType, int clashCount, int perDayMatches)
        {
            this.Rule = ruleType;
            this.NoOfClashes = clashCount;
            this.NoOfMatchesPerDay = perDayMatches;
        }
    }
}
