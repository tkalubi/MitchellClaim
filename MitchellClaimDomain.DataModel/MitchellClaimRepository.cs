using MitchellClaimDomain.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchellClaimDomain.DataModel
{
    public class MitchellClaimRepository : IMitchellClaimRepository
    {
        private MitchellClaimContext _mitchellClaimContext;

        public MitchellClaimRepository(MitchellClaimContext ctx)
        {
            _mitchellClaimContext = ctx;
        }

        public int AddMitchellClaim(MitchellClaimType mitchellClaimType)
        {

            MitchellClaimType mitchellClaimAdded = _mitchellClaimContext.MitchellClaimTypes.Add(mitchellClaimType);
            _mitchellClaimContext.SaveChanges();
            return mitchellClaimAdded.Id;

        }

        public MitchellClaimType GetMitchellClaimByClaimNumber(string clainNumber)
        {

            MitchellClaimType mitchellClaim = _mitchellClaimContext.MitchellClaimTypes.Where(x => x.ClaimNumber == clainNumber).FirstOrDefault();
            return mitchellClaim;

        }

        public List<MitchellClaimType> GetMitchellClaimsByLossDate(DateTime date1, DateTime date2)
        {

            return _mitchellClaimContext.MitchellClaimTypes.Where(x => x.LossDate >= date1 && x.LossDate <= date2).ToList();

        }

        public bool UpdateMitchellClaim(MitchellClaimType mitchellClaimType)
        {
            try
            {
                _mitchellClaimContext.Entry(mitchellClaimType).State = EntityState.Modified;
                _mitchellClaimContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public VehicleInfoType GetMitchellClaimVehicle(string claimNumber, string vin)
        {
            MitchellClaimType mitchellClaim = _mitchellClaimContext.MitchellClaimTypes.FirstOrDefault(x => x.ClaimNumber == claimNumber);
            if (mitchellClaim != null)
            {
                return mitchellClaim.Vehicles.FirstOrDefault(x => x.Vin == vin);
            }
            return null;
        }

        public MitchellClaimType GetMitchellClaimByClaimId(int claimId)
        {
            return _mitchellClaimContext.MitchellClaimTypes.FirstOrDefault(x => x.Id == claimId);
        }

        public bool DeleteMitchellClaim(string claimNumber)
        {
            try
            {
                MitchellClaimType mitchellClaim = _mitchellClaimContext.MitchellClaimTypes.FirstOrDefault(x => x.ClaimNumber == claimNumber);
                if (mitchellClaim != null)
                {
                    _mitchellClaimContext.MitchellClaimTypes.Remove(mitchellClaim);
                    _mitchellClaimContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }



    }
}
