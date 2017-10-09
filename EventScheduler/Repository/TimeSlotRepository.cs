using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventScheduler
{
    //TODO : Integrate with ORM.
    public class TimeSlotRepository : IRepository<TimeSlot>
    {
        public void Add(TimeSlot entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<TimeSlot> Get(Expression<Func<TimeSlot, bool>> filter)
        {
            if (filter != null)
            {
                return TestDatabase.TimeSlots.Where(filter).ToList();

            }

            return TestDatabase.TimeSlots.ToList();
        }

        public TimeSlot Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
