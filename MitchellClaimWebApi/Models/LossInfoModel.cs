using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MitchellClaimWebApi.Models
{
    public class LossInfoModel
    {
        public string Url { get; set; }
        public string CauseOfLoss { get; set; }
        public DateTime ReportedDate { get; set; }
        public string LossDescription { get; set; }
    }
}