using System;
using System.Collections.Generic;
using System.Linq;

namespace EulerProblems {
	public static class Program {

		// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

		// Find the sum of all the multiples of 3 or 5 below 1000.

		public static int[] MultiplesOf3And5(int max) {
			var numbers = new List<int>();

			for(int i = 0; i < max; i++) {
				if(i % 3 == 0 || i % 5 == 0) numbers.Add(i);
			}

			return numbers.ToArray();
		}

		public static IEnumerable<int> AlsoTheMultiplesOf3And5(int max) {
			return Enumerable.Range(1, max).Where(i => i % 3 == 0 || i % 5 == 0);
		}

		public static void Main() {

			var x = AlsoTheMultiplesOf3And5(1000);
			Console.WriteLine(MultiplesOf3And5(1000).Sum());
			Console.ReadLine();

		}
	}
}
