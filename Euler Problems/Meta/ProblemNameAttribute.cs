using System;

namespace EulerProblems.Meta {
	[AttributeUsage(AttributeTargets.Class)]
	public class ProblemNameAttribute : Attribute {
		public readonly string Name;

		public ProblemNameAttribute(string name) {
			Name = name;
		}
	}
}
