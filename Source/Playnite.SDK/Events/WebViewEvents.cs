namespace Playnite.SDK.Events
{
    /// <summary>
    /// Represents loading event occuring in web view browser instance.
    /// </summary>
    public class WebViewLoadingChangedEventArgs
    {
        /// <summary>
        /// Gets or sets value indicating whether the page is loading.
        /// </summary>
        public bool IsLoading { get; set; }
    }
}
