using static EventScheduler.Enums;

namespace EventScheduler
{
    public class TeamDetail
    {
        public TeamDetail(Team name, Ground homeGround)
        {
            this.Name = name;
            this.HomeGround = homeGround;
        }

        public Team Name { get; }

        public Ground HomeGround { get; }

        public int TeamId { get; set; }
    }
}
