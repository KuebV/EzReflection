using System;

namespace EzReflection.Framework
{
    public class EzReflectionConstructorArgumentException : Exception
    {
        public EzReflectionConstructorArgumentException() { }
        public EzReflectionConstructorArgumentException(string message) : 
            base(message) { }
    }
}