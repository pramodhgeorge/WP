using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalPharmacy.Entities
{
    [DataContract]
    public class ResendConfirmationCodesRequest
    {
        [DataMember(Name = "mail")]
        public string mail { get; set; }
        [DataMember(Name = "pin")]
        public string pin { get; set; }
        [DataMember(Name = "pharmacyid")]
        public string pharmacyid { get; set; }

    }
}
