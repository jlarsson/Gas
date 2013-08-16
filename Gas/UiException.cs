using System;

namespace Gas
{
    public class GasException : ApplicationException
    {
        public GasException(string message) : base(message)
        {
        }
    }
}