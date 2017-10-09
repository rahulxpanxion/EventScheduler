namespace EventScheduler
{
    public interface IRepositoryCollection
    {
        IRepository<FixtureSettings> RuleRespository { get; }

        IRepository<TeamDetail> TeamRepository { get; }
    }

    public class RepositoryCollection : IRepositoryCollection
    {

        /// <summary>
        /// Gets the rule respository.
        /// </summary>
        /// <value>
        /// The rule respository.
        /// </value>
        public IRepository<FixtureSettings> RuleRespository
        {
            get;
        }

        /// <summary>
        /// Gets the team repository.
        /// </summary>
        /// <value>
        /// The team repository.
        /// </value>
        public IRepository<TeamDetail> TeamRepository
        {
            get;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryCollection"/> class.
        /// </summary>
        /// <param name="GroundDetail">The ground repository.</param>
        /// <param name="TeamDetail">The team repository.</param>
        /// <param name="RuleDetail">The rule respository.</param>
        public RepositoryCollection(IRepository<TeamDetail> teamRepository,
            IRepository<FixtureSettings> ruleRespository)
        {
            this.RuleRespository = ruleRespository;
            this.TeamRepository = teamRepository;
        }
    }
}
