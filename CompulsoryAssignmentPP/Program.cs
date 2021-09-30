using System;
using System.Diagnostics;

namespace CompulsoryAssignmentPP
{
    class Program
    {
        static void Main(string[] args)
        {
            long start = 1;
            long end = 1_000_000;

            PrimeGenerator pg = new PrimeGenerator();
            var list = pg.GetPrimesSequential(1, 1_000_000);
            TimeAction(() => pg.GetPrimesParallel(start, end));

            Console.WriteLine("Hello World!");
            
        }

        private static void TimeAction(Action action)
        {
            var sw = Stopwatch.StartNew();
            action.Invoke();
            sw.Stop();
            Console.WriteLine("Time: " + sw.ElapsedMilliseconds / 1000f);
        }
    }
}
