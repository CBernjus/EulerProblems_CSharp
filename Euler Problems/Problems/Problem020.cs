using System.Linq;
using System.Numerics;

namespace EulerProblems {
	class Problem020 {

		public static string Name = "Factorial Digit Sum";

		// n! means n × (n − 1) × ... × 3 × 2 × 1

		// For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
		// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

		// Find the sum of the digits in the number 100!

		// Solution: 648

		private const int N = 100;

		public static object Solve() {
			return Enumerable.Range(1, N).Select(x => new BigInteger(x)).Aggregate(BigInteger.Multiply).ToString().Select(char.GetNumericValue).Sum();
		}
	}
}
