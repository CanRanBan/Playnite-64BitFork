﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Playnite.SDK.Models;

namespace Playnite.Database
{
    public class GameFieldComparer : IEqualityComparer<string>
    {
        private static readonly Regex regex = new Regex(@"[\s-]", RegexOptions.Compiled);
        public static readonly GameFieldComparer Instance = new GameFieldComparer();

        public bool Equals(string x, string y)
        {
            return StringEquals(x, y);
        }

        public static bool StringEquals(string x, string y)
        {
            if (x.IsNullOrEmpty() && y.IsNullOrEmpty())
            {
                return true;
            }

            if (!x.IsNullOrEmpty() && y.IsNullOrEmpty())
            {
                return false;
            }

            if (x.IsNullOrEmpty() && !y.IsNullOrEmpty())
            {
                return false;
            }

            return string.Equals(
                regex.Replace(x, ""),
                regex.Replace(y, ""),
                StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool FieldEquals<T>(T x, string y) where T : DatabaseObject
        {
            return StringEquals(x.Name, y);
        }

        public static bool FieldEquals<T>(T x, T y) where T : DatabaseObject
        {
            return StringEquals(x.Name, y.Name);
        }

        public int GetHashCode(string obj)
        {
            return regex.Replace(obj, "").ToLower().GetHashCode();
        }
    }
}
