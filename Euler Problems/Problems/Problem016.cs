﻿using System.Linq;
using System.Numerics;

namespace EulerProblems {
	public static class Problem016 {

		public const string Name = "Power Digit Sum";

		// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

		// What is the sum of the digits of the number 2^1000?

		// Solution: 1366

		private static readonly BigInteger Number = BigInteger.One << 1000;

		public static object Solve() {
			return Number.ToString().Select(char.GetNumericValue).Sum();
		}

	}
}
