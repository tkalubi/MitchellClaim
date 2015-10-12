using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MitchellClaimWebApi.Models
{
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.mitchell.com/examples/claim")]
    [DataContract]
    public class LossInfoModel
    {       
         [DataMember]
        public string CauseOfLoss { get; set; }
         [DataMember]
        public DateTime ReportedDate { get; set; }
         [DataMember]
        public string LossDescription { get; set; }
    }
}