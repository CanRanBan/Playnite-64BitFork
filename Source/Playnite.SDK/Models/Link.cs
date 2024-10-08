﻿using System;
using System.Collections.Generic;

namespace Playnite.SDK.Models
{
    /// <summary>
    /// Represents web link.
    /// </summary>
    public class Link : ObservableObject, IEquatable<Link>
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
        public Link()
        {
        }

        /// <summary>
        /// Creates new instance of Link with specific values.
        /// </summary>
        /// <param name="name">Link name.</param>
        /// <param name="url">Link URL.</param>
        public Link(string name, string url)
        {
            Name = name;
            Url = url;
        }

        /// <inheritdoc/>
        public bool Equals(Link other)
        {
            if (other is null)
            {
                return false;
            }

            if (!string.Equals(Name, other.Name, StringComparison.Ordinal))
            {
                return false;
            }

            if (!string.Equals(Url, other.Url, StringComparison.Ordinal))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public Link GetCopy()
        {
            return new Link
            {
                Name = Name,
                Url = Url
            };
        }
    }
}
