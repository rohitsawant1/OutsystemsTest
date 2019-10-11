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
using System.Threading.Tasks;
using OutSystems.RESTService.Behaviors;

namespace OutSystems.RESTService {
    public abstract class AbstractRESTStructure<T> {

        /* "Normal" Types */

        protected byte[] ConvertToRest(byte[] value) {
            return value; // Currently no conversion is needed
        }

        protected byte[] ConvertToRestWithoutDefaults(byte[] value) {
            if (value == null || value.Length == 0) {
                return null; 
            }
            return ConvertToRest(value);
        }

        protected String ConvertToRest(String value) {
            return value; // Currently no conversion is needed
        }

        protected String ConvertToRestWithoutDefaults(String value, String defaultValue) {
            if (String.Equals(value, defaultValue)) {
                return null;
            }
            return ConvertToRest(value);
        }

        /* DateTimes */

        protected String ConvertDateToRest(DateTime value) {
            return Conversions.DateToText(value);
        }
        protected String ConvertDateToRestWithoutDefaults(DateTime value, DateTime defaultValue) {
            if (value.Equals(defaultValue)) {
                return null;
            }
            return ConvertDateToRest(value);
        }

        protected String ConvertTimeToRest(DateTime value) {
            return Conversions.TimeToText(value);
        }
        protected String ConvertTimeToRestWithoutDefaults(DateTime value, DateTime defaultValue) {
            if (value.Equals(defaultValue)) {
                return null;
            }
            return ConvertTimeToRest(value);
        }

        protected String ConvertDateTimeToRest(DateTime value, DateTimeFormat dateFormat) {
            return Conversions.DateTimeToRestType(value,dateFormat);
        }
        protected String ConvertDateTimeToRestWithoutDefaults(DateTime value, DateTime defaultValue, DateTimeFormat dateFormat) {
            if (value.Equals(defaultValue) || Conversions.NullDateTime == value) {
                return null;
            }
            return ConvertDateTimeToRest(value,dateFormat);
        }

        /* For Basic Types */

        protected Nullable<OSType> ConvertToRest<OSType>(OSType value) where OSType : struct {
            return new Nullable<OSType>(value);
        }

        protected Nullable<OSType> ConvertToRestWithoutDefaults<OSType>(OSType value, OSType defaultValue) where OSType : struct {
            if (value.Equals(defaultValue)) {
                return default(Nullable<OSType>);
            }
            return new Nullable<OSType>(value);
        }
        
        /* For Structures */

        protected RestType ConvertToRestWithoutDefaults<OSType, RestType>(OSType value, OSType defaultValue, Func<OSType, RestType> converter) where OSType : struct {
            if (defaultValue.Equals(value)) {
                return default(RestType);
            } else {
                return converter(value);
            }
        }
    }
}
