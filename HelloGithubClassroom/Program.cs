using System;
using System.Collections;
using System.Collections.Generic;

namespace HelloGithubClassroom
{
    
    public class PrimeEnumerator : IEnumerator<long>
    {

        public long Current { get; private set; } = 2;
        
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Current == 100) // <-- Set limit here
            {
                Console.WriteLine("--reached long overflow--");
                return false;
            }
            Current++;
            return true;
        }

        public void Reset()
        {
            Current = 0;
        }

        public void Dispose()
        {
        }
    }
    
    // --------------------------------------------------------
    // ---------------------------------------------------------
    
    public class PrimeEnumerable : IEnumerable<long>
    {

        IEnumerator<long> IEnumerable<long>.GetEnumerator()
        {
            return new PrimeEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return new PrimeEnumerator();
        }
        
        

        private static bool IsPrime(object numberPassed)
        {
            var number = 0L;
            number = (long) numberPassed;
            
            if (number < 2) return false;
            if (number % 2 == 0) return (number == 2);
            int root = (int)Math.Sqrt((double)number);
            for (int i = 3; i <= root; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        public static void Main(string[] args)
        {
            var primeEnumerable = new PrimeEnumerable();

            var enumerator = primeEnumerable.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                if (IsPrime(enumerator.Current))
                {
                    Console.WriteLine($"Prime number: {enumerator.Current}");
                }
            }
        }
    }

}
