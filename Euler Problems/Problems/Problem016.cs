using System.Linq;
using System.Numerics;
using EulerProblems.Meta;

namespace EulerProblems {

	[ProblemName("Power Digit Sum")]
	[ProblemSolution(1366)]
	[ProblemDifficulty(5)]
	public static class Problem016 {

		// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

		// What is the sum of the digits of the number 2^1000?

		private static readonly BigInteger Number = BigInteger.One << 1000;

		public static object Solve() {
			return Number.ToString().Select(char.GetNumericValue).Sum();
		}

	}
}
