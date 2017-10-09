using System;

namespace EventScheduler
{
    class RunContext : IRunContext
    {
        /// <summary>
        /// Executes the and handle error.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        /// <exception cref="EventScheduler.SchedulerException">An unhandled exception occured in the sceduler</exception>
        /// <remarks>Handle all </remarks>
        T IRunContext.ExecuteAndHandleError<T>(Func<T> method)
        {
            try
            {
                return method();
            }
            catch (RepositoryException)
            {
                throw;
            }
            catch (PrinterException)
            {
                throw;
            }
            catch (SchedulerException)
            {
                throw;
            }
            catch (RuleException)
            {
                throw;
            }
            catch (Exception ex)
            {
                // Throw a scheduler exception or handle this in any  way that we want.
                throw new SchedulerException("An unhandled exception occured in the sceduler", ex);
            }
        }
    }
}
