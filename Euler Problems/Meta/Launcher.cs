using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EulerProblems.Meta {
	class Launcher {
		public static void Main(string[] args) {

			TestAll();
			return;

			if(args.Length == 0) {
				ListProblems();
				new Problem(ReadInt("Please enter the problem number: ")).Run();
				return;
			}

			if(args.Length == 1 && int.TryParse(args[0], out int problem)) {
				new Problem(problem).Run();
				return;
			}

			Console.WriteLine("Usage: EulerProblems.exe [problem no]");
		}

		public static void ListProblems() {
			Console.WriteLine("Available problems:");
			foreach(var problem in GetAllProblems()) {
				Console.WriteLine($"  Problem {problem.Number}: {problem.Name}");
			}
		}

		public static void RunAll() {
			foreach(var problem in GetAllProblems()) {
				problem.Run();
			}
		}

		public static void TestAll() {
			foreach(var problem in GetAllProblems()) {
				problem.Test();
			}
		}

		private static IEnumerable<Problem> GetAllProblems() {
			var regex = new Regex("^Problem\\d{3}$");
			return typeof(Problem001).Assembly.GetTypes()
				.Where(type => regex.IsMatch(type.Name))
				.Select(type => new Problem(type));
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
