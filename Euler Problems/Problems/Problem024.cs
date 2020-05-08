using System.Collections.Generic;
using System.Linq;

namespace EulerProblems {
	class Problem024 {

		public const string Name = "Lexicographic Permutations";

		// A permutation is an ordered arrangement of objects.

		// For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4.
		// If all of the permutations are listed numerically or alphabetically, we call it lexicographic order.
		// The lexicographic permutations of 0, 1 and 2 are:

		// 012, 021, 102, 120, 201, 210

		// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?

		// Solution: 2783915460

		private const string Elements = "0123456789";
		private const int RequestedIndex = 1000000;

		public static object Solve() {
			return string.Concat(NthLexicographicPermutationOf(Elements.OrderBy(ch => ch), RequestedIndex - 1));
		}

		private static IEnumerable<T> NthLexicographicPermutationOf<T>(IOrderedEnumerable<T> elems, int n) {
			var list = elems.ToList();
			var result = new List<T>();

			var factorials = CalculateFactorials(list.Count);

			while(list.Any()) {
				// p: the number of permutations of all elements to the right of the current one
				int p = factorials[list.Count - 1];
				int i = n / p;
				n %= p;
				result.Add(list[i]);
				list.RemoveAt(i);
			}

			return result;
		}

		private static int[] CalculateFactorials(int max) {
			var factorials = new int[max + 1];
			factorials[0] = 1;

			for(int i = 1; i < factorials.Length; i++) {
				factorials[i] = factorials[i - 1] * i;
			}

			return factorials;
		}
	}
}
