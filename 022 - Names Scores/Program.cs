using System;
using System.IO;
using System.Linq;

namespace _022___Names_Scores {
	class Program {

		// Using names.txt, a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order.
		// Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

		// For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list.
		// So, COLIN would obtain a score of 938 × 53 = 49714.


		// What is the total of all the name scores in the file?

		static void Main(string[] args) {
			var names = File.ReadAllText("names.txt").Split(',').Select(name => name.Trim('"')).ToList();
			names.Sort();

			long totalNameScore = names.Select(AlphabeticalValue).Select((a, i) => a * (i + 1)).Sum();

			Console.WriteLine(totalNameScore);
		}

		static long AlphabeticalValue(string name) {
			return name.Select(ch => ch - 'A' + 1).Sum();
		}

		// Solution: 871198282
	}
}
