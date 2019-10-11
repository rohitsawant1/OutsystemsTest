/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Security.Cryptography;

namespace OutSystems.RuntimeCommon.Cryptography.Implementations {
    internal abstract class DotNetHashGenerator: HashGenerator {
        protected abstract HashAlgorithm HashAlgorithm { get; }
        
        public override byte[] Hash(byte[] text) {
            using (var crypt = HashAlgorithm){
                return crypt.ComputeHash(text);
            }
        }

        public override int HashSizeInBytes {
            get { 
                using (var crypt = HashAlgorithm) {
                    return crypt.HashSize / 8;
                }  
            }
        }
    }
}
