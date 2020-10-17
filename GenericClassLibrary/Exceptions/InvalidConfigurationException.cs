using System;
using System.Collections.Generic;
using System.Text;

namespace GenericClassLibrary.Exceptions
{
    public class InvalidConfigurationException : Exception
    {
        public InvalidConfigurationException()
        {
        }

        public InvalidConfigurationException(string message) : base(message)
        {
        }
    }
}
