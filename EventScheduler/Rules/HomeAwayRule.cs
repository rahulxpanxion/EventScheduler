using System.Collections.Generic;
using System.Linq;

namespace EventScheduler
{
    public class HomeAwayRule : IRuleEngine
    {
        private readonly IRepository<GroundDetail> groundDetails;
        private readonly IRepository<TeamDetail> teamDetails;

        public HomeAwayRule(IRepository<GroundDetail> groundDetails, IRepository<TeamDetail> teamDetails)
        {
            this.groundDetails = groundDetails;
            this.teamDetails = teamDetails;
        }

        IList<Schedule> IRuleEngine.BuilSchedule(IList<Schedule> fixtures)
        {

            foreach (var fixture in fixtures)
            {
                if (fixture.ScheduleId % 2 == 0)
                {
                    var grounds = this.groundDetails.Get(x => x.City == fixture.TeamA.HomeCity);
                    var ground = grounds.FirstOrDefault();
                    fixture.Venue = new FixtureDetail(ground);
                }
                else
                {
                    var grounds = this.groundDetails.Get(x => x.City == fixture.TeamB.HomeCity);
                    var ground = grounds.FirstOrDefault();
                    fixture.Venue = new FixtureDetail(ground);
                }
            }

            return fixtures;

        }
    }
}