using System;
using System.Diagnostics;

namespace EulerProblems {
	class Problem019 {

		public const string Name = "Counting Sundays";

		// You are given the following information, but you may prefer to do some research for yourself.

		// - 1 Jan 1900 was a Monday.

		// - Thirty days has September,
		//	 April, June and November.
		//   All the rest have thirty-one,
		//   Saving February alone,
		//   Which has twenty-eight, rain or shine.
		//   And on leap years, twenty-nine.

		// - A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

		// How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?

		// Solution: 171

		public const int FirstYear = 1901;
		public const int LastYear = 2000;

		static readonly int[] Days = {
			-1, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
		};

		public static object Solve() {
			//return Lazy(FirstYear, LastYear);
			return Manual(FirstYear, LastYear);
		}

		static int Lazy(int startYear, int endYear) {
			int count = 0;
			for(int year = startYear; year <= endYear; year++)
				for(int month = 1; month <= 12; month++)
					if(new DateTime(year, month, 1).DayOfWeek == DayOfWeek.Sunday) count++;
			return count;
		}

		static int Manual(int startYear, int endYear) {
			bool IsLeapYear(int year) => year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);

			int DaysOfMonth(int year, int month) {
				if(month == 2 && IsLeapYear(year)) return 29;
				return Days[month];
			}

			int daysSince1900 = 1;
			int count = 0;

			for(int year = 1900; year <= endYear; year++) {
				for(int month = 1; month <= 12; month++) {
					Debug.Assert(DaysOfMonth(year, month) == DateTime.DaysInMonth(year, month));
					if(year >= startYear && daysSince1900 % 7 == 0) {
						Debug.Assert(new DateTime(year, month, 1).DayOfWeek == DayOfWeek.Sunday);
						count++;
					}
					daysSince1900 += DaysOfMonth(year, month);
				}
			}

			return count;
		}
	}
}
