using System.Reflection;

namespace EzReflection;

public class EzTypes
{
    public EzTypes(Assembly assembly = null, string pathToAssembly = null)
        => _assembly = assembly ?? Assembly.Load(File.ReadAllBytes(pathToAssembly));
    private Assembly _assembly { get; }

    /// <summary>
    /// Get any class that is represented with the passed name
    /// </summary>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public Type GetTypeWithName(string typeName)
        => _assembly.GetTypes().First(t => t.Name == typeName);

    public Type GetTypeWithAttributeName(string typeName)
        => _assembly.GetTypes().First(t => t.GetCustomAttribute<EzReflectionAttribute>()?.CallingName == typeName);

    /// <summary>
    /// Get any class that has the generic attribute
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public Type GetTypeWithGenericAttribute<T>()
        => _assembly.GetTypes().First(t => t.GetCustomAttributes(typeof(T), false).Length > 0);

    public object? this[string typeName] => _assembly.GetTypes().First(t => t.Name == typeName);
}