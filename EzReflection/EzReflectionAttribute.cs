using System.Reflection;

namespace EzReflection;

[AttributeUsage(AttributeTargets.Method)]
public class EzReflectionAttribute : Attribute
{
    public string CallingName { get; }

    public EzReflectionAttribute(string callingName = null)
    {
        if (string.IsNullOrEmpty(callingName))
            callingName = Assembly.GetCallingAssembly()
                .GetTypes()
                .SelectMany(t => t.GetMethods())
                .Where(m => m.GetCustomAttributes(typeof(EzReflectionAttribute), false).Length > 0)
                .ToArray()
                .First()
                .Name;

        CallingName = callingName;
    }
}