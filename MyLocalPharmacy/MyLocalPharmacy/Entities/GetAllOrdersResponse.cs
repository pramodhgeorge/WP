using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalPharmacy.Entities
{
    [DataContract]
   public class GetAllOrdersResponse
    {
        [DataContract]
        public class Prescription
        {
            [DataMember(Name = "pharmacyid")]
            public string pharmacyid { get; set; }
            [DataMember(Name = "pres")]
            public List<object> pres { get; set; }
            [DataMember(Name = "pharmacyname")]
            public string pharmacyname { get; set; }
        }

        [DataContract]
        public class Payload
        {
            [DataMember(Name = "prescriptions")]
            public List<Prescription> prescriptions { get; set; }
        }
        [DataContract]
        public class RootObject
        {
            [DataMember(Name = "status")]
            public int status { get; set; }
            [DataMember(Name = "message")]
            public object message { get; set; }
            [DataMember(Name = "payload")]
            public Payload payload { get; set; }
        }
    }
}
