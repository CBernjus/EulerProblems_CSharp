using System;
using EulerProblems.Meta;

namespace EulerProblems {

	[ProblemName("Special Pythagorean Triplet")]
	[ProblemSolution(31875000)]
	[ProblemDifficulty(5)]
	public static class Problem009 {

		// A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
		// a^2 + b^2 = c^2

		// For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.

		// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
		// Find the product abc.

		private const int Sum = 1000;

		public static object Solve() {
			return SpecialPythagoreanTriple(Sum);
		}

		public static int HasIntSqrt(int x) {
			double sqrt = Math.Sqrt(x);
			if(Math.Floor(sqrt) == sqrt) {
				return (int) sqrt;
			} else return -1;
		}

		public static int SpecialPythagoreanTriple(int sum) {
			for(int a = 1; a <= (sum / 3 + 1); a++) {
				for(int b = a + 1; b <= (sum / 2 + 1); b++) {

					int c2 = a * a + b * b;
					int c = HasIntSqrt(c2);

					if(c == -1) continue;

					if(a + b + c == sum) {
						return a * b * c;
					}
				}
			}

			return -1;
		}
	}
}
