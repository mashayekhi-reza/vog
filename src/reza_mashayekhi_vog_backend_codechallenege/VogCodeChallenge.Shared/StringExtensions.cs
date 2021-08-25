using VogCodeChallenge.Shared.Exceptions;

namespace VogCodeChallenge.Shared
{
    public static class StringExtensions
    {
        public static void EnsureIsNotEmpty(this string value, string display)
        {
            if (string.IsNullOrEmpty(value?.Trim()))
            {
                throw new InvalidArgumentException($"The {display} cannot be null or empty");
            }
        }
    }
}
