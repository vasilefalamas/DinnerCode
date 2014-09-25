using System;

namespace PrimeFactorsGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = PrimeFactors.Generate(-10);
            var result2 = PrimeFactors.GenerateAsUncleBob(-177);


            result.ForEach(Console.WriteLine);
        }
    }
}
