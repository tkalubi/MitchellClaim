using MitchellClaimDomain.Classes.Enumerations;
using MitchellClaimDomain.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchellClaimDomain.Classes.Entities
{
    public class LossInfoType : IModificationHistory
    {
        public int Id { get; set; }        
        public CauseOfLossCode CauseOfLoss { get; set; }
        public DateTime ReportedDate { get; set; }
        public string LossDescription { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDirty { get; set; }

        public virtual MitchellClaimType Claim { get; set; }

    }
}
