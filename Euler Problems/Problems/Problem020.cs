using System.Linq;
using System.Numerics;
using EulerProblems.Meta;

namespace EulerProblems {

	[ProblemName("Factorial Digit Sum")]
	[ProblemSolution(648)]
	[ProblemDifficulty(5)]
	class Problem020 {

		// n! means n × (n − 1) × ... × 3 × 2 × 1

		// For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
		// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

		// Find the sum of the digits in the number 100!

		private const int N = 100;

		public static object Solve() {
			return Enumerable.Range(1, N).Select(x => new BigInteger(x)).Aggregate(BigInteger.Multiply).ToString().Select(char.GetNumericValue).Sum();
		}
	}
}
