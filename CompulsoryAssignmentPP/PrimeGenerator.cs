using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace CompulsoryAssignmentPP
{
    public class PrimeGenerator
    {

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
            List<long> primes = new List<long>();
            for (long i = first; i <= last; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }

            }

            return primes;
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