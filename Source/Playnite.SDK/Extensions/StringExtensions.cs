using Playnite.SDK;

namespace System
{
    /// <summary>
    /// <see cref="string"/> extension methods.
    /// </summary>
    public static class StrExtensions
    {
        /// <summary>
        /// Returns localized version of string key.
        /// </summary>
        /// <param name="stringKey">Localization string key starting with LOC.</param>
        /// <returns></returns>
        public static string GetLocalized(this string stringKey)
        {
            return stringKey.StartsWith("LOC", StringComparison.Ordinal) ? ResourceProvider.GetString(stringKey) : stringKey;
        }
    }
}
