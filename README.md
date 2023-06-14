# EzReflection
 .NET Reflection Library to more easily Invoke methods with specified generics, names, and atrributes
 
 # Examples:
 
 ## Method Invoking
Invoking methods is accomplished via the EzMethods Class. Below are examples of invoking methods with specified names, attributes, and generic attributes

**For all examples, the example class has been written to invoke the methods that are being shown**
```csharp
public class ExampleClass
{
    // EzReflection comes with a base Attribute Library to attach to any method. 
    // The calling name helps distinguish different attributes from each other
    [EzReflection("HelloNameAttribute")]
    public static void PrintHello(string personName)
        => Console.WriteLine($"Hello {personName}!");
}
```
-------
```csharp
// Invoking Method with Name
using EzReflection;

EzMethods ezMethods = new EzMethods(typeof(Program).Assembly);
ezMethods.InvokeMethodWithName("PrintHello", null, new object [] { "Bill"});
// Output: Hello Bill!
```

-------

```csharp
// Invoking Method with Name
using EzReflection;

EzMethods ezMethods = new EzMethods(typeof(Program).Assembly);
ezMethods.InvokeMethodWithSpecifiedName("HelloNameAttribute", null, new object[] {"Billy"});
// Output: Hello Billy!
```

---------

Additionally, EzReflection allows you to invoke methods with special attributes using: 

`EzMethods::InvokeMethodWithGenericAttribute<T>(object[]? obj, object[]? parameters)`

---------

### All EzMethod Features
```
EzMethods::InvokeMethodWithName(string methodName) // Invokes the first method with the passed methodName parameter
EzMethods::InvokeMethodsWithName(string methodName) // Invokes all methods with the passed methodName parameter
EzMethods::InvokeMethodWithSpecifiedName(string callingName) // Invokes the first method that has the EzReflection Attribute, and has the passed callingName parameter
EzMethods::InvokeMethodsWithSpecifiedName(string callingName) // Invokes all methods that has the EzReflection Attribute, and has the passed callingName parameter
```
