using System;
using System.Linq;
using EulerProblems.Meta;

namespace EulerProblems {

	[ProblemName("Largest Palindrome Product")]
	[ProblemSolution(906609)]
	[ProblemDifficulty(5)]
	public static class Problem004 {

		// A palindromic number reads the same both ways.The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

		// Find the largest palindrome made from the product of two 3-digit numbers.

		private const int Digits = 3;

		public static object Solve() {
			return GetLargestPalindromeProduct(Digits);
		}

		public static bool IsPalindrome(long n) {
			return n.ToString().Reverse().SequenceEqual(n.ToString());
		}

		public static long GetLargestPalindromeProduct(int digits) {

			long from = (long) Math.Pow(10, digits) - 1;
			long to   = (long) Math.Pow(10, digits - 1);

			long max = 0;

			for(long i = from; i >= to; i--) {
				if(max > i * from) break;
				for(long j = from; j >= i; j--) {
					long product = i * j;
					if(product > max && IsPalindrome(product)) max = product;
				}
			}

			return max;
		}
	}
}
