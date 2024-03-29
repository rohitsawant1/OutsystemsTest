/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Security.Cryptography;
using OutSystems.RuntimeCommon.Cryptography.Interfaces;

namespace OutSystems.RuntimeCommon.Cryptography.Implementations.Crypt {
    internal abstract class CryptManaged {
        protected abstract SymmetricAlgorithm CreateSymmetricAlgorithm();
        
        public abstract int InitializationVectorSizeInBytes { get; }
        
        public ICryptTransform GetEncryptTransformer(CryptAlgorithmParameters parameters) {            
            var cryptAlg = CreateSymmetricAlgorithm();
            ICryptTransform transport = new CryptTransform(cryptAlg.CreateEncryptor(parameters.Key, parameters.InitializationVector));
            return transport;
        }

        public ICryptTransform GetDecryptTransformer(CryptAlgorithmParameters parameters) {            
            var cryptAlg = CreateSymmetricAlgorithm();
            ICryptTransform transport = new CryptTransform(cryptAlg.CreateDecryptor(parameters.Key, parameters.InitializationVector));
            return transport;
        }
    }
}