/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutSystems.HubEdition.DatabaseProvider.iDB2.Extensions
{
    static class StringBuilderExtensions
    {
        public static StringBuilder AppendConnectionStringParam(this StringBuilder sb, String id, String value)
        {
            if (!string.IsNullOrEmpty(value))
                sb.AppendFormat("{0}={1};",id,value);

            return sb;
        }
    }
}
