namespace EzReflection;

public class EzReflectionPropertyTypeException : Exception
{
    public EzReflectionPropertyTypeException() { }
    public EzReflectionPropertyTypeException(string message) : 
        base(message) { }
}