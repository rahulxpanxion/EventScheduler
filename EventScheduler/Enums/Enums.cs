namespace EventScheduler
{
    public class Enums
    {
        // Master tables for list of cities.
        public enum City
        {
            Delhi = 0,
            Mumbai = 1,
            Kolkata = 2,
            Chennai = 3,
        }

        // Master tabel for list of teams.
        public enum Team
        {
            DelhiRiders = 0,
            MumbaiRiders = 1,
            KolkataRiders = 2,
            ChennaiRiders = 3,
        }

        // Master tabel for list of ground. 
        public enum Ground
        {
            FirozShah = 0,
            Shivaji = 1,
            Eden = 2,
            ChinnaSwami = 3,
            Unknown = 999
        }

        /// <summary>
        /// Configure the rules
        /// </summary>
        public enum RuleType
        {
            /// <summary>
            /// The basic
            /// </summary>
            Basic = 0,

            /// <summary>
            /// The home away fixture
            /// </summary>
            TwoMatchHomeAwayRule = 1
        }
    }
}
