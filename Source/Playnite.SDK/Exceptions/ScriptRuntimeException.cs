﻿namespace Playnite.SDK.Exceptions
{
    /// <summary>
    /// Represents exception from scripting runtime.
    /// </summary>
    public class ScriptRuntimeException : LocalizedException
    {
        /// <summary>
        /// Gets script runtime stack trace.
        /// </summary>
        public string ScriptStackTrace { get; private set; }

        /// <summary>
        /// Creates new instance of <see cref="ScriptRuntimeException"/>.
        /// </summary>
        public ScriptRuntimeException() : base()
        {
        }

        /// <summary>
        /// Creates new instance of <see cref="ScriptRuntimeException"/>.
        /// </summary>
        /// <param name="message"></param>
        public ScriptRuntimeException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates new instance of <see cref="ScriptRuntimeException"/>.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="stackTrace"></param>
        public ScriptRuntimeException(string message, string stackTrace) : base(message)
        {
            ScriptStackTrace = stackTrace;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return base.ToString() + "\n--- script trace ---\n" + ScriptStackTrace;
        }
    }
}
