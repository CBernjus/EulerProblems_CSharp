using System;

namespace EulerProblems.Meta {
	[AttributeUsage(AttributeTargets.Class)]
	class ProblemSolutionAttribute : Attribute {
		public readonly object Solution;

		public ProblemSolutionAttribute(object solution) {
			Solution = solution;
		}
	}
}
