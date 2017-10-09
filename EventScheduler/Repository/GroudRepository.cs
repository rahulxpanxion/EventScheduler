using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventScheduler
{
    //TODO : Integrate with ORM.
    public class GroundRepository : IRepository<GroundDetail>
    {
        public void Add(GroundDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public GroundDetail Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<GroundDetail> Get(Expression<Func<GroundDetail, bool>> filter)
        {
            if (filter != null)
                return TestDatabase.GroundDetails.Where(filter).ToList();

            return TestDatabase.GroundDetails.ToList();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
