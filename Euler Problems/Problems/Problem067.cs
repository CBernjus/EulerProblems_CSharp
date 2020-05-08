using System;
using System.IO;
using System.Linq;

namespace EulerProblems {
	class Problem067 {

		public const string Name = "Maximum Path Sum II";

		// By starting at the top of the triangle below and moving to adjacent numbers on the row below,
		// the maximum total from top to bottom is 23.

		// 3
		// 7 4
		// 2 4 6
		// 8 5 9 3

		// That is, 3 + 7 + 4 + 9 = 23.

		// Find the maximum total from top to bottom in triangle.txt(right click and 'Save Link/Target As...'),
		// a 15K text file containing a triangle with one-hundred rows.

		// NOTE: This is a much more difficult version of Problem 18.
		// It is not possible to try every route to solve this problem, as there are 2^99 altogether!
		// If you could check one trillion (1012) routes every second it would take over twenty billion years to check them all.
		// There is an efficient algorithm to solve it. ; o)

		// Solution: 7273

		private const string InputPath = @"Resources\067-triangle.txt";

		public static object Solve() {
			var triangle = File.ReadAllText(InputPath)
				.Split('\n')
				.Select(row => row.Split(' ')
					.Select(int.Parse).ToArray()).ToArray();

			return LongestPathFast(0, 0, triangle);
		}

		static int LongestPathFast(int row, int column, int[][] triangle) {
			for(int r = triangle.Length - 2; r >= 0; r--) {

				for(int c = 0; c < triangle[r].Length; c++) {

					triangle[r][c] += Math.Max(triangle[r + 1][c], triangle[r + 1][c + 1]);
				}
			}
			return triangle[row][column];
		}
	}
}
