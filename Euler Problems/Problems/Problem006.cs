using System;

namespace EulerProblems {
	public static class Problem006 {

		public const string Name = "Sum Square Difference";

		// The sum of the squares of the first ten natural numbers is,
		// 1^2 + 2^2 + ... + 10^2 = 385

		// The square of the sum of the first ten natural numbers is,
		// (1 + 2 + ... + 10)^2 = 552 = 3025

		// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.

		// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

		// Solution: 25164150

		private const int Max = 100;

		public static object Solve() {
			return SumSquareDifference(Max);
		}

		public static int SumSquareDifference(int max) {
			int sumOfSquares = 0;
			int squareOfSums = 0;

			for(int i = 1; i <= max; i++) {
				sumOfSquares += i * i;
				squareOfSums += i;
			}

			squareOfSums *= squareOfSums;

			return Math.Abs(sumOfSquares - squareOfSums);
		}

	}
}
