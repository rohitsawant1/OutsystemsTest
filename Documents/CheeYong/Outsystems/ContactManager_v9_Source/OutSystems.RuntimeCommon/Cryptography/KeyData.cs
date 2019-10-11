/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Collections.Generic;

namespace OutSystems.RuntimeCommon.Cryptography {

    public class KeyData {

        public byte[] KeyBytes { get; private set; }

        public byte[] IVBytes { get; private set; }

        public KeyData(byte[] keyBytes, byte[] ivBytes) {
            KeyBytes = keyBytes;
            IVBytes = ivBytes;
        }

    }

}
