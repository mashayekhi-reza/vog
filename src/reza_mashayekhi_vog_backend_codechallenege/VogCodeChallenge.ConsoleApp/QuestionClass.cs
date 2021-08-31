using System.Collections.Generic;
using VogCodeChallenge.Shared.Exceptions;

public static class QuestionClass
{
    public static List<string> NamesList = new List<string>()
    {
        "Jimmy",
        "Jeffrey",
        "John",
    };

    public static dynamic TESTModule(dynamic input)
    {
        return input switch
        {
            int n when (n > 0 && n < 5) => input * 2,
            int n when (n > 4) => input * 3,
            int n when (n < 1) => throw new InvalidArgumentException("The input cannot be less than 1"),
            float n when (n == 1.0f || n == 2.0f) => 3.0f,
            string n => n.ToUpper(),
            _ => input,
        };
    }
}
