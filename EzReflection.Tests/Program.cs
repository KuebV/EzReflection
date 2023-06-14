using System.Reflection;
using EzReflection;
using EzReflection.Tests;

Assembly assembly = Assembly.Load(File.ReadAllBytes("filenamehere"));
Reflection reflection = new Reflection(assembly);

reflection.InvokeMethodWithSpecifiedName("Execute");
