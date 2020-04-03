using System;
using System.Linq;

namespace EulerProblems {
	public static class Program {

		// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

		// Find the sum of all the primes below two million.

		public static bool IsPrime(int n) {
			return Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i != 0);
		}

		public static long SumOfPrimes(int under) {

			if(under <= 0) return -1;

			long sum = 2;

			var i = 3;
			while(i <= under) {
				if(IsPrime(i)) {
					sum += i;
				}
				i += 2;
			}

			return sum;
		}

		public static void Main() {

			Console.WriteLine(SumOfPrimes(under: 2000000));
			Console.ReadLine();

		}
	}
}
