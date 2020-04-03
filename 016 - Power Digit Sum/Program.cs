using System;
using System.Linq;
using System.Numerics;

namespace EulerProblems {
	public static class Program {

		// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

		// What is the sum of the digits of the number 2^1000?

		public static void Main() {

			BigInteger input = (BigInteger.One << 1000);
			
			Console.WriteLine(input);
			Console.WriteLine(input.ToString().Select(char.GetNumericValue).Sum());
			Console.ReadLine();

		}

		// Solution: 1366

	}
}
