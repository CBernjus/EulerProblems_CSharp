﻿using System.Collections.Generic;
using System.Linq;
using EulerProblems.Meta;

namespace EulerProblems {

	[ProblemName("Even Fibonacci Numbers")]
	[ProblemSolution(4613732)]
	[ProblemDifficulty(5)]
	public static class Problem002 {

		// Each new term in the Fibonacci sequence is generated by adding the previous two terms.By starting with 1 and 2, the first 10 terms will be:

		// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

		// By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
		
		private const int Max = 4000000;

		public static object Solve() {
			return Fibonacci(Max).Where(i => i % 2 == 0).Sum();
		}

		public static int[] Fibonacci(int max) {
			var numbers = new List<int>();

			int fib = 0;
			int fib2 = 1;


			while(fib <= max) {
				numbers.Add(fib);

				int tmp = fib2;
				fib2 += fib;
				fib = tmp;
			}

			return numbers.ToArray();
		}
	}
}
