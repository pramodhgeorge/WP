using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalPharmacy.Entities
{
    [DataContract]
    public class GetPharmacyInformationRequest
    {
       
            [DataMember(Name = "pharmacyid")]
            public string Pharmacyid { get; set; }
            [DataMember(Name = "deviceid")]
            public string Deviceid { get; set; }
            [DataMember(Name = "model")]
            public string Model { get; set; }
            [DataMember(Name = "os")]
            public string Os { get; set; }
            [DataMember(Name = "branding_hash")]
            public string Branding_hash { get; set; }
            [DataMember(Name = "advert_hash")]
            public string Advert_hash { get; set; }
            [DataMember(Name = "drugs_hash")]
            public string Drugs_hash { get; set; }
       
    }
}
