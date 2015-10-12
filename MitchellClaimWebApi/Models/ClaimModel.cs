using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace MitchellClaimWebApi.Models
{
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.mitchell.com/examples/claim")]
    [System.Xml.Serialization.XmlRootAttribute("MitchellClaim", Namespace = "http://www.mitchell.com/examples/claim", IsNullable = false)]
    [DataContract]
    public class MitchellClaim
    {       
         [DataMember]
        public string ClaimNumber { get; set; }
         [DataMember]
        public string ClaimantFirstName { get; set; }
         [DataMember]
         public string ClaimantLastName { get; set; }
         [DataMember]
        public string Status { get; set; }
         [DataMember]
        public DateTime LossDate { get; set; }
         [DataMember]
        public LossInfoModel LossInfo { get; set; }
         [DataMember]
        public long AssignedAdjusterID { get; set; }
         [XmlArray("Vehicles")]
         [XmlArrayItem("VehicleDetails")]
         [DataMember]
        public VehicleModel[] Vehicles { get; set; }
    }
}