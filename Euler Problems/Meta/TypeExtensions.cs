using System;
using System.Linq;
using System.Reflection;

namespace EulerProblems.Meta {
	public static class TypeExtensions {
		public static T GetAttribute<T>(this Type type) where T : class {
			return type.GetCustomAttributes(typeof(T)).FirstOrDefault() as T
			       ?? throw new Exception($"Type {type} does not have an attribute of type {typeof(T)}");
		}
	}
}