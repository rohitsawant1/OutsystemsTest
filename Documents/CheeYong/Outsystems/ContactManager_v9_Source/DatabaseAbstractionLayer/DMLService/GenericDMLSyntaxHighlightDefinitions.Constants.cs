namespace OutSystems.HubEdition.Extensibility.Data.DMLService {
    /// <summary>
    /// Defines a set of fragments (e.g. keywords, operators) of Generic (ANSI) SQL
    /// that can be used to provide syntax highlighting in SQL statements. This is based on the book
    /// "SQL in a nutshell - A Desktop Quick Reference", from Kevin Kline and Daniel Kline (2001)
    /// </summary>
    public partial class GenericDMLSyntaxHighlightDefinitions {
        public static readonly string[] KEYWORDS = {
            "ABSOLUTE", "ACTION", "ADD", "ADMIN", "AFTER", "AGGREGATE", "ALIAS", "ALLOCATE", "ALTER", "ARE", "ARRAY", "AS", "ASC", "ASSERTION", "AT", "AUTHORIZATION",
            "BEFORE", "BEGIN", "BINARY", "BOTH", "BREADTH", "BY",
            "CALL", "CASCADE", "CASCADED", "CASE", "CAST", "CATALOG", "CHECK", "CLASS", "CLOB", "CLOSE", "COLLATE", "COLLATION", "COLUMN", "COMMIT", "COMPLETION", "CONDITION", "CONNECT", "CONNECTION", "CONSTRAINT", "CONSTRAINTS", "CONSTRUCTOR", "CONTAINS", "CONTINUE", "CORRESPONDING", "CREATE", "CROSS", "CUBE", "CURRENT", "CURRENT_PATH", "CURRENT_ROLE", "CURSOR", "CYCLE",
            "DATA", "DATALINK", "DAY", "DEALLOCATE", "DEC", "DECLARE", "DEFAULT", "DEFERRABLE", "DELETE", "DEPTH", "DEREF", "DESC", "DESCRIPTOR", "DIAGNOSTICS", "DICTIONARY", "DISCONNECT", "DO", "DOMAIN", "DOUBLE", "DROP",
            "END-EXEC", "EQUALS", "ESCAPE", "EXCEPT", "EXCEPTION", "EXECUTE", "EXIT", "EXPAND", "EXPANDING", 
            "FALSE", "FIRST", "FOR", "FOREIGN", "FREE", "FROM", "FUNCTION",
            "GENERAL", "GET", "GLOBAL", "GOTO", "GROUP", "GROUPING",
            "HANDLER", "HASH", "HOUR",
            "IDENTITY", "IF", "IGNORE", "IMMEDIATE", "INDICATOR", "INITIALIZE", "INITIALLY", "INNER", "INOUT", "INPUT", "INSERT", "INT", "INTERSECT", "INTERVAL", "INTO", "IS", "ISOLATION", "ITERATE",
            "JOIN",
            "KEY",
            "LANGUAGE", "LARGE", "LAST", "LATERAL", "LEADING", "LEAVE", "LEFT", "LESS", "LEVEL", "LIMIT", "LOCAL", "LOCALTIME", "LOCALTIMESTAMP", "LOCATOR", "LOOP",
            "MATCH", "MEETS", "MINUTE", "MODIFIES", "MODIFY", "MODULE", "MONTH",
            "NAMES", "NATIONAL", "NATURAL", "NEW", "NEXT", "NO", "NONE", "NORMALIZE", "NOT", "NULL",
            "OBJECT", "OF", "NUMERIC", "OBJECT", "OF", "OFF", "OLD", "ON", "ONLY", "OPEN", "OPERATION", "OPTION", "OR", "ORDER", "ORDINALITY", "OUT", "OUTER", "OUTPUT",
            "PAD", "PARAMETER", "PARAMETERS", "PARTIAL", "PATH", "PERIOD", "POSTFIX", "PRECEDES", "PRECISION", "PREFIX", "PREORDER", "PREPARE", "PRESERVE", "PRIMARY", "PRIOR", "PRIVILEGES", "PROCEDURE", "PUBLIC",
            "READ", "READS", "REAL", "RECURSIVE", "REDO", "REF", "REFERENCES", "REFERENCING", "RELATIVE", "REPEAT", "RESIGNAL", "RESTRICT", "RESULT", "RETURN", "RETURNS", "REVOKE", "RIGHT", "ROLE", "ROLLBACK", "ROLLUP", "ROUTINE", "ROW", "ROWS",
            "SAVEPOINT", "SCHEMA", "SCROLL", "SEARCH", "SECOND", "SECTION", "SELECT", "SEQUENCE", "SESSION", "SET", "SETS", "SIGNAL", "SIZE", "SPECIFIC", "SPECIFICTYPE", "SQL", "SQLEXCEPTION", "SQLSTATE", "SQLWARNING", "START", "STATE", "STATIC", "STRUCTURE", "SUCCEEDS",
            "TABLE", "TEMPORARY", "TERMINATE", "THAN", "THEN", "TIMEZONE_HOUR", "TIMEZONE_MINUTE", "TO", "TRAILING", "TRANSACTION", "TRANSLATION", "TREAT", "TRIGGER", "TRUE",
            "UNDER", "UNDO", "UNION", "UNIQUE", "UNKNOWN", "UNTIL", "UPDATE", "USAGE", "USER", "USING",
            "VALUE", "VALUES", "VALUES", "VARIABLE", "VARYING", "VIEW",
            "WHEN", "WHENEVER", "WHERE", "WHILE", "WITH", "WRITE",
            "YEAR",
            "ZONE"
        };

        public static readonly string[] FUNCTIONS = {            
            "AVG", "COUNT", "MIN", "MAX", "SUM",    // Aggregate            
            "CURRENT_DATE", "CURRENT_TIME", "CURRENT_TIMESTAMP", "CURRENT_USER", "SESSION_USER", "SYSTEM_USER", // Scalar - Built-in                    
            "BIT_LENGTH", "CHAR_LENGTH", "EXTRACT", "OCTET_LENGTH", "POSITION", // Scalar - Numeric                    
            "CONCATENATE", "CONVERT", "LOWER", "SUBSTRING", "TRANSLATE", "TRIM", "UPPER"    // Scalar - String
        };

        public static readonly string[] OPERATORS = {
            "+", "-", "*", "/",
            "=", "<>", "!=", "<", ">", "<=", ">=",
            "ALL", "AND", "ANY", "BETWEEN", "EXISTS", "IN", "LIKE", "NOT", "OR", "SOME"
        };

        public static readonly string[] DATA_TYPES = {
            "BLOB", 
            "BIT",
            "BOOLEAN",
            "CHAR", "CHARACTER", "CLOB", "NCHAR", "NCLOB", "NVARCHAR", "VARCHAR",
            "DECIMAL", "FLOAT", "INTEGER", "NUMERIC", "REAL", "SMALLINT",
            "DATE", "INTERVAL", "TIME", "TIMESTAMP"
        };
    }
}
