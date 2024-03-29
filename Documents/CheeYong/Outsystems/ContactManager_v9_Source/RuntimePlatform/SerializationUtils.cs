/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.RuntimePlatform {
    public static class SerializationUtils {

        private const string XsdPrefix = "xsd:";

        private static void RenameNode(ref XmlElement node, string qualifiedName, string namespaceUri) {
            XmlElement newElement = node.OwnerDocument.CreateElement(qualifiedName, namespaceUri);
            while (node.HasAttributes) {
                newElement.SetAttributeNode(node.RemoveAttributeNode(node.Attributes[0]));
            }
            while (node.HasChildNodes) {
                newElement.AppendChild(node.FirstChild);
            }
            if (node.ParentNode != null) {
                node.ParentNode.ReplaceChild(newElement, node);
            }
            node = newElement;
        }

        public static XmlElement[] SerializeXmlStringAsObjectArray(string[] anyXml) {
            return SerializeXmlStringAsObjectArray(anyXml.StrCat(""));
        }

        public static XmlElement[] SerializeXmlStringAsObjectArray(string anyXml) {
            return SerializeXmlStringAsObjectArray(anyXml, "anyType");
        }

        private static XmlElement[] SerializeXmlStringAsObjectArray(string anyXml, string tag) {
            var nodes = SerializeXmlStringAsAnyType(anyXml);

            var i = 0;
            var result = new XmlElement[nodes.Length];

            // the xml will be hosted in an array then elements must be in the form of <anyType xsi:type="<TYPENAME>">...</anyType>
            foreach (var node in nodes) {
                string typeName;
                var simpleType = XmlSchemaType.GetBuiltInSimpleType(new XmlQualifiedName(node.Name, XmlSchema.Namespace));
                if (simpleType != null) {
                    // simple types have the prefix xsd
                    typeName = XsdPrefix + simpleType.QualifiedName.Name;
                } else {
                    typeName = node.LocalName;
                }

                // add attribute type
                var typeAttribute = node.OwnerDocument.CreateAttribute("xsi", "type", System.Xml.Schema.XmlSchema.InstanceNamespace);
                typeAttribute.Value = typeName;
                node.Attributes.Append(typeAttribute);

                // fill the default namespace if empty
                string namespaceUri = node.NamespaceURI;
                if (string.IsNullOrEmpty(namespaceUri)) {
                    namespaceUri = "http://tempuri.org/";
                }

                XmlElement renamedNode = node;
                RenameNode(ref renamedNode, tag, namespaceUri);
                result[i++] = renamedNode;
            }

            return result;
        }

        public static XmlElement SerializeXmlStringAsObject(string objectXml, string tag) {
            return SerializeXmlStringAsObjectArray(objectXml, tag).FirstOrDefault();
        }

        public static XmlElement[] SerializeXmlStringAsAnyType(string[] anyXml) {
            return SerializeXmlStringAsAnyType(anyXml.StrCat(""));
        }

        public static XmlElement[] SerializeXmlStringAsAnyType(string anyXml) {
            XmlDocumentFragment xmlFragment = new XmlDocument().CreateDocumentFragment();
            xmlFragment.InnerXml = anyXml;
            return xmlFragment.ChildNodes.OfType<XmlElement>().ToArray();
        }

        public static XmlAttribute[] SerializeXmlStringAsAnyTypeAttributes(string anyXml) {
            XmlDocumentFragment xmlFragment = new XmlDocument().CreateDocumentFragment();
            xmlFragment.InnerXml = "<type " + anyXml + "/>";
            return xmlFragment.FirstChild.Attributes.OfType<XmlAttribute>().ToArray();
        }

        public static string DeserializeObject(XmlNode node) {
            if (node == null) {
                return string.Empty;
            }

            return DeserializeObject(node.ToEnumerable().ToArray()).StrCat("");
        }

        public static string[] DeserializeObject(XmlNode[] nodes) {
            if (nodes == null) {
                return new string[0];
            }

            var i = 0;
            var result = new string[nodes.Length];

            foreach (var node in nodes.OfType<XmlElement>()) {
                var type = node.Attributes.RemoveNamedItem("type", System.Xml.Schema.XmlSchema.InstanceNamespace);
                if (type != null) {
                    if (type.Value.StartsWith(XsdPrefix)) {
                        type.Value = type.Value.Substring(XsdPrefix.Length);
                    }
                    XmlElement renamedNode = node;
                    RenameNode(ref renamedNode, type.Value, node.NamespaceURI);
                    result[i++] = renamedNode.OuterXml;
                } else {
                    result[i++] = node.InnerXml;
                }
            }

            return result;
        }

        public static XmlDocument ToXml(string xml) {
            var doc = new XmlDocument();
            if (!xml.IsEmpty()) {
                doc.LoadXml(xml);
            }
            return doc;
        }

        public static string[] GetOuterXml(XmlNode[] xmlNodes) {
            if (xmlNodes == null) {
                return new string[0];
            }
            return xmlNodes.Select(node => node.OuterXml).ToArray();
        }

        public static object ParseEnum(Type enumType, string name) {
            foreach (var field in enumType.GetFields(BindingFlags.Static | BindingFlags.GetField | BindingFlags.Public)) {
                var soapEnumAttribute = (SoapEnumAttribute)field.GetCustomAttributes(typeof(SoapEnumAttribute), true).FirstOrDefault();
                if (soapEnumAttribute != null && soapEnumAttribute.Name == name) {
                    return field.GetValue(null);
                }

                var xmlEnumAttribute = (XmlEnumAttribute)field.GetCustomAttributes(typeof(XmlEnumAttribute), true).FirstOrDefault();
                if (xmlEnumAttribute != null && xmlEnumAttribute.Name == name) {
                    return field.GetValue(null);
                }
            }

            return Enum.Parse(enumType, name);
        }

        public static string GetEnumValue(Object enumField) {
            var enumFiledDefinition = enumField.GetType().GetFields().SingleOrDefault(ef => ef.Name.Equals(enumField.ToString()));
            if (enumFiledDefinition != null) {
                var xmlEnumAttribute = (XmlEnumAttribute)enumFiledDefinition.GetCustomAttributes(typeof(XmlEnumAttribute), true).FirstOrDefault();
                if (xmlEnumAttribute != null && !xmlEnumAttribute.Name.IsNullOrEmpty()) {
                    return xmlEnumAttribute.Name;
                }
            }
            return enumField.ToString();
        }
    }
}