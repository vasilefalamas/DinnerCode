using System;
using System.Collections.Generic;

namespace PrimeFactorsGeneration
{
    public class PrimeFactors
    {
        public static List<int> Generate(int input)
        {
            var primeFactors = new List<int>();

            if (input <= 1)
            {
                throw new ArgumentException("The input was invalid.");
            }

            var divisor = 2;

            while (input > 1)
            {
                if (input % divisor == 0)
                {
                    primeFactors.Add(divisor);

                    input /= divisor;

                    continue;
                }

                divisor++;
            }

            return primeFactors;
        }

        public static List<int> GenerateAsUncleBob(int input)
        {
            var primeFactors = new List<int>();

            int divisor = 2;

            while (input > 1)
            {
                for (; input % divisor == 0; input /= divisor)
                {
                    primeFactors.Add(divisor);
                }

                divisor++;
            }

            return primeFactors;
        }
    }
}
