﻿/*
Project Orleans Cloud Service SDK ver. 1.0
 
Copyright (c) Microsoft Corporation
 
All rights reserved.
 
MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
associated documentation files (the ""Software""), to deal in the Software without restriction,
including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO
THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS
OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;


namespace Orleans.Runtime.Storage.Relational
{
    /// <summary>
    /// Extensions methods to work with dictionaries.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Gets the value or a default for the given type if not found.
        /// </summary>
        /// <typeparam name="TKey">The type of a key with which to search for.</typeparam>
        /// <typeparam name="TValue">The type of a value which to return.</typeparam>
        /// <param name="dictionary">The dictionary from which to search from.</param>
        /// <param name="key">The key with which to search.</param>
        /// <returns>The found object or <em>default(TValue)</em>.</returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            dictionary.TryGetValue(key, out value);
            return value;
        }


        /// <summary>
        /// Gets the value or a default for the given type if not found.
        /// </summary>
        /// <typeparam name="TKey">The type of a key with which to search for.</typeparam>
        /// <typeparam name="TValue">The type of a value which to return.</typeparam>
        /// <param name="dictionary">The dictionary from which to search from.</param>
        /// <param name="key">The key with which to search.</param>
        /// <param name="defaultProvider">A provider for a default value if the value was not found.</param>
        /// <returns>The found object or value as defined by <see paramref="defaultProvider"/>.</returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> defaultProvider)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultProvider();
        }
    }
}
