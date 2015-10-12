using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MitchellClaimWebApi.Models
{
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.mitchell.com/examples/claim")]
    [DataContract]
    public class VehicleModel
    {
         [DataMember]
        public int ModelYear { get; set; }
         [DataMember]
        public string MakeDescription { get; set; }
         [DataMember]
        public string ModelDescription { get; set; }
         [DataMember]
        public string EngineDescription { get; set; }
         [DataMember]
        public string ExteriorColor { get; set; }
         [DataMember]
        public string Vin { get; set; }
         [DataMember]
        public string LicPlate { get; set; }
         [DataMember]
        public string LicPlateState { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
         [DataMember]
        public DateTime LicPlateExpDate { get; set; }
         [DataMember]
        public string DamageDescription { get; set; }
         [DataMember]
        public int Mileage { get; set; }          
    }
}