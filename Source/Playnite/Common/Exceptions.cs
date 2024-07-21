using System;

namespace Playnite.Common
{
    public class NoDiskSpaceException : Exception
    {
        public long RequiredSpace { get; }

        public NoDiskSpaceException(long requiredSpace) : base()
        {
            RequiredSpace = requiredSpace;
        }

        public NoDiskSpaceException(string message) : base(message)
        {
        }

        public NoDiskSpaceException(string message, long requiredSpace) : base(message)
        {
            RequiredSpace = requiredSpace;
        }
    }
}
