/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

namespace OutSystems.HubEdition.Extensibility.Data.DMLService {
    /// <summary>
    /// Generates the DML operators required by the applications to perform simple queries.
    /// </summary>
    public interface IDMLOperators {

        /// <summary>
        /// Gets the associated <see cref="IDMLService" />.
        /// </summary>
        /// <value>
        /// The DML service associated.
        /// </value>
        IDMLService DMLService { get; }

        /// <summary>
        /// Returns a DML expression that computes the numeric negation of a number.
        /// </summary>
        /// <param name="n">A DML expression that evaluates to a Decimal or Integer.</param>
        /// <returns>A DML expression that evaluates to a Decimal or Integer.</returns>
        string Negative(string n);

        /// <summary>
        /// Returns a DML expression that computes the logical negation.
        /// </summary>
        /// <param name="b">A DML expression that evaluates to a Boolean.</param>
        /// <returns>A DML expression that evaluates to a Boolean.</returns>
        string Not(string b);

        /// <summary>
        /// Returns a DML expression that checks if the value is NULL.
        /// </summary>
        /// <param name="v">A DML expression that evaluates to a value of any database type.</param>
        /// <returns>A DML expression that evaluates to a Boolean.</returns>
        string IsNull(string v);

        /// <summary>
        /// Returns a DML expression that checks if a is not NULL.
        /// </summary>
        /// <param name="v">A DML expression that evaluates to a value of any database type.</param>
        /// <returns>A DML expression that evaluates to a Boolean.</returns>
        string IsNotNull(string v);

        /// <summary>
        /// Returns a DML expression that concatenates two values.
        /// </summary>
        /// <param name="v1">A DML expression that evaluates to a value of any type except binary data.</param>
        /// <param name="v2">A DML expression that evaluates to a value of any type except binary data.</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        string Concatenate(string v1, string v2);

        /// <summary>
        /// Returns a DML expression that adds two numbers.
        /// </summary>
        /// <param name="n1">A DML expression that evaluates to a Decimal or Integer.</param>
        /// <param name="n2">A DML expression that evaluates to a Decimal or Integer.</param>
        /// <returns>A DML expression that evaluates to a Decimal or Integer.</returns>
        string Add(string n1, string n2);

        /// <summary>
        /// Returns a DML expression that subtracts two numbers.
        /// </summary>
        /// <param name="n1">A DML expression that evaluates to a Decimal or Integer.</param>
        /// <param name="n2">A DML expression that evaluates to a Decimal or Integer.</param>
        /// <returns>A DML expression that evaluates to a Decimal or Integer.</returns>
        string Subtract(string n1, string n2);

        /// <summary>
        /// Returns a DML expression that multiplies two numbers.
        /// </summary>
        /// <param name="n1">A DML expression that evaluates to a Decimal or Integer.</param>
        /// <param name="n2">A DML expression that evaluates to a Decimal or Integer.</param>
        /// <returns>A DML expression that evaluates to a Decimal or Integer.</returns>
        string Multiply(string n1, string n2);

        /// <summary>
        /// Returns a DML expression that divides two numbers.
        /// </summary>
        /// <param name="n1">A DML expression that evaluates to a Decimal or Integer.</param>
        /// <param name="n2">A DML expression that evaluates to a Decimal or Integer.</param>
        /// <returns>A DML expression that evaluates to a Decimal.</returns>
        string Divide(string n1, string n2);

        /// <summary>
        /// Returns a DML expression that checks if two values are equal.
        /// </summary>
        /// <param name="v1">A DML expression that evaluates to a value of any type except binary data.</param>
        /// <param name="v2">A DML expression that evaluates to a value of any type except binary data.</param>
        /// <returns>A DML expression that evaluates to Boolean.</returns>
        string Equal(string v1, string v2);

        /// <summary>
        /// Returns a DML expression that checks if two values are different.
        /// </summary>
        /// <param name="v1">A DML expression that evaluates to a value of any type except binary data.</param>
        /// <param name="v2">A DML expression that evaluates to a value of any type except binary data.</param>
        /// <returns>A DML expression that evaluates to Boolean.</returns>
        string NotEqual(string v1, string v2);

        /// <summary>
        /// Returns a DML expression that checks if a value is less than another.
        /// </summary>
        /// <param name="v1">A DML expression that evaluates to a value of any type except binary data.</param>
        /// <param name="v2">A DML expression that evaluates to a value of any type except binary data.</param>
        /// <returns>A DML expression that evaluates to Boolean.</returns>
        string LessThen(string v1, string v2);

        /// <summary>
        /// Returns a DML expression that checks if a value is less than or equal to another.
        /// </summary>
        /// <param name="v1">A DML expression that evaluates to a value of any type except binary data.</param>
        /// <param name="v2">A DML expression that evaluates to a value of any type except binary data.</param>
        /// <returns>A DML expression that evaluates to Boolean.</returns>
        string LessThanOrEqual(string v1, string v2);

        /// <summary>
        /// Returns a DML expression that checks if a value is greater than another.
        /// </summary>
        /// <param name="v1">A DML expression that evaluates to a value of any type except binary data.</param>
        /// <param name="v2">A DML expression that evaluates to a value of any type except binary data.</param>
        /// <returns>A DML expression that evaluates to Boolean.</returns>
        string GreaterThan(string v1, string v2);

        /// <summary>
        /// Returns a DML expression that checks if a value is less or equals to another.
        /// </summary>
        /// <param name="v1">A DML expression that evaluates to a value of any type except binary data.</param>
        /// <param name="v2">A DML expression that evaluates to a value of any type except binary data.</param>
        /// <returns>A DML expression that evaluates to Boolean.</returns>
        string GreaterThanOrEqual(string v1, string v2);

        /// <summary>
        /// Returns a DML expression that performs the logical AND.
        /// </summary>
        /// <param name="b1">A DML expression that evaluates to Boolean.</param>
        /// <param name="b2">A DML expression that evaluates to Boolean.</param>
        /// <returns>A DML expression that evaluates to Boolean.</returns>
        string And(string b1, string b2);

        /// <summary>
        /// Returns a DML expression that performs the logical OR.
        /// </summary>
        /// <param name="b1">A DML expression that evaluates to Boolean.</param>
        /// <param name="b2">A DML expression that evaluates to Boolean.</param>
        /// <returns>A DML expression that evaluates to Boolean.</returns>
        string Or(string b1, string b2);

        /// <summary>
        /// Provides a DML expression that checks whether a string matches a pattern.
        /// </summary>
        /// <param name="t1">A DML expression that evaluates to Text.</param>
        /// <param name="t2">A DML expression that evaluates to Text.</param>
        /// <returns>A DML expression that evaluates to Text.</returns>
        string Like(string t1, string t2);
    }
}
