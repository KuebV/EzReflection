using System.Reflection;
using EzReflection;
using EzReflection.Tests;


#region Invoking Methods that are static and non-static

EzTypes ezTypeA = new EzTypes(Assembly.GetExecutingAssembly());
Type typeA = ezTypeA.GetTypeWithAttributeName("ClassA");
EzMethods ezMethod = new EzMethods(typeA);

// Non-Static Print Method
ezMethod.InvokeInstancedMethodWithAttributeCallingName("TestOne.NonStatic", Activator.CreateInstance(typeA), new object[] {"John"});

// Static-Print Method
ezMethod.InvokeStaticMethodWithAttributeCallingName("TestOne.Static", new object[] { "Jill"});

#endregion

#region Getting Properties from Class

EzTypes ezTypeB = new EzTypes(Assembly.GetExecutingAssembly());
Type typeB = ezTypeB.GetTypeWithAttributeName("ClassB");

EzProperties ezProperties = new EzProperties(typeB);

// Get Property Value from Static Property
Console.WriteLine($"Property from {typeB.Name}: {ezProperties.GetStaticValue("FirstName")}");

// You are able to use [] to index for a specific property, this only works for static properties
Console.WriteLine($"Property from {typeB.Name}: {ezProperties["LastName"]}");

#endregion