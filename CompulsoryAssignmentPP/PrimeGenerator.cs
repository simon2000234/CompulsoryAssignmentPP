using System.Numerics;

namespace CompulsoryAssignmentPP
{
    public class PrimeGenerator
    {











        private static bool IsPrime(BigInteger number)
        {
            if (number <= BigInteger.One) return false;
            if (number == (BigInteger)2) return true;
            if (number % 2 == BigInteger.Zero) return false;


            var boundary = BigInteger.Divide(number, 2);

            for (BigInteger i = 3; i <= boundary; i += 2)
                if (number % i == BigInteger.Zero)
                    return false;

            return true;
        }
    }
}