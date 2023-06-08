using System.Reflection;
using EzReflection;
using EzReflection.Tests;

Assembly assembly = Assembly.Load(File.ReadAllBytes("E:\\CSharp\\MHKAnnihilation\\MHKAnnihilation\\bin\\Debug\\MHKAnnihilation.dll"));
Reflection reflection = new Reflection(assembly);

reflection.InvokeMethodWithSpecifiedName("Execute");