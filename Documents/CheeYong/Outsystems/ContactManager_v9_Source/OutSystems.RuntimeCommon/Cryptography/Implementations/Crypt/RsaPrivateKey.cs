/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Xml;

namespace OutSystems.RuntimeCommon.Cryptography.Implementations.Crypt
{
    /// <summary>
    /// NOTE: This algorithm is FIPS compliant...
    /// </summary>
    public class RsaPrivateKey : RsaKey {
        private BigInteger e;
        private BigInteger p;
        private BigInteger q;
        private BigInteger dP;
        private BigInteger dQ;
        private BigInteger qInv;

        public RsaPrivateKey(string xmlRepresentation)
            : base(xmlRepresentation) {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlRepresentation);
            this.e = GetNodeValue(doc, "PublicExponent");
            this.p = GetNodeValue(doc, "P");
            this.q = GetNodeValue(doc, "Q");
            this.dQ = GetNodeValue(doc, "DQ");
            this.dP = GetNodeValue(doc, "DP");
            this.qInv = GetNodeValue(doc, "QINV");
            }

        public RsaPrivateKey(
            BigInteger modulus,
            BigInteger publicExponent,
            BigInteger privateExponent,
            BigInteger p,
            BigInteger q,
            BigInteger dP,
            BigInteger dQ,
            BigInteger qInv)
            : base(true, modulus, privateExponent) {
            this.e = publicExponent;
            this.p = p;
            this.q = q;
            this.dP = dP;
            this.dQ = dQ;
            this.qInv = qInv;
            }

        public BigInteger PublicExponent {
            get {
                return e;
            }
        }

        public BigInteger P {
            get {
                return p;
            }
        }

        public BigInteger Q {
            get {
                return q;
            }
        }

        public BigInteger DP {
            get {
                return dP;
            }
        }

        public BigInteger DQ {
            get {
                return dQ;
            }
        }

        public BigInteger QInv {
            get {
                return qInv;
            }
        }

        public override bool Equals(object obj) {
            RsaPrivateKey kp = obj as RsaPrivateKey;
            if (kp != null) {
                return (kp.DP.Equals(dP) &&
                        kp.DQ.Equals(dQ) &&
                        kp.Exponent.Equals(this.Exponent) &&
                        kp.Modulus.Equals(this.Modulus) &&
                        kp.P.Equals(p) &&
                        kp.Q.Equals(q) &&
                        kp.PublicExponent.Equals(e) &&
                        kp.QInv.Equals(qInv));
            }
            return false;
        }

        public override int GetHashCode() {
            return (this.DP.GetHashCode() ^
                    this.DQ.GetHashCode() ^
                    this.Exponent.GetHashCode() ^
                    this.Modulus.GetHashCode() ^
                    this.P.GetHashCode() ^
                    this.Q.GetHashCode() ^
                    this.PublicExponent.GetHashCode() ^
                    this.QInv.GetHashCode());
        }

        public new XmlDocument ToXmlDocument() {
            XmlDocument xmldoc = base.ToXmlDocument();
            XmlNode root = xmldoc.FirstChild;
            AddXmlElement(xmldoc, root, "PublicExponent", this.PublicExponent.ToString(RADIX));
            AddXmlElement(xmldoc, root, "P", this.P.ToString(RADIX));
            AddXmlElement(xmldoc, root, "Q", this.Q.ToString(RADIX));
            AddXmlElement(xmldoc, root, "DQ", this.DQ.ToString(RADIX));
            AddXmlElement(xmldoc, root, "DP", this.DP.ToString(RADIX));
            AddXmlElement(xmldoc, root, "QINV", this.QInv.ToString(RADIX));
            return xmldoc;
        }

        public new string ToXmlString() {
            XmlDocument xmldoc = ToXmlDocument();
            return xmldoc.OuterXml;
        }
    }
}