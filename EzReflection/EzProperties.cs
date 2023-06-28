using System.Reflection;

namespace EzReflection;

public class EzProperties
{
    public EzProperties(Type type)
        => Type = type ?? throw new NullReferenceException();

    private Type? Type;
    
    /// <summary>
    /// Get all properties within the given class
    /// </summary>
    /// <returns></returns>
    public PropertyInfo[]? GetProperties()
        => Type.GetProperties();

    /// <summary>
    /// Get the value of a property from an already initialized class
    /// </summary>
    /// <param name="instanceOf"></param>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    public object? GetValueFromInstance(object instanceOf, string propertyName)
        => Type?.GetProperty(propertyName)?.GetValue(instanceOf, null);

    /// <summary>
    /// Get the value of a property from a static class
    /// </summary>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    public object? GetStaticValue(string propertyName)
        => Type?.GetProperty(propertyName)?.GetValue(null, null);

    /// <summary>
    /// Get the value of a property from a non-initialized class
    /// </summary>
    /// <param name="propertyName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public object? GetValue<T>(string propertyName)
        => Type?.GetProperty(propertyName)?.GetValue(Activator.CreateInstance(typeof(T)), null);
    
    public object? this[string propertyName] => Type?.GetProperty(propertyName)?.GetValue(null, null);


}