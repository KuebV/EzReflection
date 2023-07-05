using System.Reflection;

namespace EzReflection;

public class EzMethods
{
   /// <summary>
   /// EzMethods Constructor
   /// </summary>
   /// <param name="type"></param>
   /// <exception cref="NullReferenceException"></exception>
    public EzMethods(Type type)
        => _type = type ?? throw new NullReferenceException();
   private Type? _type { get; }

   public void InvokeStaticMethodWithName(string methodName, object[]? parameters = null)
        =>  _type!.GetMethods()
            .First(m => m.Name == methodName)?
            .Invoke(null, parameters);
   
   public void InvokeInstancedMethodWithName(string methodName, object? obj = null, object[]? parameters = null)
        =>  _type!.GetMethods()
            .First(m => m.Name == methodName)?
            .Invoke(obj, parameters);

   public void InvokeStaticMethodWithAttributeCallingName(string callingName, object[]? parameters = null)
       =>  _type?.GetMethods()
           .Where(m => m.GetCustomAttributes(typeof(EzReflectionAttribute), false).Length > 0)
           .First(x => x.GetCustomAttribute<EzReflectionAttribute>()?.CallingName == callingName)
           .Invoke(null, parameters);

   public void InvokeInstancedMethodWithAttributeCallingName(string callingName, object? obj = null, object[]? parameters = null)
        =>  _type?.GetMethods()
            .Where(m => m.GetCustomAttributes(typeof(EzReflectionAttribute), false).Length > 0)
            .First(x => x.GetCustomAttribute<EzReflectionAttribute>()?.CallingName == callingName)
            .Invoke(obj, parameters);

   public void InvokeStaticMethodWithGenericAttribute<T>(object[]? parameters = null)
       => _type!.GetMethods()
           .First(m => m.GetCustomAttributes(typeof(T), false).Length > 0)?
           .Invoke(null, parameters);
   
   public void InvokeInstancedMethodWithGenericAttribute<T>(object? obj = null, object[]? parameters = null)
       => _type!.GetMethods()
           .First(m => m.GetCustomAttributes(typeof(T), false).Length > 0)?
           .Invoke(obj, parameters);


   public MethodInfo GetMethodWithName(string methodName) => 
       _type!.GetMethods()
       .First(m => m.Name == methodName);

   public MethodInfo GetMethodWithAttributeCallingName(string callingName)
       => _type!.GetMethods()
           .Where(m => m.GetCustomAttributes(typeof(EzReflectionAttribute), false).Length > 0)
           .First(x => x.GetCustomAttribute<EzReflectionAttribute>()?.CallingName == callingName);

   public MethodInfo GetMethodWithGenericAttribute<T>()
       => _type!.GetMethods()
           .First(m => m.GetCustomAttributes(typeof(T), false).Length > 0);


}