using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventScheduler
{
    //TODO : Integrate with ORM.
    public class RuleRepository : IRepository<FixtureSettings>
    {
        public void Add(FixtureSettings entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<FixtureSettings> Get(Expression<Func<FixtureSettings, bool>> filter = null)
        {
            if (filter != null)
            {
                return TestDatabase.GetRules.Where(filter).ToList();

            }

            return TestDatabase.GetRules.ToList();
        }

        public FixtureSettings Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
