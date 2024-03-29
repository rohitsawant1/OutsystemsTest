/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;

namespace OutSystems.RuntimeCommon {

    partial class CollectionsExtensions {

        private sealed class DynamicEqualityComparer<T, TResult> : IEqualityComparer<T> {

            private readonly Func<T, TResult> _selector;

            public DynamicEqualityComparer(Func<T, TResult> selector) {
                _selector = selector;
            }

            public bool Equals(T x, T y) {
                TResult result1 = _selector(x);
                TResult result2 = _selector(y);
                return result1.Equals(result2);
            }

            public int GetHashCode(T obj) {
                TResult result = _selector(obj);
                return result.GetHashCode();
            }
        }
    }
}