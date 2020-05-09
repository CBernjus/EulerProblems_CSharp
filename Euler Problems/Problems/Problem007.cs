using System;
using System.Linq;
using EulerProblems.Meta;

namespace EulerProblems {

	[ProblemName("10001st Prime")]
	[ProblemSolution(104743)]
	[ProblemDifficulty(5)]
	public static class Problem007 {

		// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

		// What is the 10001st prime number?

		private const int Index = 10001;

		public static object Solve() {
			return GetPrimeAt(Index);
		}

		public static bool IsPrime(int n) {
			return Enumerable.Range(2, (int) Math.Sqrt(n) - 1).All(i => n % i != 0);
		}

		public static int GetPrimeAt(int index) {

			if(index <= 0) return -1;

			int i = 3;
			int prime = 2;
			int n = 1;

			while(n != index) {
				if(IsPrime(i)) {
					prime = i;
					n++;
				}

				i += 2;
			}

			return prime;
		}
	}
}
