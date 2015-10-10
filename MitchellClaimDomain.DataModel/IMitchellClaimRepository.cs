using MitchellClaimDomain.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchellClaimDomain.DataModel
{
    public interface IMitchellClaimRepository
    {
        int AddMitchellClaim(MitchellClaimType mitchellClaimType);
        MitchellClaimType GetMitchellClaimByClaimNumber(string clainNumber);
        MitchellClaimType GetMitchellClaimByClaimId(int claimId);
        List<MitchellClaimType> GetMitchellClaimsByLossDate(DateTime date1, DateTime date2);
        bool UpdateMitchellClaim(MitchellClaimType mitchellClaimType);
        VehicleInfoType GetMitchellClaimVehicle(string claimNumber, string vin);
        bool DeleteMitchellClaim(string claimNumber);
    }
}
