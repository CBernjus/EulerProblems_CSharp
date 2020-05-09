using System;

namespace EulerProblems.Meta {
	[AttributeUsage(AttributeTargets.Class)]
	class ProblemDifficultyAttribute : Attribute {
		public readonly int Difficulty;

		public ProblemDifficultyAttribute(int difficulty) {
			Difficulty = difficulty;
		}
	}
}
