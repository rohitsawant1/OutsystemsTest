/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace OutSystems.HubEdition.WebWidgets {
    public interface IValidationMessages {
        string MandatoryValidatorMsg{get;}
        string IntegerValidatorMsg { get; }
        string DecimalValidatorMsg { get; }
        string CurrencyValidatorMsg { get; }
        string DateValidatorMsg { get; }
        string TimeValidatorMsg { get; }
        string DateTimeValidatorMsg { get; }
        string TextValidatorMsg { get; }
        string PhoneNumberValidatorMsg { get; }
        string NumericPasswordValidatorMsg { get; }
        string EmailValidatorMsg { get; }
    }
}
