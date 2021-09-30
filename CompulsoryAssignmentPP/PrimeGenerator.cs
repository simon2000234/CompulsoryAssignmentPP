using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using System.Threading.Tasks;

namespace CompulsoryAssignmentPP
{
    public class PrimeGenerator
    {
        public Object lockThing = new object();

        public List<long> GetPrimesSequential(long first, long last)
        {
            Stopwatch sw = new Stopwatch();
            List<long> list = new List<long>();

            sw.Start();
            for (long i = first; i < last; i++)
            {
                bool result = IsPrime(i);
                if (result == true)
                {
                    list.Add(i);
                }
            }

            sw.Stop();
            System.Console.WriteLine("Seq Time = " + sw.ElapsedMilliseconds / 1000);
            return list;
        }


        public List<long> GetPrimesParallel(long first, long last)
        {
            List<long> primesParallel = new List<long>();

            Parallel.ForEach(Partitioner.Create(first, last), range =>
            {
                for (long i = range.Item1; i < range.Item2; i++)
                {
                    bool isPrime = IsPrime(i);
                    if (isPrime)
                    {
                        lock (lockThing)
                        {
                            primesParallel.Add(i);
                        }
                    }
                }
            });
            primesParallel.Sort();

            return primesParallel;
        }

        private bool IsPrime(long number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;


            var boundary = number / 2;

            for (long i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}