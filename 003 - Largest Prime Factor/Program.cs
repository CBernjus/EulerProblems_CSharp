using System;
using System.Collections.Generic;
using System.Linq;

namespace EulerProblems {
	public static class Program {

		// The prime factors of 13195 are 5, 7, 13 and 29.

		// What is the largest prime factor of the number 600851475143 ?

		public static long[] PrimeFactorsOf(long n) {

			var factors = new List<long>();

			// n is even
			while(n % 2 == 0) {
				factors.Add(2);
				n /= 2;
			}

			// n is odd
			for(long i = 3; i <= Math.Sqrt(n); i += 2) {
				while(n % i == 0) {
					factors.Add(i);
					n /= i;
				}
			}

			// if n is a prime > 2
			if(n > 2) factors.Add(n);

			return factors.ToArray();
		}

		public static void Main() {

			Console.WriteLine(PrimeFactorsOf(600851475143).Last());
			Console.ReadLine();

		}
	}
}
