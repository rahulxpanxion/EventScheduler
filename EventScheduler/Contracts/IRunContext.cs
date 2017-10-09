using System;

namespace EventScheduler
{
    public interface IRunContext
    {
        T ExecuteAndHandleError<T>(Func<T> method);
    }
}