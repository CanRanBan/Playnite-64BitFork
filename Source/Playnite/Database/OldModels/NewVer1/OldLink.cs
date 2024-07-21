using System.Collections.Generic;

namespace Playnite.Database.OldModels.NewVer1
{
    /// <summary>
    /// Represents web link.
    /// </summary>
    public class OldLink : ObservableObject
    {
        private string name;
        /// <summary>
        /// Gets or sets name of the link.
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string url;
        /// <summary>
        /// Gets or sets web based URL.
        /// </summary>
        public string Url
        {
            get => url;
            set
            {
                url = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Creates new instance of Link.
        /// </summary>
        public OldLink()
        {
        }

        /// <summary>
        /// Creates new instance of Link with specific values.
        /// </summary>
        /// <param name="name">Link name.</param>
        /// <param name="url">Link URL.</param>
        public OldLink(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}
