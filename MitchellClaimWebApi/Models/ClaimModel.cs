using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MitchellClaimWebApi.Models
{
    public class ClaimModel
    {
        public string Url { get; set; }
        public string ClaimNumber { get; set; }
        public string ClaimFirstName { get; set; }
        public string ClaimLastName { get; set; }
        public string Status { get; set; }
        public DateTime LossDate { get; set; }
        public LossInfoModel LossInfo { get; set; }
        public long AssignedAdjusterID { get; set; }
        public IEnumerable<VehicleModel> Vehicles { get; set; }
    }
}