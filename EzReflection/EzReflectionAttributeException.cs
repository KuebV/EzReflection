using System.Runtime;

namespace EzReflection
{
    public class EzReflectionAttributeException : Exception
    {
        public EzReflectionAttributeException() { }
        public EzReflectionAttributeException(string message) : base(message) { }
    }
}
