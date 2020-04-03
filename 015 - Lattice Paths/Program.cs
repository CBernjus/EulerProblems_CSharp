using System;
using System.Numerics;

namespace EulerProblems {
	public static class Program {

		// Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.

		// How many such routes are there through a 20×20 grid?

		public static BigInteger NumberOfPossibleLatticeRoutesInGridSlow(int width, int height) {
			return NumberOfPossibleLatticeRoutesWithEdgesSlow(new BigInteger(width + 1), new BigInteger(height + 1), 0);
		}

		public static BigInteger NumberOfPossibleLatticeRoutesWithEdgesSlow(BigInteger width, BigInteger height, BigInteger index) {

			BigInteger routes = 0;

			if(index == width * height - 1) routes++;

			if(index % width < width - 1) {
				routes += NumberOfPossibleLatticeRoutesWithEdgesSlow(width, height, index + 1);
			}

			if(index / width < height - 1) {
				routes += NumberOfPossibleLatticeRoutesWithEdgesSlow(width, height, index + width);
			}

			return routes;
		}

		public static BigInteger Factorial(BigInteger number) {
			BigInteger result = 1;
			while(number != 1) {
				result = result * number;
				number = number - 1;
			}
			return result;
		}

		public static BigInteger NumberOfPossibleLatticeRoutesInGrid(int width, int height) {
			BigInteger bigWidth = new BigInteger(width);
			BigInteger bigHeight = new BigInteger(height);

			return (Factorial(bigWidth + bigHeight) / (Factorial(bigWidth) * Factorial(bigHeight)));
		}


		public static void Main(string[] args) {

			Console.WriteLine(NumberOfPossibleLatticeRoutesInGrid(20, 20));
			Console.ReadLine();

		}
	}
}
