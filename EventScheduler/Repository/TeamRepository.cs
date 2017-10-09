using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventScheduler
{
    //TODO : Integrate with ORM.
    public class TeamRepository : IRepository<TeamDetail>
    {
        public void Add(TeamDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TeamDetail Get()
        {
            throw new NotImplementedException();
        }

        public TeamDetail Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<TeamDetail> Get(Expression<Func<TeamDetail, bool>> filter = null)
        {
            if (filter != null)
            {
                return TestDatabase.TeamDetails.Where(filter).ToList();

            }

            return TestDatabase.TeamDetails.ToList();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
