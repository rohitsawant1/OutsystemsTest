/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OutSystems.RESTService.Behaviors {
    public interface IBehaviorsConfiguration : ICloneable {
        DefaultValuesBehavior DefaultValuesBehavior { get; }
        HTTPSecurity HTTPSecurity { get; set; }
        DateTimeFormat DateTimeFormat { get; set; }
        bool InternalAccessOnly { get; set; }
        JsonSerializerSettings SerializerSettings {
            get;
        }
        bool IsRESTRequest { get; set; }
        bool IncludeBinariesURL { get; set; }
        bool OptimizeBinaries { get; set; }
        HashSet<string> BinariesUsed { get; }
    }
}
