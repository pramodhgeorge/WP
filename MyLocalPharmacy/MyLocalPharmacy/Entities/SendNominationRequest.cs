using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalPharmacy.Entities
{
      [DataContract]
        public class SendNominationRequestSurgery
        {
            [DataMember(Name = "name")]
            public string name { get; set; }
            [DataMember(Name = "address")]
            public string address { get; set; }
        }

        [DataContract]
        public class SendNominationRequest
        {
            [DataMember(Name = "pharmacyid")]
            public string pharmacyid { get; set; }
            [DataMember(Name = "deviceid")]
            public string deviceid { get; set; }
            [DataMember(Name = "model")]
            public string model { get; set; }
            [DataMember(Name = "os")]
            public string os { get; set; }
            [DataMember(Name = "pushid")]
            public string pushid { get; set; }
            [DataMember(Name = "fullname")]
            public string fullname { get; set; }
            [DataMember(Name = "nhs")]
            public string nhs { get; set; }
            [DataMember(Name = "birthdate")]
            public string birthdate { get; set; }
            [DataMember(Name = "address1")]
            public string address1 { get; set; }
            [DataMember(Name = "address2")]
            public string address2 { get; set; }
            [DataMember(Name = "postcode")]
            public string postcode { get; set; }
            [DataMember(Name = "phone")]
            public string phone { get; set; }
            [DataMember(Name = "mail")]
            public string mail { get; set; }
            [DataMember(Name = "sex")]
            public string sex { get; set; }
            [DataMember(Name = "pin")]
            public string pin { get; set; }
            [DataMember(Name = "country")]
            public string country { get; set; }
            [DataMember(Name = "mode")]
            public string mode { get; set; }
            [DataMember(Name = "verifyby")]
            public string verifyby { get; set; }
            [DataMember(Name = "surgery")]
            public SendNominationRequestSurgery surgery { get; set; }
        }
    
}
