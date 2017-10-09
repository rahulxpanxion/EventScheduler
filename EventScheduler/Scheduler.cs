using System.Collections.Generic;
using System.Linq;

namespace EventScheduler
{
    public class Scheduler : IScheduler
    {
        /// <summary>
        /// The rule engine required to build schedule.
        /// </summary>
        private readonly IRuleFactory ruleFactory;

        /// <summary>
        /// The schedule printer
        /// </summary>
        private readonly ISchedulePrinter schedulePrinter;

        /// <summary>
        /// The context
        /// </summary>
        private readonly IRunContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Scheduler"/> class.
        /// </summary>
        public Scheduler(IRuleFactory ruleFactory, ISchedulePrinter printer, IRunContext runContext)
        {
            if (ruleFactory == null)
            {
                throw new SchedulerException("rule engine not instantiated properly.");
            }

            if (printer == null)
            {
                throw new SchedulerException("printer not instantiated properly.");
            }

            if (runContext == null)
            {
                throw new SchedulerException("printer not instantiated properly.");
            }

            this.ruleFactory = ruleFactory;
            this.schedulePrinter = printer;
            this.context = runContext;
        }

        /// <summary>
        /// Buils the schedule.
        /// </summary>
        /// <param name="teamDetails">The team details.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        IList<Fixture> IScheduler.GetSchedule()
        {
            return this.context.ExecuteAndHandleError(() =>
             {
                 var ruleEngine = this.ruleFactory.GetRuleEngine();
                 if (ruleEngine == null)
                 {
                     throw new SchedulerException("No rule engine was found");
                 }

                 var schedule = ruleEngine.BuilSchedule();

                 if (schedule == null || !schedule.Any())
                 {
                     throw new SchedulerException("No schedule was built");
                 }

                 this.schedulePrinter.PrintSchedule(schedule);

                 return schedule;
             });
        }
    }
}
