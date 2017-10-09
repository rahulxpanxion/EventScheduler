using static EventScheduler.Enums;

namespace EventScheduler
{
    public class GroundDetail
    {
        /// <summary>
        /// Gets or sets the ground detail identifier.
        /// </summary>
        /// <value>
        /// The ground detail identifier.
        /// </value>
        public int GroundDetailId { get; set; }

        /// <summary>
        /// Gets the ground.
        /// </summary>
        /// <value>
        /// The ground.
        /// </value>
        public Ground Ground { get; }

        /// <summary>
        /// Gets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public City City { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroundDetail"/> class.
        /// </summary>
        /// <param name="ground">The ground.</param>
        /// <param name="city">The city.</param>
        public GroundDetail(Ground ground, City city)
        {
            this.Ground = ground;
            this.City = city;
        }
    }
}
