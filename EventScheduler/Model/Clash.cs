using static EventScheduler.Enums;

namespace EventScheduler.Model
{
    public class Clash
    {
        /// <summary>
        /// Gets the clash number.
        /// </summary>
        /// <value>
        /// The clash number.
        /// </value>
        public int ClashNumber { get; }

        /// <summary>
        /// Gets the team a.
        /// </summary>
        /// <value>
        /// The team a.
        /// </value>
        public TeamDetail TeamA { get; }

        /// <summary>
        /// Gets the team b.
        /// </summary>
        /// <value>
        /// The team b.
        /// </value>
        public TeamDetail TeamB { get; }

        /// <summary>
        /// Gets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public Ground Ground { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Clash"/> class.
        /// </summary>
        /// <param name="teamA">The team a.</param>
        /// <param name="teamB">The team b.</param>
        /// <param name="clashNumber">The clash number.</param>
        public Clash(int clashNumber, TeamDetail teamA, TeamDetail teamB, Ground ground = Ground.Unknown)
        {
            this.TeamA = teamA;
            this.TeamB = teamB;
            this.ClashNumber = clashNumber;

            if (ground == Ground.Unknown)
            {
                this.Ground = this.TeamA.HomeGround;
            }
            else
            {
                this.Ground = this.Ground;
            }
        }
    }
}
