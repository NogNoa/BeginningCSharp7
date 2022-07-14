using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11Ex03
{
    public class Primes
    {
        private long min;
        private long max;
        public Primes() : this(2, 100) { }
        public Primes(long minimum, long maximum)
        {
            if (minimum < 2)
                min = 2;
            else
                min = minimum;
            max = maximum;
        }
        public IEnumerator GetEnumerator()
        {
            for (long possiblePrime = min; possiblePrime <= max; possiblePrime++)
            {
                bool isPrime = true;
                long limit = (long)Math.Floor(Math.Sqrt(possiblePrime));
                for (long possibleFactor = 2; possibleFactor <= limit; possibleFactor++)
                {
                    if (possiblePrime % possibleFactor == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    yield return possiblePrime;
                }
            }
        }
    }
}
