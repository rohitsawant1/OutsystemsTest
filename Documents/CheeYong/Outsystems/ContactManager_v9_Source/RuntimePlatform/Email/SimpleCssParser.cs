/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using OutSystems.RuntimeCommon;
using System.Collections;

namespace OutSystems.HubEdition.RuntimePlatform.Email {
    public class SimpleCssParser {

        private static readonly Regex selectorRegex;

        static SimpleCssParser() {
            //Note for .net users: named captures are not supported in java
            string tagRegex = @"([a-z][_\-0-9a-z]*|\*)";
            string idRegex = @"(?:#([a-z][_\-0-9a-z]*))";
            string classesRegex = @"((?:\.[a-z][_\-0-9a-z]*)+)";
            string pseudoClassRegex = @"(?::(link|visited|hover|active|before|after|first-line|first-letter))";
            string conditionRegex = @"(?:\[([a-z]+)(?:=([^\]+]+))?\])";

            selectorRegex = new Regex("(?:(?:" + tagRegex + "?" + idRegex + ")|" +
                                           "(?:" + tagRegex + "?" + classesRegex + ")|" +
                                           "(?:" + tagRegex + "))" +
                                          pseudoClassRegex + "?" + conditionRegex + "?",
                                      RegexOptions.Compiled);

            //Guide Expression
            //@"(?:(?:(tag)?(?:#(id)))|(?:(tag)?(classes)|(?:(tag)))(?::(pseudoClass))?(?:\[(cond)(?:=(condVal)?\])?";
            //tag : group 1,3,5
            //id : group 2
            //classes: group 4
            //pseudoclass: group 6
            //cond = group 7
            //condVal = group8
        }

        private static IList<SimpleCssSelectorElement> ParseSelector(string selectorElements, HashSet<string> allCssClasses) {
            var elements = new List<SimpleCssSelectorElement>();

            foreach (var selectorElement in selectorElements.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)) {
                Match m = selectorRegex.Match(selectorElement.ToLower());
                
                if (m.Length != selectorElement.Length) {
                    return null;
                }

                string tagName = m.Groups[1].Value + m.Groups[3].Value + m.Groups[5].Value;

                string pseudoClass = m.Groups[6].Value;
                string conditionAttribute = m.Groups[7].Value;
                //TODO Support pseudo classes and conditions -> string conditionValue = m.Groups[8].Value;
                if (!pseudoClass.IsEmpty() || !conditionAttribute.IsEmpty())
                    return null; //TODO Support pseudo classes and conditions

                string cssClassesString = m.Groups[4].Value;
                string[] cssClasses = cssClassesString.IsEmpty() ? EmptyArray<string>.Instance : cssClassesString.Substring(1).Split('.');
                allCssClasses.AddRange(cssClasses);

                elements.Add(new SimpleCssSelectorElement(
                    tagName,
                    cssClasses,
                    m.Groups[2].Value));
            }

            return elements;
        }
        
        internal static IEnumerable<SimpleCssStyleDefinition> GetStyleDefinitions(string styleSheetString, out HashSet<string> allCssClasses) {
            var styleDefinitions = new List<SimpleCssStyleDefinition>();
            allCssClasses = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            DiscoverStyleDefinitions(styleDefinitions, allCssClasses, new StringBuilder(styleSheetString ?? string.Empty));
            return styleDefinitions;
        }

        private static void DiscoverStyleDefinitions(IList<SimpleCssStyleDefinition> styleDefinitions, HashSet<string> allCssClasses, StringBuilder stylesheetBuffer) {
            int nextCharacterIndex = 0;
            while (nextCharacterIndex < stylesheetBuffer.Length) {
                // Extract selector
                int selectorStart = nextCharacterIndex;
                while (nextCharacterIndex < stylesheetBuffer.Length && stylesheetBuffer[nextCharacterIndex] != '{') {
                    // Skip declaration directive starting from @
                    if (stylesheetBuffer[nextCharacterIndex] == '@') {
                        while (nextCharacterIndex < stylesheetBuffer.Length && stylesheetBuffer[nextCharacterIndex] != ';') {
                            nextCharacterIndex += 1;
                        }
                        selectorStart = nextCharacterIndex + 1;
                    }
                    nextCharacterIndex += 1;
                }

                if (nextCharacterIndex < stylesheetBuffer.Length) {
                    // Extract definition
                    int definitionStart = nextCharacterIndex;
                    while (nextCharacterIndex < stylesheetBuffer.Length && stylesheetBuffer[nextCharacterIndex] != '}') {
                        nextCharacterIndex += 1;
                    }

                    // Define a style
                    AddStyleDefinition(
                        styleDefinitions,
                        allCssClasses,
                        stylesheetBuffer.ToString(selectorStart, definitionStart - selectorStart),
                        stylesheetBuffer.ToString(definitionStart + 1, nextCharacterIndex - definitionStart - 1));

                    // Skip closing brace
                    if (nextCharacterIndex < stylesheetBuffer.Length) {
                        nextCharacterIndex += 1;
                    }
                }
            }
        }

        private static void AddStyleDefinition(IList<SimpleCssStyleDefinition> styleDefinitions, HashSet<string> allCssClasses, string selectorsString, string propertiesString) {

            selectorsString = selectorsString.Trim();
            propertiesString = propertiesString.Trim().ToLower();

            var cssProperties = GetRawCssPropertyDefinitions(propertiesString);
            if (cssProperties.IsEmpty()) {
                return;
            }

            string[] selectors = selectorsString.Split(',');

            for (int i = 0; i < selectors.Length; ++i) {
                string trimmedSelector = selectors[i].Trim();
                if (trimmedSelector.Length > 0) {
                    var cssSelectorElements = ParseSelector(trimmedSelector, allCssClasses);
                    if (cssSelectorElements != null && !cssSelectorElements.IsEmpty()) {
                        styleDefinitions.Add(new SimpleCssStyleDefinition(cssSelectorElements, cssProperties, styleDefinitions.Count));
                    }
                }
            }
        }

        public static IEnumerable<Pair<string, string>> GetRawCssPropertyDefinitions(string definitions) {

            foreach (var propertyDefinition in definitions.Split(';')) {
                string trimmedPropertyDefinition = propertyDefinition.Trim();
                if (trimmedPropertyDefinition.Length == 0) {
                    continue;
                }

                var parts = trimmedPropertyDefinition.Split(':');
                if (parts.Length != 2) {
                    continue;
                }

                string propertyName = parts[0].Trim().ToLower();
                string propertyValue = parts[1].Trim().ToLower();

                if (propertyName.Length == 0 || propertyValue.Length == 0) {
                    continue;
                }

                yield return Pair.Create(propertyName, propertyValue);
            }
        }

    }
}
