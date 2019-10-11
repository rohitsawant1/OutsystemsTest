/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.Extensibility.Data.DMLService;
using System.Collections.Generic;

namespace OutSystems.HubEdition.DatabaseProvider.iDB2.DMLService {
    public class iDB2DMLSyntaxHighlightDefinitions : GenericDMLSyntaxHighlightDefinitions {

        public iDB2DMLSyntaxHighlightDefinitions(iDB2DMLService dmlService) : base(dmlService) { }
        
        /// <summary>
        /// Based on IBM DB2 for i SQL Reference 7.1
        /// Repeated words were removed (that are also in Function or Operators)
        /// </summary>
        public override IEnumerable<string> Keywords {
            get {
                return new[] {
                    "ACCORDING", "ACCTNG", "ACTION", "ACTIVATE", "ADD", "ALIAS", "ALLOCATE", "ALTER", "APPEND", "APPLNAME", "AT", 
                    "ATOMIC", "ATTRIBUTES", "AUTHORIZATION", "BEFORE", "BEGIN", "BIND", "BIT", "BUFFERPOOL", "BY", "CACHE", "CALL", 
                    "CALLED", "CASE", "CAST", "CCSID", "CHECK", "CL", "CLOSE", "CLUSTER", "COLLECT", "COLLECTION", "COLUMN", "COMMENT", 
                    "COMMIT", "COMPACT", "COMPRESS", "CONCURRENT", "CONDITION", "CONNECT", "CONNECT_BY_ROOT", "CONNECTION", "CONSTRAINT", 
                    "CONTENT", "CONTINUE", "COPY", "CREATE", "CROSS", "CUBE", "CURRENT", "CURRENT_DATE", "CURRENT_PATH", "CURRENT_SCHEMA",
                    "CURRENT_SERVER", "CURRENT_TIME", "CURRENT_TIMESTAMP", "CURRENT_TIMEZONE", "CURRENT_USER", "CURSOR", "CYCLE", "DATA",
                    "DBINFO", "DB2GENERAL", "DB2GENRL", "DB2SQL", "DEACTIVATE", "DEALLOCATE", "DECLARE", "DEFAULT", "DEFAULTS", "DEFER", 
                    "DEFINE", "DEFINITION", "DELETE", "DELETING", "DENSERANK", "DENSE_RANK", "DESC", "DESCRIBE", "DESCRIPTOR", 
                    "DETERMINISTIC", "DIAGNOSTICS", "DISABLE", "DISALLOW", "DISCONNECT", "DO", "DOCUMENT", "DROP", "DYNAMIC", "EACH",
                    "ELSE", "ELSEIF", "ENABLE", "ENCRYPTION", "END", "ENDING", "END-EXEC", "ENFORCED", "ESCAPE", "EVERY", "EXCEPTION", 
                    "EXCLUDING", "EXCLUSIVE", "EXECUTE", "EXIT", "EXTEND", "EXTERNAL", "FENCED", "FETCH", "FIELDPROC", "FILE", "FINAL", 
                    "FOR", "FOREIGN", "FREE", "FREEPAGE", "FROM", "FULL", "FUNCTION", "GBPCACHE", "GENERAL", "GENERATED", "GET", "GLOBAL", 
                    "GO", "GOTO", "GRANT", "GROUP", "HANDLER", "HAVING", "HINT", "HOLD", "HOURS", "ID", "IDENTITY", "IF", "IGNORE",
                    "IMMEDIATE", "IMPLICITLY", "INCLUDE", "INCLUDING", "INCLUSIVE", "INCREMENT", "INDEX",
                    "INDEXBP", "INDICATOR", "INF", "INFINITY", "INHERIT", "INNER", "INOUT", "INSENSITIVE", "INSERT", "INTEGRITY",
                    "INTO", "IS", "ISOLATION", "ITERATE", "JAVA", "JOIN", "KEY", "LABEL", "LANGUAGE", "LATERAL", "LEAVE",
                    "LEVEL2", "LINKTYPE", "LOCAL", "LOCALDATE", "LOCALTIME", "LOCALTIMESTAMP", "LOCATION", "LOCATOR", "LOCK",
                    "LOCKSIZE", "LOGGED", "LONG", "LOOP", "MAINTAINED", "MATCHED", "MATERIALIZED", "MAXVALUE", "MERGE",
                    "MICROSECONDS", "MINPCTUSED", "MINUTES", "MINVALUE", "MIXED", "MODE", "MODIFIES", "MONTHS",
                    "NAMESPACE", "NAN", "NATIONAL", "NEW", "NEW_TABLE", "NEXTVAL", "NO", "NOCACHE", "NOCYCLE", "NODENAME",
                    "NODENUMBER", "NOMAXVALUE", "NOMINVALUE", "NONE", "NOORDER", "NORMALIZED", "NULL", "NULLS", "OBID",
                    "OF", "OLD", "OLD_TABLE", "ON", "OPEN", "OPTIMIZE", "OPTION", "ORDER", "ORDINALITY", "ORGANIZE", "OUT", "OUTER",
                    "OVER", "OVERRIDING", "PACKAGE", "PADDED", "PAGE", "PAGESIZE", "PARAMETER", "PART", "PARTITION", "PARTITIONED",
                    "PARTITIONING", "PARTITIONS", "PASSING", "PASSWORD", "PATH", "PCTFREE", "PIECESIZE", "PLAN", "PREPARE",
                    "PREVVAL", "PRIMARY", "PRIOR", "PRIQTY", "PRIVILEGES", "PROCEDURE", "PROGRAM", "PROGRAMID", "QUERY", "RANGE", "RANK",
                    "RCDFMT", "READ", "READS", "RECOVERY", "REFERENCES", "REFERENCING", "REFRESH", "RELEASE", "RENAME", "REPEAT", "RESET",
                    "RESIGNAL", "RESTART", "RESULT", "RESULT_SET_LOCATOR", "RETURN", "RETURNS", "REVOKE", "ROLLBACK",
                    "ROLLUP", "ROUTINE", "ROW", "ROWNUMBER", "ROW_NUMBER", "ROWS", "RUN", "SAVEPOINT", "SBCS", "SCHEMA", "SCRATCHPAD",
                    "SCROLL", "SEARCH", "SECONDS", "SECQTY", "SELECT", "SENSITIVE", "SEQUENCE", "SESSION", "SESSION_USER", "SET",
                    "SIGNAL", "SIMPLE", "SKIP", "SNAN", "SOURCE", "SPECIFIC", "SQL", "SQLID", "STACKED", "START", "STARTING",
                    "STATEMENT", "STATIC", "STOGROUP", "SUBSTRING", "SUMMARY", "SYNONYM", "SYSTEM_USER", "TABLE", "TABLESPACE",
                    "TABLESPACES", "THEN", "THREADSAFE", "TO", "TRANSACTION", "TRIGGER", "TYPE",
                    "UNDO", "UNIQUE", "UNIT", "UNNEST", "UNTIL", "UPDATE", "UPDATING", "URI", "USAGE", "USE", "USER", "USERID", "USING",
                    "VALUES", "VARIABLE", "VARIANT", "VCAT", "VERSION", "VIEW", "VOLATILE", "WAIT", "WHEN", "WHENEVER", "WHERE",
                    "WHILE", "WITH", "WITHOUT", "WRAPPED", "WRITE", "WRKSTNNAME", "XMLCAST",
                    "XSROBJECT", "YEARS", "YES"
                };
            }
        }

        /// <summary>
        /// Based on http://msdn.microsoft.com/en-us/library/ms174318(v=sql.110).aspx
        /// </summary>
        public override IEnumerable<string> Functions {
            get {
                return new[] {
                    // Aggregate
                    "ARRAY_AGG", "AVG", "COUNT", "COUNT_BIG", "GROUPING", "MAX", "MIN", "STDDEV_POP", "STDDEV", "STDDEV_SAMP", "SUM", "VAR_POP",
                    "VARIANCE", "VAR", "VARIANCE_SAMP", "VAR_SAMP", "XMLAGG", "XMLGROUP", 
                    // Scalar
                    "ABS", "ACOS", "ADD_MONTHS", "ANTILOG", "ASCII", "ASIN", "ATAN", "ATANH", "ATAN2", "BIGINT", 
                    "BITAND", "BITANDNOT", "BITOR", "BITXOR", "BITNOT", "BIT_LENGTH", "BLOB", "CARDINALITY", "CEILING",
                    "CHARACTER_LENGTH", "CHR", "CLOB", "COALESCE", "COMPARE_DECFLOAT", "CONCAT", "CONTAINS", "COS", "COSH", "COT",
                    "CURDATE", "CURTIME", "DATABASE", "DATAPARTITIONNAME", "DATAPARTITIONNUM", "DAY", "DAYNAME", "DAYOFMONTH",
                    "DAYOFWEEK", "DAYOFWEEK_ISO", "DAYOFYEAR", "DAYS", "DBCLOB", "DBPARTITIONNAME", "DBPARTITIONNUM", "DECFLOAT", "DECFLOAT_SORTKEY",
                    "DECIMAL", "DEC", "DECRYPT_BIT", "DECRYPT_BINARY", "DECRYPT_CHAR", "DECRYPT_DB", "DEGREES", "DIFFERENCE", "DIGIT", "DLCOMMENT",
                    "DLLINKTYPE", "DLURLCOMPLETE", "DLURLPATH", "DLURLPATHONLY", "DLURLSCHEME", "DLURLSERVER", "DLVALUE", "DOUBLE_PRECISION", 
                    "ENCRYPT_AES", "ENCRYPT_RC", "ENCRYPT_TDES", "EXP", "EXTRACT", "FLOAT", "FLOOR", "GENERATE_UNIQUE", "GET_BLOB_FROM_FILE", 
                    "GET_CLOB_FROM_FILE", "GET_DBCLOB_FROM_FILE", "GET_XML_FILE", "GETHINT", "HASH", "HASHED_VALUE", "HEX", "HOUR", 
                    "IDENTITY_VAL_LOCAL", "IFNULL", "INSERT", "INSERTING", "INTEGER", "INT", "JULIAN_DAY", "LAND", "LAST_DAY", "LCASE", "LEFT", "LENGTH", "LN",
                    "LNOT", "LOCATE", "LOG", "LOR", "LOWER", "LTRIM", "MAX", "MAX_CARDINALITY", "MICROSECOND", "MIDNIGHT_SECONDS", "MIN", "MINUTE",
                    "MOD", "MONTH", "MONTHNAME", "MONTHS_BETWEEN", "MQREAD", "MQREADCLOB", "MQRECEIVE", "MQRECEIVECLOB", "MQSEND", "MULTIPLY_ALT",
                    "NEXT_DAY", "NORMALIZE_DECFLOAT", "NOW", "NULLIF", "OCTET_LENGTH", "PI", "POSITION", "POSSTR", "POWER", "QUANTIZE", "QUARTER",
                    "RADIANS", "RAISE_ERROR", "RAND", "REAL", "REPEAT", "REPLACE", "RID", "RIGHT", "ROUND", "ROUND_TIMESTAMP", "ROWID", "RRN", "RTRIM",
                    "SCORE", "SECOND", "SIGN", "SIN", "SINH", "SMALLINT", "SOUNDEX", "SPACE", "SQRT", "STRIP", "SUBSTR", "SUBSTRING", "TAN", "TANH",
                    "TIMESTAMP_FORMAT", "TIMESTAMP_ISO", "TIMESTAMPDIFF", "TOTALORDER", "TRANSLATE", "TRIM", "TRIM_ARRAY", 
                    "TRUNCATE or TRUNC", "TRUNC_TIMESTAMP", "UCASE", "UPPER", "VALUE", "VARBINARY", "VARCHAR", "VARCHAR_FORMAT", "VARGRAPHIC",
                    "WEEK", "WEEK_ISO", "WRAP", "XMLATTRIBUTES", "XMLCOMMENT", "XMLCONCAT", "XMLDOCUMENT", "XMLELEMENT", "XMLFOREST", "XMLNAMESPACES",
                    "XMLPARSE", "XMLPI", "XMLROW", "XMLSERIALIZE", "XMLTEXT", "XMLVALIDATE", "XOR", "XSLTRANSFORM", "YEAR", "ZONED",
                    // Table
                    "BASE_TABLE", "MQREADALL", "MQREADALLCLOB", "MQRECEIVEALL", "MQRECEIVEALLCLOB", "XMLTABLE"
                    
                };
            }
        }

        /// <summary>
        /// Based on http://msdn.microsoft.com/en-us/library/ms174986(v=sql.110).aspx
        /// </summary>
        public override IEnumerable<string> Operators {
            get { return new[] {
                "+", "-", "*", "/", "**",
                // Comparison
                "=", ">", "<", ">=", "<=", "<>", "!=", 
                // Logical
                "ALL", "AND", "ANY", "BETWEEN", "EXISTS", "IN", "LIKE", "NOT", "OR", "SOME",
                // Set
                "EXCEPT", "INTERSECT", "UNION", "DISTINCT",
                // String
                "^", "?", "%", "||"
            }; }
        }

        /// <summary>
        /// Based on IBM DB2 for i SQL Reference 7.1
        /// </summary>
        public override IEnumerable<string> DataTypes {
            get {
                return new[] {
                    "SMALLINT", "INTEGER", "INT", "BIGINT", "DECIMAL", "DEC", "NUMERIC", "NUM", "REAL", "FLOAT", "DOUBLE", "DECFLOAT",
                    "CHAR", "CHARACTER", "VARCHAR", "NCHAR", "NVARCHAR", "NCLOB", "GRAPHIC", "VARGRAPHIC", "CLOB", "DBCLOB", "BINARY",
                    "VARBINARY", "BLOB", "DATE", "TIME", "TIMESTAMP", "DATALINK", "ROWID", "XML", "ARRAY"
                };
            }
        }
    }
}
