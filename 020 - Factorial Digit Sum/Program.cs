using System;
using System.Linq;
using System.Numerics;

namespace _020___Factorial_Digit_Sum {
	class Program {

		// n! means n × (n − 1) × ... × 3 × 2 × 1
		
		// For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
		// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

		// Find the sum of the digits in the number 100!

		static void Main(string[] args) {

			int n = 100;

			Console.WriteLine(Enumerable.Range(1, n).Select(x => new BigInteger(x)).Aggregate(BigInteger.Multiply).ToString().Select(char.GetNumericValue).Sum());

		}

		// Solution: 468

	}
}
