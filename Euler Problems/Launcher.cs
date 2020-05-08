using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EulerProblems {
	class Launcher {
		public static void Main(string[] args) {

			LaunchAll();
			return;
			
			if(args.Length == 0) {
				ListProblems();
				LaunchProblem(ReadInt("Please enter the problem number: "));
				return;
			}

			if(args.Length == 1 && int.TryParse(args[0], out int problem)) {
				LaunchProblem(problem);
				return;
			}

			Console.WriteLine("Usage: EulerProblems.exe [problem no]");
		}

		public static void ListProblems() {
			Console.WriteLine("Available problems:");
			foreach(var type in GetProblemTypes()) {
				Console.WriteLine("  Problem " + type.Name.Substring(7) + ": " + GetProblemName(type));
			}
		}

		public static void LaunchProblem(int problemNo) {
			var problemType = GetProblemType(problemNo);
			LaunchProblem(problemType);
		}

		public static void LaunchProblem(Type problemType) {
			var solveMethod = GetSolveMethod(problemType);
			string name = GetProblemName(problemType);
			object result = solveMethod.Invoke(null, new object[0]);

			Console.WriteLine();
			Console.WriteLine($"Problem {problemType.Name.Substring(7)} - " + name);
			Console.WriteLine($"Solution: {result}");
		}

		public static void LaunchAll() {
			foreach(var problemType in GetProblemTypes()) {
				LaunchProblem(problemType);
			}
		}

		private static IEnumerable<Type> GetProblemTypes() {
			return typeof(Problem001).Assembly.GetTypes().Where(type => type.Name.StartsWith("Problem"));
		}

		private static Type GetProblemType(int problemNo) {
			string className = $"EulerProblems.Problem{problemNo:D3}";
			var type = Type.GetType(className);
			if(type == null) throw new Exception("Type not found: " + className);
			return type;
		}

		private static MethodInfo GetSolveMethod(Type problemType) {
			var solveMethod = problemType.GetMethod("Solve", BindingFlags.Static | System.Reflection.BindingFlags.Public);
			if(solveMethod == null) throw new Exception("Type " + problemType + " does not contain a public static Solve method");
			if(solveMethod.ReturnType == typeof(void)) throw new Exception("Solve method must return something");
			if(solveMethod.GetParameters().Any()) throw new Exception("Solve method must not have any parameters");
			return solveMethod;
		}

		private static string GetProblemName(Type problemType) {
			var nameField = problemType.GetField("Name", BindingFlags.Static | System.Reflection.BindingFlags.Public);
			if(problemType == null) throw new Exception("Type " + problemType + " does not contain a public static Name field");
			if(nameField.FieldType != typeof(string)) throw new Exception("Name field must be of type string (was " + nameField.FieldType + ")");
			return (string)nameField.GetValue(null);
		}

		private static int ReadInt(string query) {
			Console.Write(query);
			while(true) {
				string line = Console.ReadLine().Trim();
				if(int.TryParse(line, out int num)) return num;
			}
		}
	}
}
