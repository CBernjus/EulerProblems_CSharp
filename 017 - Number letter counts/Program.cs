using System;
using System.Linq;

namespace EulerProblems {
	class Program {

		// If the numbers 1 to 5 are written out in words: one, two, three, four, five,
		// then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

		// If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words,
		// how many letters would be used?

		// NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters
		// and 115 (one hundred and fifteen) contains 20 letters.
		// The use of "and" when writing out numbers is in compliance with British usage.

		static readonly string[] FirstTwenty = {
			"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
			"ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
		};

		static readonly string[] Tens = {
			null, null, "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
		};

		static string ToWords(int number) {
			if(number == 1000) return "one thousand";

			if(number >= 100) return FirstTwenty[number / 100] + " hundred" +
					(number % 100 == 0 ? "" : " and " + ToWords(number % 100));

			if(number < 20) return FirstTwenty[number];

			return Tens[number / 10] + (number % 10 == 0 ? "" : "-" + FirstTwenty[number % 10]);
		}

		static int CountLetters(string text) => text.Count(char.IsLetter);

		static void Main(string[] args) {
			Console.WriteLine(Enumerable.Range(1, 1000).Select(ToWords).Select(CountLetters).Sum());
			foreach(string s in Enumerable.Range(1, 1000).Select(ToWords)) {
				Console.WriteLine(s);
			}
		}

		// Solution: 21124
	}
}
