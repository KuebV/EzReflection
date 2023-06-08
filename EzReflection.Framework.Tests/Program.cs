using System.IO;
using System.Reflection;

namespace EzReflection.Framework.Tests
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Assembly assembly = Assembly.Load(File.ReadAllBytes("E:\\CSharp\\MHKAnnihilation\\MHKAnnihilation\\bin\\Debug\\MHKAnnihilation.dll"));
            Reflection reflection = new Reflection(assembly);

            reflection.InvokeMethodWithSpecifiedName("Execute");
        }
    }
}