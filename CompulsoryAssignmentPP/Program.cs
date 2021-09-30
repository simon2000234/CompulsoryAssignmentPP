using System;
using System.Diagnostics;

namespace CompulsoryAssignmentPP
{
    class Program
    {
        static void Main(string[] args)
        {
            long start = 1;
            long end = 10000;

            PrimeGenerator pg = new PrimeGenerator();
            TimeAction(() => pg.GetPrimesParallel(start, end).ForEach(prime => Console.WriteLine(""+prime)));

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
