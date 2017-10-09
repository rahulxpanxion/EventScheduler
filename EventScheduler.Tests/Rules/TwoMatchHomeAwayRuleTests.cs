using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventScheduler.Tests
{
    [TestClass]
    public class TwoMatchHomeAwayRuleTests
    {
        private IRepositoryCollection respository;

        private Mock<IRuleFactory> factory;

        private Mock<IRepository<FixtureSettings>> ruleRespository;

        private Mock<IRepository<TeamDetail>> teamRepository;

        private IRuleEngine ruleEngine;

        [TestInitialize]
        public void Init()
        {
            this.ruleRespository = new Mock<IRepository<FixtureSettings>>(MockBehavior.Strict);
            this.teamRepository = new Mock<IRepository<TeamDetail>>(MockBehavior.Strict);
            this.respository = new RepositoryCollection(this.teamRepository.Object, this.ruleRespository.Object);
            this.factory = new Mock<IRuleFactory>(MockBehavior.Strict);
            this.ruleEngine = new TwoMatchHomeAwayRule(this.respository, this.factory.Object);

            // setups
            this.ruleRespository.Setup(x => x.Get(It.IsAny<Expression<Func<FixtureSettings, bool>>>()))
             .Returns(TestDatabase.GetRules.ToList());
        }

        [TestMethod]
        public void GetNoOfMatchesShouldReturnValidNumbers()
        {
            // Arrange
            const int teamSize = 4;
            const int noOfClashes = 2;
            const int expectedNoOfMatches = 12;

            // Act
            var matches = this.ruleEngine.GetNoOfMatches(teamSize, noOfClashes);

            // Assert
            matches.Should().Be(expectedNoOfMatches, "Incorrect number of matches");
        }

        [TestMethod]
        public void BuilScheduleShouldReturnValidFixturesForTwoTeams()
        {
            // Arrange
            const int expectedCount = 2;
            var teamDetails = new List<TeamDetail>
            {
                 new TeamDetail(Enums.Team.ChennaiRiders, Enums.Ground.ChinnaSwami),
                 new TeamDetail(Enums.Team.MumbaiRiders, Enums.Ground.Shivaji),
            };

            this.teamRepository.Setup(x => x.Get(It.IsAny<Expression<Func<TeamDetail, bool>>>()))
             .Returns(teamDetails);

            // Act
            var fixtures = this.ruleEngine.BuilSchedule();

            // Assert

            //Check number of macthes.
            fixtures.Should().NotBeNull("fixtures not found");
            fixtures.Count.Should().Be(expectedCount, "Only two macthes for a team.");

            // check grounds
            var clash1 = fixtures[0].Clash;
            var clash2 = fixtures[1].Clash;
            clash1.ClashNumber.Should().NotBe(clash2.ClashNumber, "Non unique clashes found");
            clash1.TeamA.Should().NotBe(clash1.TeamB, "Match fixed within same team");
            clash1.TeamA.Should().Be(clash2.TeamB, "Home away rule not satified");
            clash1.Ground.Should().NotBe(clash2.Ground, "Home away rule not satisfied.");

            // same teams should not clash on same day.
        }

        [TestMethod]
        public void BuilScheduleShouldReturnValidFixturesForFourTeams()
        {
            // Arrange
            const int expectedCount = 12;
            var teamDetails = TestDatabase.TeamDetails.ToList();
            this.teamRepository.Setup(x => x.Get(It.IsAny<Expression<Func<TeamDetail, bool>>>()))
             .Returns(teamDetails);

            // Act
            var fixtures = this.ruleEngine.BuilSchedule();

            // Assert

            //Check number of macthes.
            fixtures.Should().NotBeNull("fixtures not found");
            fixtures.Count.Should().Be(expectedCount, "Only two macthes for a team.");

            // check home away rule;
            var homeAwayFixture = GetMatchesWithSameTeam(fixtures);
            foreach (var fix in homeAwayFixture)
            {
                var teamAFixture = fix.Key;
                var teamBFixture = fix.Value;
                var dayDiff = Math.Abs(teamAFixture.DayNo - teamBFixture.DayNo);
                teamAFixture.Clash.Ground.Should().Be(teamAFixture.Clash.TeamA.HomeGround, "Match not scheduled on home ground for team A");
                teamBFixture.Clash.Ground.Should().Be(teamBFixture.Clash.TeamA.HomeGround, "Match not scheduled on home ground for team B");
                dayDiff.Should().BeGreaterThan(1, "Match scheduled on  consecutive day");
            }
        }

        private Dictionary<Fixture, Fixture> GetMatchesWithSameTeam(IList<Fixture> fixtures)
        {
            var homeAwayFixture = new Dictionary<Fixture, Fixture>();
            for (var i = 0; i < fixtures.Count; i++)
            {
                for (var j = 0; j < fixtures.Count; j++)
                {
                    if ((fixtures[i].Clash.TeamA == fixtures[j].Clash.TeamB) && (fixtures[i].Clash.TeamB == fixtures[j].Clash.TeamA))
                    {
                        homeAwayFixture.Add(fixtures[i], fixtures[j]);
                    }
                }
            }

            return homeAwayFixture;
        }
    }
}
