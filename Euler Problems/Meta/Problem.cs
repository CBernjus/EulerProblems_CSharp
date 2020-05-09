using System;
using System.Linq;
using System.Reflection;

namespace EulerProblems.Meta {
	class Problem {
		public readonly Type ProblemType;
		public readonly MethodInfo SolveMethod;
		public readonly string Name;
		public readonly object Solution;
		public readonly int Difficulty;
		public readonly int Number;

		public Problem(Type problemType) {
			ProblemType = problemType;
			SolveMethod = GetSolveMethod(problemType);
			Number = int.Parse(problemType.Name.Substring(7));
			Name = problemType.GetAttribute<ProblemNameAttribute>().Name;
			Solution = problemType.GetAttribute<ProblemSolutionAttribute>().Solution;
			Difficulty = problemType.GetAttribute<ProblemDifficultyAttribute>().Difficulty;
		}

		public Problem(string typeName) : this(Type.GetType(typeName) ?? throw new Exception("Type not found: " + typeName)) { }

		public Problem(int problemNo) : this($"EulerProblems.Problem{problemNo:D3}") { }

		public void Test() {
			Console.Write($"Testing problem {Number} - {Name}... ");
			try {
				var result = Solve();
				// TODO hacky fix with ToString
				if(Equals(Solution.ToString(), result.ToString())) {
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("success");
				}
				else {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"failed: expected {Solution}, got {result}");
				}
			}
			catch(Exception e) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine(e.GetType().Name);
			}
			Console.ResetColor();
		}

		public void Run() {
			Console.WriteLine();
			Console.WriteLine($"Problem {Number} - {Name} ({Difficulty}%)");
			Console.WriteLine($"Solution: {Solve()}");
		}

		public object Solve() {
			return SolveMethod.Invoke(null, new object[0]);
		}

		private static MethodInfo GetSolveMethod(Type problemType) {
			var solveMethod = problemType.GetMethod("Solve", BindingFlags.Static | BindingFlags.Public);
			if(solveMethod == null) throw new Exception("Type " + problemType + " does not contain a public static Solve method");
			if(solveMethod.ReturnType == typeof(void)) throw new Exception("Solve method must return something");
			if(solveMethod.GetParameters().Any()) throw new Exception("Solve method must not have any parameters");
			return solveMethod;
		}
	}
}