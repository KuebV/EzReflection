namespace EzReflection.Tests;

public class RefTests
{
    [RefTestsCustomAttribute]
    public static void ReverseName(string name) => Console.WriteLine(string.Join("", name.Reverse()));
}

[AttributeUsage(AttributeTargets.Method)]
public class RefTestsCustomAttribute : Attribute { }