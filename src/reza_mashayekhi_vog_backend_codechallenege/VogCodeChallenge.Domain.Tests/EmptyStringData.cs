﻿using System.Collections;
using System.Collections.Generic;

namespace VogCodeChallenge.Domain.Tests
{
    public class EmptyStringData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                null
            };
            yield return new object[]
            {
                ""
            };
            yield return new object[]
            {
                "    "
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
