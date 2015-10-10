using MitchellClaimDomain.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MitchellClaimDomain.Classes.Entities
{    
    public class VehicleInfoType : IModificationHistory
    {
        public VehicleInfoType()
        {
            this.MitchellClaimTypes = new HashSet<MitchellClaimType>();
        }
        public int Id { get; set; }
        public int ModelYear { get; set; }
        public string MakeDescription { get; set; }
        public string ModelDescription { get; set; }
        public string EngineDescription { get; set; }
        public string ExteriorColor { get; set; }
        public string Vin { get; set; }
        public string LicPlate { get; set; }
        public string LicPlateState { get; set; }
        public DateTime LicPlateExpDate { get; set; }
        public string DamageDescription { get; set; }
        public int Mileage { get; set; }
        public virtual ICollection<MitchellClaimType> MitchellClaimTypes { get; set; }       
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDirty { get; set; }

    }
}
