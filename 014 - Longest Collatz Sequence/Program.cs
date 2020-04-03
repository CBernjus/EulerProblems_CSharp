using System;
using System.Linq;
using System.Numerics;

namespace EulerProblems {
	public static class Program {

		// The following iterative sequence is defined for the set of positive integers:

		// n → n/2 (n is even)
		// n → 3n + 1 (n is odd)

		// Using the rule above and starting with 13, we generate the following sequence:

		// 13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
		// It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

		// Which starting number, under one million, produces the longest chain?

		// NOTE: Once the chain starts the terms are allowed to go above one million.

		public static BigInteger NextCollatzNumber(BigInteger n) {
			if(n <= 0) return -1;

			if(n % 2 == 0) {
				return n / 2;
			} else {
				return 3 * n + 1;
			}
		}

		public static int GetCollatzSeqLength(BigInteger start) {

			int length = 1;
			
			while(start != 1) {
				if(start <= 0) {
					Console.WriteLine("-1");
					return -1;
				}
				// Console.Write("{0} -> ", start);
				start = NextCollatzNumber(start);
				length++;
			}

			// Console.WriteLine("{0}", start);

			return length;
		}

		public static void Main() {

			var n = 1000000;

			Console.WriteLine(Enumerable.Range(1, n).Select(i => new {Index = i, Value = GetCollatzSeqLength(i)}).Aggregate((a, b) => (a.Value > b.Value) ? a : b).Index);
			Console.ReadLine();

		}
	}
}
