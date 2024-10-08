﻿namespace Playnite.SDK
{
    /// <summary>
    /// Represents errors related to type mismatch use.
    /// </summary>
    public class TypeMismatchException : LocalizedException
    {
        /// <summary>
        /// Creates new instance of <see cref="TypeMismatchException"/>.
        /// </summary>
        public TypeMismatchException() : base()
        {
        }

        /// <summary>
        /// Creates new instance of <see cref="TypeMismatchException"/>.
        /// </summary>
        /// <param name="message">Error message.</param>
        public TypeMismatchException(string message) : base(message)
        {
        }
    }
}
