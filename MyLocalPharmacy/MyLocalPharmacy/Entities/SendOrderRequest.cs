using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalPharmacy.Entities
{
    [DataContract]
   public class SendOrderRequest
    {
        [DataContract]
        public class Prescription
        {
            [DataMember(Name = "drugname")]
            public string drugname { get; set; }
             [DataMember(Name = "reason")]
            public string reason { get; set; }
             [DataMember(Name = "quantity")]
            public object quantity { get; set; }
             [DataMember(Name = "vmp")]
            public string vmp { get; set; }
             [DataMember(Name = "vmpp")]
            public string vmpp { get; set; }
             [DataMember(Name = "amp")]
            public string amp { get; set; }
             [DataMember(Name = "ampp")]
            public string ampp { get; set; }
        }
        [DataContract]
        public class RootObject
        {
             [DataMember(Name = "pharmacyid")]
            public string pharmacyid { get; set; }
             [DataMember(Name = "mail")]
            public string mail { get; set; }
             [DataMember(Name = "pin")]
            public string pin { get; set; }
             [DataMember(Name = "prescriptions")]
            public List<Prescription> prescriptions { get; set; }
        }
    }
}
