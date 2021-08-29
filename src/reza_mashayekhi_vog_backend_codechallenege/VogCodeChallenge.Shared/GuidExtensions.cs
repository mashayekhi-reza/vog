using System;
using VogCodeChallenge.Shared.Exceptions;

namespace VogCodeChallenge.Shared
{
    public static class GuidExtensions
    {
        public static void EnsureIsNotEmpty(this Guid value, string display)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidArgumentException($"The {display} cannot be null or empty");
            }
        }
    }
}
