using System;
using System.Collections.Generic;

namespace EventScheduler
{
    public class ConsolePrinter : ISchedulePrinter
    {
        /// <summary>
        /// Prints the schedule.
        /// </summary>
        /// <param name="fixtures">The fixtures.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void PrintSchedule(IList<Fixture> fixtures)
        {
            Console.WriteLine("******ProKabbadi Match Fixtures**********");

            foreach (var fixture in fixtures)
            {
                Console.WriteLine("**************");
                Console.WriteLine($"Day :: {fixture.DayNo}  :::  Match {fixture.MatchNumber}");
                Console.WriteLine($"{fixture.Clash.TeamA.Name} Vs {fixture.Clash.TeamB.Name}    At :: {fixture.Clash.Ground}");
                Console.WriteLine("**************");
                Console.WriteLine("**************");
            }

            Console.WriteLine("******Finished********");
            Console.ReadKey();
        }
    }
}
