using System.Linq;
using EulerProblems.Meta;

namespace EulerProblems {

	[ProblemName("Smallest Multiple")]
	[ProblemSolution(232792560)]
	[ProblemDifficulty(5)]
	public static class Problem005 {

		// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

		// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
		
		private const int Max = 20;

		public static object Solve() {
			return SmallestCommonMultipleOf(Enumerable.Range(1, Max).ToArray());
		}

		public static long SmallestCommonMultipleOf(int[] numbers) {

			checked {

				for(int i = 0; i < numbers.Length; i++) {
					if(numbers[i] == 0) return 0;
					if(numbers[i] < 0) {
						numbers[i] *= -1;
					}
				}

				long lcm = 1;
				int divisor = 2;

				while(true) {
					int counter = 0;
					bool divisible = false;

					for(int i = 0; i < numbers.Length; i++) {
						if(numbers[i] == 1) counter++;

						if(numbers[i] % divisor == 0) {
							divisible = true;
							numbers[i] /= divisor;
						}
					}

					if(divisible) {
						lcm = lcm * divisor;
					} else {
						divisor += 1;
					}

					if(counter == numbers.Length) {
						return lcm;
					}

				}
			}

		}

	}
}
