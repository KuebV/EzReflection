using System.Reflection;

namespace EzReflection;

public class Reflection
{
    /// <summary>
    /// Constructor for Reflection
    /// Must pass either Assembly, or a path to an Assembly File.
    /// If both are passed to the constructor, it will default to the Assembly that is passed
    /// </summary>
    /// <param name="assembly"></param>
    /// <param name="pathToAssembly"></param>
    /// <exception cref="EzReflectionConstructorArgumentException"></exception>
    public Reflection(Assembly? assembly = null, string? pathToAssembly = null)
    {
        if (assembly == null && string.IsNullOrEmpty(pathToAssembly))
            throw new EzReflectionConstructorArgumentException("assembly & pathToAssembly cannot be empty or null!");

        if (!File.Exists(pathToAssembly) && !string.IsNullOrEmpty(pathToAssembly))
            throw new EzReflectionConstructorArgumentException("Specified file does not exist!");

        if (assembly != null)
            _assembly = assembly;

        if (!string.IsNullOrEmpty(pathToAssembly) && File.Exists(pathToAssembly) && _assembly == null)
            _assembly = Assembly.Load(File.ReadAllBytes(pathToAssembly));
    }

    private Assembly? _assembly { get; }

    /// <summary>
    /// Invokes the Method that is specified regardless of the EzReflectionAttribute status
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="obj"></param>
    /// <param name="parameters"></param>
    public void InvokeMethodWithName(string methodName, object? obj = null, object[]? parameters = null)
    {
        MethodInfo methods = _assembly.GetTypes()
            .SelectMany(t => t.GetMethods())
            .Where(m => m.Name == methodName)
            .ToArray().First();
        methods.Invoke(obj, parameters);
    }

    /// <summary>
    /// Invokes the Method that has the specified EzReflectionAttribute Name
    /// </summary>
    /// <param name="specifiedName"></param>
    /// <param name="obj"></param>
    /// <param name="parameters"></param>
    public void InvokeMethodWithSpecifiedName(string specifiedName, object? obj = null, object[]? parameters = null)
    {
        MethodInfo methods = _assembly.GetTypes()
            .SelectMany(t => t.GetMethods())
            .Where(m => m.GetCustomAttributes(typeof(EzReflectionAttribute), false).Length > 0)
            .ToArray().First();
        methods.Invoke(obj, parameters);
    }

    /// <summary>
    /// Invokes the all methods that is specified regardless of the EzReflectionAttribute status
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="obj"></param>
    /// <param name="parameters"></param>
    public void InvokeMehtodsWithName(string methodName, object? obj = null, object[]? parameters = null)
    {
        MethodInfo[] methods = _assembly.GetTypes()
            .SelectMany(t => t.GetMethods())
            .Where(m => m.Name == methodName)
            .ToArray();

        for (int i = 0; i < methods.Length; i++)
            methods[i].Invoke(obj, parameters);
    }

    /// <summary>
    /// Invokes all methods that has the specified EzReflectionAttribute Name
    /// </summary>
    /// <param name="specifiedName"></param>
    /// <param name="parameters"></param>
    public void InvokeMethodsWithSpecifiedName(string specifiedName, object? obj = null, object[]? parameters = null)
    {
        MethodInfo[] methods = _assembly.GetTypes()
            .SelectMany(t => t.GetMethods())
            .Where(m => m.GetCustomAttributes(typeof(EzReflectionAttribute), false).Length > 0)
            .ToArray();
        for (int i = 0; i < methods.Length; i++)
            methods[i].Invoke(obj, parameters);
    }

    /// <summary>
    /// Gets all methods with the EzReflectionAttribute
    /// </summary>
    /// <returns></returns>
    public MethodInfo[] GetEzMethods()
        => _assembly.GetTypes()
            .SelectMany(t => t.GetMethods())
            .Where(m => m.GetCustomAttributes(typeof(EzReflectionAttribute), false).Length > 0)
            .ToArray();

    /// <summary>
    /// Invokes the first method that has the specified generic Attribute
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="parameters"></param>
    /// <typeparam name="T"></typeparam>
    public void InvokeMethodWithGenericAttribute<T>(object? obj = null, object[]? parameters = null)
    {
        MethodInfo methods = _assembly.GetTypes()
            .SelectMany(t => t.GetMethods())
            .Where(m => m.GetCustomAttributes(typeof(T), false).Length > 0)
            .ToArray().First();
        methods.Invoke(obj, parameters);
    }

    
    /// <summary>
    /// Invokes all methods that has the specified generic attribute
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="parameters"></param>
    /// <typeparam name="T"></typeparam>
    public void InvokeMethodsWithGenericAttribute<T>(object? obj = null, object[]? parameters = null)
    {
        MethodInfo[] methods = _assembly.GetTypes()
            .SelectMany(t => t.GetMethods())
            .Where(m => m.GetCustomAttributes(typeof(T), false).Length > 0)
            .ToArray();
        for (int i = 0; i < methods.Length; i++)
            methods[i].Invoke(obj, parameters);
    }
    
}