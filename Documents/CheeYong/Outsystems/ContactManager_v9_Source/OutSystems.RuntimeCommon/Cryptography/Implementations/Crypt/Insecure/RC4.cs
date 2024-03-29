/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.IO;
using System.Text;

namespace OutSystems.RuntimeCommon.Cryptography.Implementations.Crypt.Insecure
{
    /// <summary>
    /// NOTE: This algorithm is NOT FIPS compliant...
    /// </summary>
    [Obsolete("NOT FIPS compliant")]
    public class RC4 {

        #region Getters and Modifiers

        private static string key = string.Empty;

        private static int[] box = new int[256];

        /// <summary>
        /// Warning: key string must be Encodings.Encoding (hopefully UTF-8).
        /// </summary>
        public static string Key {
            set {
                int a;
                int b;
                byte[] keyBuffer;
                int keyLength;
                int temp;
                // Checks key
                if (key == value) {
                    return;
                }
                // Sets key
                key = value;
                keyBuffer = Encoding.UTF8.GetBytes(key);
                keyLength = keyBuffer.Length;
                // Clears box
                for (a = 0; a < 256; a++) {
                    box[a] = a;
                }
                // Sets box
                b = 0;
                for (a = 0; a < 256; a++) {
                    b = (b + box[a] + keyBuffer[a % keyLength]) % 256;
                    temp = box[a];
                    box[a] = box[b];
                    box[b] = temp;
                }
            }
            get {
                return key;
            }
        }

        #endregion Getters and Modifiers

        #region Logic

        #endregion Logic


        /// <summary>
        /// Writes to a file the encrypted version of string.
        /// Parameter key is optional if property Key is set null may be passed.
        /// </summary>
        internal static void EncryptStringToFile(string text, string outFile, string key) {
            // Converts
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            // Encrypts
            EncryptByte(bytes, key);
            // Saves
            using (var stream = new FileStream(outFile, FileMode.Create, FileAccess.Write)) {
                stream.Write(bytes, 0, bytes.Length);
            }
        }

        /// <summary>
        /// Returns the decrypted string version of a file.
        /// Parameter key is optional if property Key is set null may be passed.
        /// </summary>
        internal static string DecryptFileToString(string inFile, string key, out long streamLength) {
            // Reads data
            if (!File.Exists(inFile)) {
                throw new FileNotFoundException("File '" + inFile + "' does not exists!");
            }

            byte[] bytes;

            using (var stream = new FileStream(inFile, FileMode.Open, FileAccess.Read)) {
                streamLength = stream.Length;
                bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
            }

            // Decrypts
            DecryptByte(bytes, key);
            // Converts
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Parameter key is optional if property Key is set null may be passed.
        /// </summary>
        internal static string EncryptString(string text, string key) {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            EncryptByte(bytes, key);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Parameter key is optional if property Key is set null may be passed.
        /// </summary>
        internal static string DecryptString(string text, string key) {
            byte[] bytes = Convert.FromBase64String(text);                
            DecryptByte(bytes, key);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Parameter key is optional if property Key is set null may be passed.
        /// </summary>
        internal static void EncryptByte(byte[] bytes, string key) {
            int i;
            int j;
            int offset;
            int[] localBox;
            int temp;
            // Checks key
            if (key != null && key.Length > 0) {
                Key = key;
            }
            // Creates local box
            localBox = (int[])box.Clone();
            i = 0;
            j = 0;
            for (offset = 0; offset < bytes.Length; offset++) {
                i = (i + 1) % 256;
                j = (j + localBox[i]) % 256;
                temp = localBox[i];
                localBox[i] = localBox[j];
                localBox[j] = temp;
                bytes[offset] = (byte)(bytes[offset] ^ localBox[(localBox[i] + localBox[j]) % 256]);
            }
        }

        /// <summary>
        /// Parameter key is optional if property Key is set null may be passed.
        /// </summary>
        internal static void DecryptByte(byte[] bytes, string key) {
            EncryptByte(bytes, key);
        }

    }
}