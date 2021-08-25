using System;

namespace VogCodeChallenge.Shared.Exceptions
{
    public class InvalidArgumentException : ApplicationException
    {
        public InvalidArgumentException(string message) : base(message)
        {
        }
    }
}
