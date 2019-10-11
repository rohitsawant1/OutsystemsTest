/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OutSystems.RuntimeCommon.Cryptography.Insecure {
    /// <summary>
    /// NOTE: This algorithm is NOT FIPS compliant...
    /// </summary>    
    public static class MD5GuidHelper {
        public static System.Guid ToGuid(byte[] bytes) {

            #pragma warning disable 618

            return CryptManager.Instance.Insecure.ToGuid(bytes);

            #pragma warning restore 618

        }

        public static System.Guid ToGuid(string text) {

            #pragma warning disable 618
            
            return CryptManager.Instance.Insecure.ToGuid(text);

            #pragma warning restore 618

        }

        public static System.Guid ToGuidUsingDefaultEncoding(byte[] data) {

            #pragma warning disable 618
            
            return CryptManager.Instance.Insecure.ToGuid(data);

            #pragma warning restore 618

        }

        public static System.Guid ToGuidUsingDefaultEncoding(string text) {

            #pragma warning disable 618
            
            return CryptManager.Instance.Insecure.ToGuidUsingDefaultEncoding(text);

            #pragma warning restore 618

        }

        public static System.Guid ToGuidUsingDefaultEncoding<T>(IEnumerable<T> list) {            
            return ToGuidUsingDefaultEncoding(GuidHelper.IEnumerableToText(list));
        }

        public static string GenerateToBase64(string text) {

            #pragma warning disable 618
            
            return CryptManager.Instance.Insecure.ToGuidToBase64(text);

            #pragma warning restore 618

        }

        public static string GenerateToBase64UsingDefaultEncoding(string text) {

            #pragma warning disable 618
            
            return CryptManager.Instance.Insecure.GenerateToBase64UsingDefaultEncoding(text);

            #pragma warning restore 618

        }

        public static System.Guid ToGuidWithSaltAndUTF16(string text, string salt) {

            #pragma warning disable 618
            
            return CryptManager.Instance.Insecure.ToGuidWithSaltAndUTF16(text, salt);

            #pragma warning restore 618

        }
    }
}