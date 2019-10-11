/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

namespace OutSystems.HubEdition.Extensibility.Data.DMLService {

    /// <summary>
    /// Base implementation for generating the DML functions required by the applications to perform simple queries
    /// </summary>
    public abstract class BaseDMLFunctions : IDMLFunctions {

        protected BaseDMLFunctions(IDMLService dmlService) {
            DMLService = dmlService;
        }

        /// <summary>
        /// This property represents the associated DML service.
        /// </summary>
        public IDMLService DMLService { get; private set; }

        #region Math

        /// <summary>
        /// Returns a DML expression that computes the absolute value (unsigned magnitude) of a decimal number.
        /// This implementation returns <code>Abs(n)</code>.
        /// </summary>
        /// <param name="n">A string representing a decimal number.</param>
        /// <returns>A DML expression that evaluates to a Decimal.</returns>
        public virtual string Abs(string n) {
            return string.Format("Abs({0})", n);
        }

        /// <summary>
        /// Returns a DML expression that computes the decimal number 'n' rounded to the zero fractional digits.
        /// This implementation returns <code>Round(n,0)</code>.
        /// </summary>
        /// <param name="n">DML expression of type Decimal that evaluates to the decimal number to round</param>
        /// <returns>A DML expression that evaluates to a Decimal.</returns>
        public virtual string Round(string n) {
            return string.Format("Round({0}, 0)", n);
        }

        /// <summary>
        /// Returns a DML expression that computes the square root of the decimal number 'n'.
        /// This implementation returns <code>Sqrt(n)</code>.
        /// </summary>
        /// <param name="n">DML expression of type Decimal that evaluates to a decimal number</param>
        /// <returns>A DML expression that evaluates to a Decimal.</returns>
        public virtual string Sqrt(string n) {
            return string.Format("Sqrt({0})", n);
        }

        /// <summary>
        /// Returns a DML expression that computes the decimal number 'n' truncated to integer removing the decimal part of 'n'.
        /// </summary>
        /// <param name="n">DML expression of type Decimal that evaluates to the decimal number to truncate</param>
        /// <returns>A DML expression that evaluates to a Decimal.</returns>
        public abstract string Trunc(string n);

        #endregion

        #region Text

        /// <summary>
        /// Returns a DML expression that concatenates two strings: 't1' and 't2'.
        /// </summary>
        /// <param name="t1">A DML expression that evaluates to Text.</param>
        /// <param name="t2">A DML expression that evaluates to Text.</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        public virtual string Concat(string t1, string t2){
            return string.Format("concat({0},{1})", t1, t2);
        }


        /// <summary>
        /// Returns a DML expression that coalesce two arguments: 't1' and 't2' (returning the first non null one).
        /// </summary>
        /// <param name="t1">A DML expression with no specific type.</param>
        /// <param name="t2">A DML expression with no specific type.</param>
        /// <returns>A DML expression with no specific type.</returns>
        public virtual string Coalesce(string t1, string t2) {
            return string.Format("coalesce({0},{1})", t1, t2);
        }

        /// <summary>
        /// Returns a DML expression that searches an expression for another expression and returns its starting position if found.
        /// Returns -1 if the <paramref name="search"/> expression is empty or cannot be found.
        /// </summary>
        /// <param name="t">A DML expression that evaluates to Text.</param>
        /// <param name="search">A DML expression that evaluates to Text.</param>
        /// <returns>A DML expression that evaluates to an Integer.</returns>
        public abstract string Index(string t, string search);

        /// <summary>
        /// Returns a DML expression that computes the number of characters in a string.
        /// </summary>
        /// <param name="t">A DML expression that evaluates to Text.</param>
        /// <returns>A DML expression that evaluates to an Integer.</returns>
        public abstract string Length(string t);

        /// <summary>
        /// Returns a DML expression that replaces all occurrences of a specified string value with another string value.
        /// The base implementation returns 'Replace(t, search, replace)'.
        /// </summary>
        /// <param name="t">A DML expression that evaluates to Text.</param>
        /// <param name="search">A DML expression that evaluates to Text, to search for.</param>
        /// <param name="replace">A DML expression that evaluates to Text, to replace all occurrences with.</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        public virtual string Replace(string t, string search, string replace) {
            return string.Format("Replace({0}, {1}, {2})", t, search, replace);
        }


        /// <summary>
        /// Returns a DML expression that computes a substring beginning at <code>start</code> zero-based position
        /// and with <code>length</code> characters.
        /// </summary>
        /// <param name="t">A DML expression that evaluates to Text.</param>
        /// <param name="start">A DML expression that evaluates to an Integer, containing the start index.</param>
        /// <param name="length">A DML expression that evaluates to an Integer, containing the length of the text to return.</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        public abstract string Substr(string t, string start, string length);

        /// <summary>
        /// Returns a DML expression that converts a string to lowercase.
        /// The base implementation returns 'Lower(t)'.
        /// </summary>
        /// <param name="t">A DML expression that evaluates to Text.</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        public virtual string ToLower(string t) {
            return string.Format("Lower({0})", t);
        }

        /// <summary>
        /// Returns a DML expression that converts a string to uppercase.
        /// The base implementation returns 'Upper(t)'.
        /// </summary>
        /// <param name="t">A DML expression that evaluates to Text.</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        public virtual string ToUpper(string t) {
            return string.Format("Upper({0})", t);
        }

        /// <summary>
        /// Returns a DML expression that removes all leading and trailing white spaces from a string.
        /// </summary>
        /// <param name="t">A DML expression that evaluates to Text.</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        public abstract string Trim(string t);

        /// <summary>
        /// Returns a DML expression that removes all trailing white spaces from a string.
        /// The base implementation returns 'RTrim(t)'.
        /// </summary>
        /// <param name="t">A DML expression that evaluates to Text.</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        public virtual string TrimEnd(string t) {
            return string.Format("RTrim({0})", t);
        }

        /// <summary>
        /// Returns a DML expression that removes all leading white spaces from a string.
        /// The base implementation returns 'LTrim(t)'.
        /// </summary>
        /// <param name="t">A DML expression that evaluates to Text.</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        public virtual string TrimStart(string t) {
            return string.Format("LTrim({0})", t);
        }

        #endregion

        #region Date & Time

        /// <summary>
        /// Returns a DML expression that adds days to a DateTime and returns a valid DataTime.
        /// </summary>
        /// <param name="dt">A DML expression that evaluates to a DateTime.</param>
        /// <param name="n">A DML expression that evaluates to a Integer.</param>
        /// <returns>A DML expression that evaluates to a DateTime.</returns>
        public abstract string AddDays(string dt, string n);

        /// <summary>
        /// Returns a DML expression that adds days to a DateTime and returns a valid DataTime.
        /// </summary>
        /// <param name="dt">A DML expression that evaluates to a DateTime.</param>
        /// <param name="n">A DML expression that evaluates to a Integer.</param>
        /// <returns>A DML expression that evaluates to a DateTime.</returns>
        public abstract string AddHours(string dt, string n);

        /// <summary>
        /// Returns a DML expression that adds minutes to a DateTime and returns a valid DateTime.
        /// </summary>
        /// <param name="dt">A DML expression that evaluates to a DateTime.</param>
        /// <param name="n">A DML expression that evaluates to an Integer.</param>
        /// <returns>A DML expression that evaluates to a DateTime.</returns>
        public abstract string AddMinutes(string dt, string n);

        /// <summary>
        /// Returns a DML expression that adds months to a DateTime and returns a valid DateTime.
        /// </summary>
        /// <param name="dt">A DML expression that evaluates to a DateTime.</param>
        /// <param name="n">A DML expression that evaluates to an Integer.</param>
        /// <returns>A DML expression that evaluates to a DateTime.</returns>
        public abstract string AddMonths(string dt, string n);

        /// <summary>
        /// Returns a DML expression that adds seconds to a DateTime and returns a valid DateTime.
        /// </summary>
        /// <param name="dt">A DML expression that evaluates to a DateTime.</param>
        /// <param name="n">A DML expression that evaluates to an Integer.</param>
        /// <returns>A DML expression that evaluates to a DateTime.</returns>
        public abstract string AddSeconds(string dt, string n);

        /// <summary>
        /// Returns a DML expression that adds years to a DateTime and returns a valid DateTime.
        /// </summary>
        /// <param name="dt">A DML expression that evaluates to a DateTime.</param>
        /// <param name="n">A DML expression that evaluates to an Integer.</param>
        /// <returns>A DML expression that evaluates to a DateTime.</returns>
        public abstract string AddYears(string dt, string n);

        /// <summary>
        /// Returns a DML expression that creates a new DateTime given a Date and a Time.
        /// </summary>
        /// <param name="d">A DML expression that evaluates to a Date.</param>
        /// <param name="t">A DML expression that evaluates to a Time.</param>
        /// <returns>A DML expression that evaluates to a DateTime.</returns>
        public abstract string BuildDateTime(string d, string t);

        /// <summary>
        /// Returns a DML expression that computes the day of a DateTime.
        /// </summary>
        /// <param name="dt">A DML expression that evaluates to a DateTime.</param>
        /// <returns>A DML expression that evaluates to an Integer.</returns>
        public abstract string Day(string dt);

        /// <summary>
        /// Returns a DML expression that computes the week day of a DateTime, ranging from 0 (Sunday) to 6 (Saturday).
        /// </summary>
        /// <param name="dt">A DML expression that evaluates to a DateTime.</param>
        /// <returns>A DML expression that evaluates to an Integer.</returns>
        public abstract string DayOfWeek(string dt);

        /// <summary>
        /// Returns a DML expression that computes how many days have passed between two DateTimes.
        /// Returns zero if the two dates are the same, a positive integer if <paramref name="dt1"/> is smaller than <paramref name="dt2"/>, and
        /// a negative number otherwise.
        /// </summary>
        /// <param name="dt1">First DML expression that evaluates to a DateTime.</param>
        /// <param name="dt2">Second DML expression that evaluates to a DateTime.</param>
        /// <returns>A DML expression that evaluates to an Integer.</returns>
        public abstract string DiffDays(string dt1, string dt2);

        /// <summary>
        /// Returns a DML expression that computes how many hours have passed between two DateTimes.
        /// Returns zero if the two dates and hours are the same, a positive integer if <paramref name="dt1"/> is smaller than <paramref name="dt2"/>, and
        /// a negative number otherwise.
        /// </summary>
        /// <param name="dt1">First DML expression that evaluates to a DateTime.</param>
        /// <param name="dt2">Second DML expression that evaluates to a DateTime.</param>
        /// <returns>A DML expression that evaluates to an Integer.</returns>
        public abstract string DiffHours(string dt1, string dt2);

        /// <summary>
        /// Returns a DML expression that computes how many minutes have passed between two DateTimes.
        /// Returns zero if the two dates, hours and minutes are the same, a positive integer if <paramref name="dt1"/> is smaller than <paramref name="dt2"/>, and
        /// a negative number otherwise.
        /// </summary>
        /// <param name="dt1">A DML expression that evaluates to a DateTime.</param>
        /// <param name="dt2">A DML expression that evaluates to a DateTime.</param>
        /// <returns>A DML expression that evaluates to an Integer.</returns>
        public abstract string DiffMinutes(string dt1, string dt2);

        /// <summary>
        /// Returns a DML expression that computes how many seconds have passed between two DateTimes.
        /// Returns zero if the two dates, hours, minutes, and seconds are the same, a positive integer if <paramref name="dt1"/> is smaller than
        /// <paramref name="dt2"/>, and a negative number otherwise.
        /// </summary>
        /// <param name="dt1">A DML expression that evaluates to a DateTime.</param>
        /// <param name="dt2">A DML expression that evaluates to a DateTime.</param>
        /// <returns>A DML expression that evaluates to an Integer.</returns>
        public abstract string DiffSeconds(string dt1, string dt2);

        /// <summary>
        /// Returns a DML expression that computes the hour part of a DateTime.
        /// </summary>
        /// <param name="dt">A DML expression that evaluates to a DateTime.</param>
        /// <returns>A DML expression that evaluates to an Integer.</returns>
        public abstract string Hour(string dt);
        /// <summary>
        /// Returns a DML expression that computes the minute part of a DateTime.
        /// </summary>
        /// <param name="dt">A DML expression that evaluates to a DateTime.</param>
        /// <returns>A DML expression that evaluates to an Integer.</returns>
        public abstract string Minute(string dt);

        /// <summary>
        /// Returns a DML expression that computes the month part of a DateTime.
        /// </summary>
        /// <param name="dt">A DML expression that evaluates to a DateTime.</param>
        /// <returns>A DML expression that evaluates to an Integer.</returns>
        public abstract string Month(string dt);

        /// <summary>
        /// Returns a DML expression that computes a new date from a year, month, and day.
        /// </summary>
        /// <param name="y">A DML expression that evaluates to an Integer.</param>
        /// <param name="m">A DML expression that evaluates to an Integer.</param>
        /// <param name="d">A DML expression that evaluates to an Integer.</param>
        /// <returns>A DML expression that evaluates to a Date.</returns>
        public abstract string NewDate(string y, string m, string d);

        /// <summary>
        /// Returns a DML expression that computes a new DateTime from a year, month, day, hour, minute, and second.
        /// </summary>
        /// <param name="y">A DML expression that evaluates to an Integer.</param>
        /// <param name="mo">A DML expression that evaluates to an Integer.</param>
        /// <param name="d">A DML expression that evaluates to an Integer.</param>
        /// <param name="h">A DML expression that evaluates to an Integer.</param>
        /// <param name="m">A DML expression that evaluates to an Integer.</param>
        /// <param name="s">A DML expression that evaluates to an Integer.</param>
        /// <returns>A DML expression that evaluates to DateTime.</returns>
        public abstract string NewDateTime(string y, string mo, string d, string h, string m, string s);

        /// <summary>
        /// Returns a DML expression that computes a new Time from an hour, minute, and second.
        /// </summary>
        /// <param name="h">A DML expression that evaluates to an Integer.</param>
        /// <param name="m">A DML expression that evaluates to an Integer.</param>
        /// <param name="s">A DML expression that evaluates to an Integer.</param>
        /// <returns>A DML expression that evaluates to Time.</returns>
        public abstract string NewTime(string h, string m, string s);

        /// <summary>
        /// Returns a DML expression that computes the seconds part of a DateTime.
        /// </summary>
        /// <param name="dt">A DML expression that evaluates to a DateTime.</param>
        /// <returns>A DML expression that evaluates to an Integer.</returns>
        public abstract string Second(string dt);

        /// <summary>
        /// Returns a DML expression that computes the year part of a DateTime.
        /// </summary>
        /// <param name="dt">A DML expression that evaluates to a DateTime.</param>
        /// <returns>A DML expression that evaluates to an Integer.</returns>
        public abstract string Year(string dt);

        #endregion

        #region Data Conversion

        /// <summary>
        /// Returns a DML expression that converts a Boolean expression to an Integer. The expression evaluates into
        /// 1 if the boolean is True, or 0 if False.
        /// </summary>
        /// <param name="b">A DML expression that evaluates to a Boolean.</param>
        /// <returns>A DML expression that evaluates to an Integer.</returns>
        public abstract string BooleanToInteger(string b);

        /// <summary>
        /// Returns a DML expression that converts a Boolean in its textual representation: <code>True</code> or <code>False</code>.
        /// </summary>
        /// <param name="b">A DML expression that evaluates to Boolean.</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        public abstract string BooleanToText(string b);

        /// <summary>
        /// Returns a DML expression that converts a DateTime to a Date, by dropping the Time component.
        /// </summary>
        /// <param name="dt">A DML expression that evaluates to a DateTime.</param>
        /// <returns>A DML expression that evaluates to a Date.</returns>
        public abstract string DateTimeToDate(string dt);

        /// <summary>
        /// Returns a DML expression that converts a DateTime to its textual representation, using a specified format.
        /// </summary>
        /// <param name="dt">A DML expression that evaluates to a DateTime.</param>
        /// <param name="dateFormat">Date format used to serialize the date component of the text value (e.g. YYYY-MM-DD).</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        public abstract string DateTimeToText(string dt, string dateFormat);

        /// <summary>
        /// Returns a DML expression that converts a DateTime to a Time, by dropping the Date component.
        /// </summary>
        /// <param name="dt">A DML expression that evaluates to a DateTime.</param>
        /// <returns>A DML expression that evaluates to a Time.</returns>
        public abstract string DateTimeToTime(string dt);

        /// <summary>
        /// Returns a DML expression that converts a Date to a DateTime, by adding an empty Time component (00:00:00).
        /// </summary>
        /// <param name="d">A DML expression that evaluates to a Date.</param>
        /// <returns>A DML expression that evaluates to a DateTime.</returns>
        public virtual string DateToDateTime(string d) {
            return d;
        }

        /// <summary>
        /// Returns a DML expression that converts a Date to its textual representation, using a specified format.
        /// </summary>
        /// <param name="d">A DML expression that evaluates to a Date.</param>
        /// <param name="dateFormat">Date format used to serialize the date component of the text value (e.g. YYYY-MM-DD).</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        public abstract string DateToText(string d, string dateFormat);

        /// <summary>
        /// Returns an SQL expression that converts a Decimal to a Boolean. A Decimal value of 0.0 is False, all other values are True.
        /// </summary>
        /// <param name="d">A DML expression that evaluates to a Decimal.</param>
        /// <returns>A DML expression that evaluates to Boolean.</returns>
        public abstract string DecimalToBoolean(string d);

        /// <summary>
        /// Returns a DML expression that converts a Decimal to an Integer.
        /// </summary>
        /// <param name="d">A DML expression that evaluates to a Decimal.</param>
        /// <returns>A DML expression that evaluates to Integer.</returns>
        public abstract string DecimalToInteger(string d);

        /// <summary>
        /// Returns a DML expression that converts a Decimal to a Long Integer.
        /// </summary>
        /// <param name="d">A DML expression that evaluates to a Decimal.</param>
        /// <returns>A DML expression that evaluates to Long Integer.</returns>
        public abstract string DecimalToLongInteger(string d);

        /// <summary>
        /// Returns a DML expression that converts a Decimal to its textual representation.
        /// </summary>
        /// <param name="d">A DML expression that evaluates to a Decimal.</param>
        /// <returns>A DML expression that evaluates to a Decimal.</returns>
        public abstract string DecimalToText(string d);

        /// <summary>
        /// Provides a DML expression that converts Identifier 'id' to an Integer value.
        /// </summary>
        /// <param name="id">DML expression that evaluates to an integer value</param>
        /// <returns>DML expression of type Integer</returns>
        public abstract string IdentifierToInteger(string id);

        /// <summary>
        /// Provides a DML expression that converts Identifier 'id' to a Long Integer value.
        /// </summary>
        /// <param name="id">DML expression that evaluates to a Long Integer value</param>
        /// <returns>DML expression of type Long Integer</returns>
        public abstract string IdentifierToLongInteger(string id);

        /// <summary>
        /// Returns a DML expression that converts an Identifier to its textual representation.
        /// </summary>
        /// <param name="id">A DML expression that evaluates to Text.</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        public abstract string IdentifierToText(string id);

        /// <summary>
        /// Returns a DML expression that converts an Integer to a Boolean.
        /// A Decimal value of 0 is False, all other values are True.
        /// </summary>
        /// <param name="i">A DML expression that evaluates to an Integer.</param>
        /// <returns>A DML expression that evaluates to a Boolean.</returns>
        public abstract string IntegerToBoolean(string i);

        /// <summary>
        /// Returns a DML expression that converts an Integer to a Decimal.
        /// </summary>
        /// <param name="i">A DML expression that evaluates to an Integer.</param>
        /// <returns>A DML expression that evaluates to a decimal.</returns>
        public abstract string IntegerToDecimal(string i);

        /// <summary>
        /// Returns a DML expression that converts an Integer to an (untyped) Identifier.
        /// </summary>
        /// <param name="i">A DML expression that evaluates to an Integer.</param>
        /// <returns>A DML expression that evaluates to an Integer.</returns>
        public virtual string IntegerToIdentifier(string i) {
            return i;
        }

        /// <summary>
        /// Returns a DML expression that converts a Long Integer to an (untyped) Identifier.
        /// </summary>
        /// <param name="b">A DML expression that evaluates to a Long Integer.</param>
        /// <returns>A DML expression that evaluates to a Long Integer.</returns>
        public virtual string LongIntegerToIdentifier(string b) {
            return b;
        }

        /// <summary>
        /// Returns a DML expression that converts a Long Integer to an Integer.
        /// </summary>
        /// <param name="b">A DML expression that evaluates to a Long Integer.</param>
        /// <returns>A DML expression that evaluates to Integer.</returns>
        public abstract string LongIntegerToInteger(string b);

        /// <summary>
        /// Returns a DML expression that converts a Long Integer to a Decimal.
        /// </summary>
        /// <param name="b">A DML expression that evaluates to a Long Integer.</param>
        /// <returns>A DML expression that evaluates to Decimal.</returns>
        public abstract string LongIntegerToDecimal(string b);

        /// <summary>
        /// Returns a DML expression that converts an Integer to a Long Integer.
        /// </summary>
        /// <param name="b">A DML expression that evaluates to an Integer.</param>
        /// <returns>A DML expression that evaluates to Long Integer.</returns>
        public abstract string IntegerToLongInteger(string b);

        /// <summary>
        /// Returns a DML expression that converts a Long Integer to its textual representation.
        /// </summary>
        /// <param name="b">A DML expression that evaluates to a Long Integer.</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        public abstract string LongIntegerToText(string b);

        /// <summary>
        /// Returns a DML expression that converts an Integer to its textual representation.
        /// </summary>
        /// <param name="i">A DML expression that evaluates to an Integer.</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        public abstract string IntegerToText(string i);

        /// <summary>
        /// Returns a DML expression that computes a Null Date (1900-01-01).
        /// </summary>
        /// <returns>A DML expression that evaluates to a Date.</returns>
        public abstract string NullDate();

        /// <summary>
        /// Returns a DML expression that returns a Null Numeric Identifier.
        /// This implementation always returns zero.
        /// </summary>
        /// <returns>A DML expression that evaluates to an Integer.</returns>
        public virtual string NullIdentifier() {
            return "0";
        }

        /// <summary>
        /// Returns a DML expression that computes a Null Text Identifier.
        /// This implementation always returns <code>''</code>.
        /// </summary>
        /// <returns>A DML expression that evaluates to Text.</returns>
        public virtual string NullTextIdentifier() {
            return "''";
        }

        /// <summary>
        /// Returns a DML expression that converts Text to a Date.
        /// </summary>
        /// <param name="t">A DML expression that evaluates to Text.</param>
        /// <param name="dateFormat">Date format used to serialize the date component of the text value (e.g. YYYY-MM-DD).</param>
        /// <returns>A DML expression that evaluates to a Date.</returns>
        public abstract string TextToDate(string t, string dateFormat);

        /// <summary>
        /// Provides a DML expression that converts Text 't' to a DateTime value.
        /// </summary>
        /// <param name="t">DML expression that evaluates to a text value</param>
        /// <param name="dateFormat">date format used to serialize the date component of the text value (e.g. YYYY-MM-DD)</param>
        /// <returns>DML expression of type DateTime</returns>
        public abstract string TextToDateTime(string t, string dateFormat);

        /// <summary>
        /// Returns a DML expression that converts Text to a DateTime.
        /// </summary>
        /// <param name="t">A DML expression that evaluates to Text.</param>
        /// <returns>A DML expression that evaluates to a DateTime.</returns>
        public abstract string TextToDecimal(string t);

        /// <summary>
        /// Returns a DML expression that converts Text to an (untyped) Identifier.
        /// </summary>
        /// <param name="t">A DML expression that evaluates to Text.</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        public virtual string TextToIdentifier(string t) {
            return t;
        }

        /// <summary>
        /// Returns a DML expression that converts Text to an Integer.
        /// </summary>
        /// <param name="t">A DML expression that evaluates to Text.</param>
        /// <returns>A DML expression that evaluates to an Integer.</returns>
        public abstract string TextToInteger(string t);

        /// <summary>
        /// Returns a DML expression that converts Text to a Long Integer.
        /// </summary>
        /// <param name="t">A DML expression that evaluates to Text.</param>
        /// <returns>A DML expression that evaluates to a Long Integer.</returns>
        public abstract string TextToLongInteger(string t);

        /// <summary>
        /// Returns a DML expression that converts Text to Time.
        /// </summary>
        /// <param name="t">A DML expression that evaluates to Text.</param>
        /// <returns>A DML expression that evaluates to Time.</returns>
        public abstract string TextToTime(string t);

        /// <summary>
        /// Returns a DML expression that converts a Time to a DateTime, by adding an empty Date component (1900-01-01).
        /// </summary>
        /// <param name="t">A DML expression that evaluates to Time.</param>
        /// <returns>A DML expression that evaluates to DateTime.</returns>
        public virtual string TimeToDateTime(string t) {
            return t;
        }

        /// <summary>
        /// Returns a DML expression that converts a Time to its text value in the format <code>hh:mm:ss</code>.
        /// </summary>
        /// <param name="t">A DML expression that evaluates to Time.</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        public abstract string TimeToText(string t);

        #endregion

        #region Misc

        /// <summary>
        /// Returns a DML expression that returns <paramref name="trueReturn"/> if <paramref name="value"/> is True, otherwise, it returns <paramref name="falseReturn"/>.
        /// The base implementation returns 'CASE WHEN <paramref name="value"/> THEN <paramref name="trueReturn"/> ELSE <paramref name="falseReturn"/> END'
        /// </summary>
        /// <param name="value">A DML expression that evaluates to Boolean</param>
        /// <param name="trueReturn">A DML expression that evaluates to a specific type</param>
        /// <param name="falseReturn">A DML expression that evaluates to the same type as <paramref name="trueReturn"/></param>
        /// <returns>A DML expression that evaluates to the same type of <paramref name="trueReturn"/> and <paramref name="falseReturn"/></returns>
        public string IfElse(string value, string trueReturn, string falseReturn) {
            return string.Format("CASE WHEN {0} THEN {1} ELSE {2} END", value, trueReturn, falseReturn);
        }

        #endregion

    }
}
