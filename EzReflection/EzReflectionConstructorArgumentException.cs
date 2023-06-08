using System;
using System.Runtime;

namespace EzReflection
{
    public class EzReflectionConstructorArgumentException : Exception
    {
        public EzReflectionConstructorArgumentException() { }
        public EzReflectionConstructorArgumentException(string message) : 
            base(message) { }
    }
}
