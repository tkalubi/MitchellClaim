using MitchellClaimDomain.Classes.Enumerations;
using MitchellClaimDomain.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchellClaimDomain.Classes.Entities
{   
    public class MitchellClaimType : IModificationHistory
    {
        public MitchellClaimType()
        {
            this.Vehicles = new HashSet<VehicleInfoType>();            
        }

        public int Id { get; set; }       
        public string ClaimNumber { get; set; }
        public string ClaimantFirstName { get; set; }
        public string ClaimantLastName { get; set; }
        public StatusCode Status { get; set; }
        public DateTime LossDate { get; set; }
        public virtual LossInfoType LossInfo { get; set; }
        public long AssignedAdjusterID { get; set; }
        public virtual ICollection<VehicleInfoType> Vehicles { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDirty { get; set; }

    }
}
