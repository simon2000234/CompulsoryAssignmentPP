using System.Collections.Generic;
using System.Numerics;

namespace CompulsoryAssignmentPP
{
    public class PrimeGenerator
    {

        public List<long> GetPrimesSequential(long first, long last)
        {

        }


        public List<long> GetPrimesParallel(long first, long last)
        {

        }





        private static bool IsPrime(long number)
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