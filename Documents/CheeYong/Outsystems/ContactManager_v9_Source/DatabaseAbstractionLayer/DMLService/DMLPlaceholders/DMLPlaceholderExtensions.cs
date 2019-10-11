/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.RuntimeCommon;
using System.Collections.Generic;

namespace OutSystems.HubEdition.Extensibility.Data.DMLService.DMLPlaceholders {
    public static class DMLPlaceholderExtensions {
        /// <summary>
        /// Gets the placeholder value and removes all leading white spaces.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="placeholders">The placeholder.</param>
        /// <param name="key">The placeholder key in the dictionary.</param>
        /// <returns>
        /// The placeholder value.
        /// </returns>
        public static string GetPlaceholderValueTrimStart<TKey>(this IDictionary<TKey, string> placeholders, TKey key) {
            return GetPlaceholderValue(placeholders, key, /*trimStart*/true, /*trimEnd*/false);
        }

        /// <summary>
        /// Gets the placeholder value and removes all trailing white spaces.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="placeholders">The placeholder.</param>
        /// <param name="key">The placeholder key in the dictionary.</param>
        /// <returns>
        /// The placeholder value.
        /// </returns>
        public static string GetPlaceholderValueTrimEnd<TKey>(this IDictionary<TKey, string> placeholders, TKey key) {
            return GetPlaceholderValue(placeholders, key, /*trimStart*/false, /*trimEnd*/true);
        }

        /// <summary>
        /// Gets the placeholder value and removes all leading and trailing white spaces.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="placeholders">placeholders</param>
        /// <param name="key">The placeholder key in the dictionary.</param>
        /// <returns>
        /// The placeholder value.
        /// </returns>
        public static string GetPlaceholderValue<TKey>(this IDictionary<TKey, string> placeholders, TKey key) {
            return GetPlaceholderValue(placeholders, key, /*trimStart*/true, /*trimEnd*/true);
        }

        /// <summary>
        /// Gets the placeholder value and removes all leading and trailing white spaces depending on
        /// the values of <code>trimStart</code> and <code>trimEnd</code>.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="placeholders">placeholders</param>
        /// <param name="key">placeholder's key</param>
        /// <param name="trimStart">if set to <c>true</c> removes all leading white spaces from the placeholder value.</param>
        /// <param name="trimEnd">if set to <c>true</c> removes all trailing white spaces from the placeholder value</param>
        /// <returns>
        /// The placeholder value.
        /// </returns>
        public static string GetPlaceholderValue<TKey>(this IDictionary<TKey, string> placeholders, TKey key, bool trimStart, bool trimEnd) {
            string value = placeholders == null ? string.Empty : placeholders.GetValueOrEmpty(key).Trim();
            return (trimStart || value.IsEmpty() ? "" : " ") + value + (trimEnd || value.IsEmpty() ? "" : " ");
        }
    }
}
