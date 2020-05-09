using System;
using System.Linq;
using EulerProblems.Meta;

namespace EulerProblems {

	[ProblemName("Summation Of Primes")]
	[ProblemSolution(142913828922)]
	[ProblemDifficulty(5)]
	public static class Problem010 {

		// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

		// Find the sum of all the primes below two million.

		private const int Max = 2000000;

		public static object Solve() {
			return SumOfPrimes(Max);
		}

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
	}
}
