using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _025___1000_Digit_Fibonacci_Number {
	class Program {

		// The Fibonacci sequence is defined by the recurrence relation:

		// Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
		// Hence the first 12 terms will be:

		// F0 = 0
		// F1 = 1
		// F2 = 1
		// F3 = 2
		// F4 = 3
		// F5 = 5
		// F6 = 8
		// F7 = 13
		// F8 = 21
		// F9 = 34
		// F10 = 55
		// F11 = 89
		// F12 = 144
		// The 12th term, F12, is the first term to contain three digits.

		// What is the index of the first term in the Fibonacci sequence to contain 1000 digits?

		// Solution: 4782

		private const int Digits = 1000;

		static void Main(string[] args) {
			Console.WriteLine("Problem 025 - 1000-Digit Fibonacci Number");

			BigInteger result = IndexOfFirstNumberWithNDigits(Fibonacci(), Digits);

			Console.WriteLine("Solution: " + result);
		}

		static BigInteger IndexOfFirstNumberWithNDigits(IEnumerable<BigInteger> numbers, int digits) {
			return numbers.Select((n, i) => (n, i)).First(t => (int) Math.Floor(BigInteger.Log10(t.n) + 1) == digits).i;
		}

		static IEnumerable<BigInteger> Fibonacci() {
			BigInteger f2 = 0;
			BigInteger f1 = 1;
			yield return f2;
			yield return f1;
			while(true) {
				var f = f2 + f1;
				yield return f;
				f2 = f1;
				f1 = f;
			}
		}
	}
}
