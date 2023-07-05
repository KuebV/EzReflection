namespace EzReflection.Tests;


[EzReflection("ClassA")]
public class ExampleClassA
{
    [EzReflection("TestOne.NonStatic")]
    public void PrintInstancedName(string name)
        => Console.WriteLine("Name: " + name);
    
    [EzReflection("TestOne.Static")]
    public static void PrintStaticName(string name)
        => Console.WriteLine("Name: " + name);

}

[EzReflection("ClassB")]
public class ExampleClassB
{
    public static string FirstName { get; set; } = "John";
    public static string LastName { get; set; } = "Doe";
}

[EzReflection("ClassC")]
public class ExampleClassC
{
    public string? FullName { get; set; }
    public void SetName(string name) => FullName = name;
    public string? DefaultName { get; set; } = "John Doe";
}
