﻿using System.Collections.Generic;

namespace System
{
    public static class DictionaryExtensions
    {
        public static void AddOrUpdate<TKey, TVal>(this Dictionary<TKey, TVal> source, TKey key, TVal value)
        {
            if (source.ContainsKey(key))
            {
                source[key] = value;
            }
            else
            {
                source.Add(key, value);
            }
        }

        public static void AddMissing<TKey, TVal>(this Dictionary<TKey, TVal> source, TKey key, TVal value)
        {
            if (!source.ContainsKey(key))
            {
                source.Add(key, value);
            }
        }
    }
}
