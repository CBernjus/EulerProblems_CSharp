using System.IO;
using System.Linq;

namespace EulerProblems {
	class Problem022 {

		public const string Name = "Names Scores";

		// Using names.txt, a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order.
		// Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

		// For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list.
		// So, COLIN would obtain a score of 938 × 53 = 49714.

		// What is the total of all the name scores in the file?

		// Solution: 871198282

		private const string InputPath = @"Resources\022-names.txt";

		public static object Solve() {
			var names = File.ReadAllText(InputPath).Split(',').Select(name => name.Trim('"')).ToList();
			names.Sort();

			return names.Select(AlphabeticalValue).Select((a, i) => a * (i + 1)).Sum();
		}

		static long AlphabeticalValue(string name) {
			return name.Select(ch => ch - 'A' + 1).Sum();
		}
	}
}
