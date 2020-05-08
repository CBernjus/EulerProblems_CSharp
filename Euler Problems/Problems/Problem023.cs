using System.Linq;

namespace EulerProblems {
	class Problem023 {

		public const string Name = "Non-Abundant Sums";

		// A perfect number is a number for which the sum of its proper divisors is exactly equal to the number.
		// For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

		// A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.

		// As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16,
		// the smallest number that can be written as the sum of two abundant numbers is 24.

		// By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers.
		// However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number
		// that cannot be expressed as the sum of two abundant numbers is less than this limit.

		// Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.

		// Solution: 4179871

		private const int Max = 28123;

		public static object Solve() {
			int[] divisorSums = CalculateDivisorSums(Max);
			int[] abundantNumbers = divisorSums.Select((v, i) => v > i ? i : -1).Where(v => v >= 0).ToArray();

			bool[] abundantSum = new bool[Max];
			
			foreach(int a in abundantNumbers) {
				foreach(int b in abundantNumbers) {
					if(a + b >= Max) break;
					abundantSum[a + b] = true;
				}
			}

			return abundantSum.Select((b, i) => b ? 0 : i).Sum();
		}

		static int[] CalculateDivisorSums(int n) {
			var divisorSums = new int[n];
			for(int i = 1; i <= n / 2; i++) {
				for(int j = i * 2; j < n; j += i) {
					divisorSums[j] += i;
				}
			}
			return divisorSums;
		}
	}
}
