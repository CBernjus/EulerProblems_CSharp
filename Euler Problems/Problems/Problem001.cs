using System.Collections.Generic;
using System.Linq;
using EulerProblems.Meta;

namespace EulerProblems {
	[ProblemName("Multiples Of 3 And 5")]
	[ProblemSolution(233168)]
	[ProblemDifficulty(5)]
	public static class Problem001 {

		// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

		// Find the sum of all the multiples of 3 or 5 below 1000.

		private const int Max = 1000;

		public static object Solve() {
			return AlsoTheMultiplesOf3And5(Max).Sum();
		}

		public static int[] MultiplesOf3And5(int max) {
			var numbers = new List<int>();

			for(int i = 0; i < max; i++) {
				if(i % 3 == 0 || i % 5 == 0) numbers.Add(i);
			}

			return numbers.ToArray();
		}

		public static IEnumerable<int> AlsoTheMultiplesOf3And5(int max) {
			return Enumerable.Range(1, max - 1).Where(i => i % 3 == 0 || i % 5 == 0);
		}

	}
}
