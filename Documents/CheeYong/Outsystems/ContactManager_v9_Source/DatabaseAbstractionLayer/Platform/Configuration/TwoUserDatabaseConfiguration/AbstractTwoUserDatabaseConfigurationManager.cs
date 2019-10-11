/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.Extensibility.Data.Platform.Configuration {

    public abstract class AbstractTwoUserDatabaseConfigurationManager : BaseConfigurationManager, ITwoUserDatabaseConfigurationManager {

        protected ITwoUserDatabaseConfiguration uiConfiguration;

        public AbstractTwoUserDatabaseConfigurationManager(ITwoUserDatabaseConfiguration uiConfiguration) {
            this.uiConfiguration = uiConfiguration;
        }

        public abstract bool RecommendDatabaseBackup {
            get;
        }

        public virtual bool RequiresElevatedPrivilges() {
            return uiConfiguration.ImplementsElevatedPrivilegesOperations;
        }

        public virtual string GenerateSetupScript() {
            throw new NotImplementedException("Setup script generation not implemented for this database provider");
        }

        public abstract void Pre_CreateOrUpgradePlatform();

        public abstract IRuntimeDatabaseConfiguration GetRuntimeDatabaseConfigurationForAdminUser(Source source);

        public abstract IRuntimeDatabaseConfiguration GetRuntimeDatabaseConfigurationForRuntimeUser(Source source);

        public virtual bool TestAdminConnection(out string friendlyMessage, Source source) {
            bool sucess = TestConnection(GetRuntimeDatabaseConfigurationForAdminUser(source), out friendlyMessage);
            if (!sucess) {
                string newFriendlyMessage;
                string upperCaseUser = ((AbstractTwoUserDatabaseConfiguration)uiConfiguration).AdminUser;
                ((AbstractTwoUserDatabaseConfiguration)uiConfiguration).AdminUser = upperCaseUser.ToUpperInvariant();
                sucess = TestConnection(GetRuntimeDatabaseConfigurationForAdminUser(source), out newFriendlyMessage);
                if (!sucess) {
                    ((AbstractTwoUserDatabaseConfiguration)uiConfiguration).AdminUser = upperCaseUser;
                } else {
                    friendlyMessage = newFriendlyMessage;
                }
            }
            return sucess;
        }

        public virtual bool TestRuntimeConnection(out string friendlyMessage, Source source) {
            bool sucess = TestConnection(GetRuntimeDatabaseConfigurationForRuntimeUser(source), out friendlyMessage);
            if (!sucess) {
                string newFriendlyMessage;
                string upperCaseUser = ((AbstractTwoUserDatabaseConfiguration)uiConfiguration).RuntimeUser;
                ((AbstractTwoUserDatabaseConfiguration)uiConfiguration).RuntimeUser = upperCaseUser.ToUpperInvariant();
                sucess = TestConnection(GetRuntimeDatabaseConfigurationForRuntimeUser(source), out newFriendlyMessage);
                if (!sucess) {
                    ((AbstractTwoUserDatabaseConfiguration)uiConfiguration).RuntimeUser = upperCaseUser;
                } else {
                    friendlyMessage = newFriendlyMessage;
                }
            }
            return sucess;
        }

        public abstract FileStream StreamForScriptFile {
            get;
        }

        public abstract string ProcessStatement(string statement);

        public virtual Version GetUpgradeVersion() {
            string script = ReadScriptFile(StreamForScriptFile);
            string version = SliceModelScript(script, null).First(b => b.ConditionTag == Tag.SCRIPT_VERSION).Value;
            return new Version(version);
        }

        public IEnumerable<Block> GetDatabaseScriptStatements(Version currentModelVersion) {
            string script = ReadScriptFile(StreamForScriptFile);

            foreach (Block block in SliceModelScript(script, currentModelVersion)) {
                for (int i = 0; i < block.Statements.Count; i++) {
                    string statement = ProcessStatement(block.Statements[i]);
                    if (!statement.IsNullOrEmpty()) {
                        block.Statements[i] = statement;
                    }
                }
                yield return block;
            }

            foreach (var block in ExtraDatabaseStatements(currentModelVersion)) {
                yield return block;
            }
        }

        public virtual IEnumerable<Block> ExtraDatabaseStatements(Version currentModelVersion) {
            yield break;
        }

        private readonly static Regex LineTagRegex = new Regex("--[\\t ]*%(.+)%[\\t ]*(?:=[\\t ]*\\\"(.*)\\\")?", RegexOptions.Compiled);

        protected string LineExtractTag(string sourceLine, int sourceLineNum, out string tagName) {
            // match: '-- %TAG_NAME% = "Tag Content"'
            tagName = string.Empty;
            if (sourceLine.StartsWith("--")) {
                Match match = LineTagRegex.Match(sourceLine);
                if (match.Success) {
                    tagName = match.Groups[1].Value;
                    return match.Groups[2].Value;
                }
                // some developer error, writing the tag?
                // else, some errors could silently go unnoticed...
                if (sourceLine.TrimStart('\t', ' ').StartsWith("--%")) {
                    throw new Exception("Could not parse tag. Line no: " + sourceLineNum + " Line content: '" + sourceLine + "'");
                }
            }
            return string.Empty; // not a tag line
        }

        //Some tags are statements and not blocks
        protected virtual bool IsStatement(string tag, string tagValue) {
            if (tag == "") {
                return true;
            }
            Tag tagEnum = (Tag)Enum.Parse(typeof(Tag), tag);
            if (tagEnum == Tag.DROP_COLUMN || tagEnum == Tag.SPECIFIC_UPGRADE) {
                return true;
            }
            return false;
        }

        private bool LineHasTag(string sourceLine, out string tagName) {
            LineExtractTag(sourceLine, 0, out tagName);
            return tagName != "";
        }

        private string ReadStatement(StringReader reader, ref int sourceLineNum) {
            StringBuilder sb = null;
            string line;
            while ((line = reader.ReadLine()) != null) {
                if (sb == null) {
                    sb = new StringBuilder();
                }

                string tag;
                sourceLineNum++;

                if (LineHasTag(line, out tag)) {
                    sb.AppendLine(line);
                    break;
                }

                if ((line.Trim().ToUpper() == StatementSeparator)) {
                    break;
                }

                if (line.Trim() != "" && !line.Trim().StartsWith("--")) {
                    sb.AppendLine(line);
                }
            }

            return sb != null ? sb.ToString() : null;
        }

        protected virtual bool ValidateStatement(string sourceLine, string tagName) {
            return (sourceLine != "" && !sourceLine.StartsWith("--")) || tagName != "";
        }

        private IEnumerable<Block> SliceModelScript(string script, Version sliceVersion) {
            string sourceLine;
            int sourceLineNum;
            string tagName, tagValue;

            using (var reader = new StringReader(script)) {
                Block statement = new Block();
                sourceLineNum = 1;
                sourceLine = reader.ReadLine();
                tagValue = LineExtractTag(sourceLine, sourceLineNum, out tagName);


                if (tagName != Tag.SCRIPT_VERSION.ToString()) {
                    throw new Exception("Could not get current schema version from script file");
                }

                statement.SetTagValue(tagName, tagValue);

                yield return statement;

                while ((sourceLine = reader.ReadLine()) != null) {

                    sourceLineNum++;
                    tagValue = LineExtractTag(sourceLine, sourceLineNum, out tagName);

                    if (tagName == Tag.VERSION_UPGRADE.ToString() && new Version(tagValue) >= sliceVersion || tagName == Tag.TOUCH_VERSION.ToString()) {
                        statement = new Block();
                        statement.SetTagValue(tagName, tagValue);
                        break;
                    }
                }

                while ((sourceLine = ReadStatement(reader, ref sourceLineNum)) != null) {

                    tagValue = LineExtractTag(sourceLine, sourceLineNum, out tagName);

                    sourceLineNum++;

                    if (IsStatement(tagName, tagValue)) {
                        if (ValidateStatement(sourceLine, tagName)) {
                            statement.AddStatement(sourceLine);
                        }
                    } else {
                        yield return statement;
                        statement = new Block();
                        statement.SetTagValue(tagName, tagValue);
                    }
                }

                yield return statement;
            }
        }

        public virtual int QueryTimeout { get; set; }
    }
}