using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalPharmacy.Entities
{
    [DataContract]
  public  class GetOrderStatusRequest
    {
        [DataContract]
        public class RootObject
        {
            [DataMember(Name = "mail")]
            public string mail { get; set; }
            [DataMember(Name = "pin")]
            public string pin { get; set; }
            [DataMember(Name = "orderid")]
            public int orderid { get; set; }
        }
    }
}
