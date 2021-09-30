using System;

namespace CompulsoryAssignmentPP
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeGenerator primeGenerator = new PrimeGenerator();
            var list = primeGenerator.GetPrimesSequential(1, 1_000_000);


        }
    }
}
