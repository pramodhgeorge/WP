using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalPharmacy.Entities
{
    [DataContract]
    public  class LoginParameters
    {
        [DataMember(Name = "pin")]
        public string Pin { get; set; } 
        
        [DataMember(Name = "mail")]
        public string Mail { get; set; } 
        
        
        [DataMember(Name = "pharmacyid")]
        public string Pharmacyid { get; set; } 
        
        
    }
}
