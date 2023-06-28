using System.Reflection;

namespace EzReflection
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Property)]
    public class EzReflectionAttribute : Attribute
    {
        public readonly string? CallingName;

        public EzReflectionAttribute(object callingName = null)
        {
            if (string.IsNullOrEmpty(callingName.ToString()))
                callingName = Assembly.GetCallingAssembly()
                    .GetTypes()
                    .SelectMany(t => t.GetMethods())
                    .Where(m => m.GetCustomAttributes(typeof(EzReflectionAttribute), false).Length > 0)
                    .ToArray()
                    .First()
                    .Name;

            CallingName = callingName.ToString();
        }
    }
}
