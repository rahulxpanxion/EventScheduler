using EventScheduler.Model;
using System.Collections.Generic;

namespace EventScheduler
{
    public class Fixture
    {

        /// <summary>
        /// Gets the fixture identifier.
        /// </summary>
        /// <value>
        /// The fixture identifier.
        /// </value>
        public int MatchNumber { get; set; }

        /// <summary>
        /// Gets or sets the day no.
        /// </summary>
        /// <value>
        /// The day no.
        /// </value>
        public int DayNo { get; set; }

        /// <summary>
        /// Gets or sets the clash.
        /// </summary>
        /// <value>
        /// The clash.
        /// </value>
        public Clash Clash { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Fixture"/> class.
        /// </summary>
        /// <param name="fixtureId">The fixture identifier.</param>
        /// <param name="dayNo">The day no.</param>
        private Fixture()
        {
            this.DayNo = DayCount;
        }

        /// <summary>
        /// Gets the new fixture slot.
        /// </summary>
        /// <param name="noOfMacthesAllowedInOneDay">The no of macthes allowed in one day.</param>
        /// <returns></returns>
        public static IList<Fixture> GetNewFixtureSlot(int noOfMacthesAllowedInOneDay)
        {
            var slots = new List<Fixture>();
            for (var i = 0; i < noOfMacthesAllowedInOneDay; i++)
            {
                slots.Add(new Fixture());
            }

            DayCount++;
            return slots;
        }

        private static int DayCount = 1;
    }
}
