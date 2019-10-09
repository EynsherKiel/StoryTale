using System;

namespace StoryTale.Core.Exceptions
{
    public class AssertException : Exception
    {
        public AssertException(string message) : base(message)
        {
        }
    }
}