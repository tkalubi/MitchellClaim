using MitchellClaimDomain.Classes.Entities;
using MitchellClaimDomain.Classes.Enumerations;
using MitchellClaimDomain.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace MitchellClaimWebApi.Models
{
    public class ModelFactory
    {
        IMitchellClaimRepository _repo;
        UrlHelper _urlHelper;

        public ModelFactory(HttpRequestMessage request, IMitchellClaimRepository repo)
        {
            _urlHelper = new UrlHelper(request);
            _repo = repo;
        }

        #region LossInfoModel Factory

        public LossInfoModel Create(LossInfoType lossInfo)
        {
            if (lossInfo == null) return null;
            return new LossInfoModel()
            {
                CauseOfLoss = lossInfo.CauseOfLoss.ToString(),
                LossDescription = lossInfo.LossDescription,
                ReportedDate = lossInfo.ReportedDate,
            };
        }

        public LossInfoType Parse(LossInfoModel lossInfoModel)
        {
            if (lossInfoModel == null) return null;
            return new LossInfoType()
            {
                CauseOfLoss = (CauseOfLossCode)Enum.Parse(typeof(CauseOfLossCode), lossInfoModel.CauseOfLoss),
                LossDescription = lossInfoModel.LossDescription,
                ReportedDate = lossInfoModel.ReportedDate
            };
        }

        #endregion

        #region VehicleModel Factory

        public VehicleModel Create(VehicleInfoType vehicleInfo)
        {
            if (vehicleInfo == null) return null;

            return new VehicleModel()
            {
                DamageDescription = vehicleInfo.DamageDescription,
                EngineDescription = vehicleInfo.EngineDescription,
                ExteriorColor = vehicleInfo.ExteriorColor,
                LicPlate = vehicleInfo.LicPlate,
                LicPlateExpDate = vehicleInfo.LicPlateExpDate,
                LicPlateState = vehicleInfo.LicPlateState,
                MakeDescription = vehicleInfo.MakeDescription,
                Mileage = vehicleInfo.Mileage,
                ModelDescription = vehicleInfo.ModelDescription,
                ModelYear = vehicleInfo.ModelYear,
                Vin = vehicleInfo.Vin
            };
        }

        public VehicleInfoType Parse(VehicleModel vehicleModel)
        {
            if (vehicleModel == null) return null;
            return new VehicleInfoType()
            {
                DamageDescription = vehicleModel.DamageDescription,
                EngineDescription = vehicleModel.EngineDescription,
                ExteriorColor = vehicleModel.ExteriorColor,
                LicPlate = vehicleModel.LicPlate,
                LicPlateExpDate = vehicleModel.LicPlateExpDate,
                MakeDescription = vehicleModel.MakeDescription,
                ModelDescription = vehicleModel.ModelDescription,
                ModelYear = vehicleModel.ModelYear,
                Vin = vehicleModel.Vin
            };

        }

        public List<VehicleInfoType> Parse(IEnumerable<VehicleModel> vehicles)
        {
            if (vehicles == null) return null;
            var res = new List<VehicleInfoType>();
            foreach (var item in vehicles)
            {
                res.Add(Parse(item));
            }
            return res;
        }

        #endregion

        #region ClaimModel Factory

        public MitchellClaim Create(MitchellClaimType mitchellClaimType)
        {
            if (mitchellClaimType == null) return null;

            return new MitchellClaim()
            {
                AssignedAdjusterID = mitchellClaimType.AssignedAdjusterID,
                ClaimantFirstName = mitchellClaimType.ClaimantFirstName,
                ClaimantLastName = mitchellClaimType.ClaimantLastName,
                ClaimNumber = mitchellClaimType.ClaimNumber,
                LossDate = mitchellClaimType.LossDate,
                LossInfo = Create(mitchellClaimType.LossInfo),
                Status = mitchellClaimType.Status.ToString(),
                Vehicles = mitchellClaimType.Vehicles.Select(m => Create(m)).ToArray()
            };
        }

        public IEnumerable<MitchellClaim> Create(IEnumerable<MitchellClaimType> mitchellClaimTypes)
        {
            if (mitchellClaimTypes == null) return null;

            List<MitchellClaim> res = new List<MitchellClaim>();
            if (mitchellClaimTypes == null) return null;
            foreach (var item in mitchellClaimTypes)
            {
                res.Add(Create(item));
            }

            return res;
        }

        public MitchellClaimType Parse(MitchellClaim model)
        {
            try
            {
                if (model == null) return null;

                var entity = new MitchellClaimType()
                {
                    AssignedAdjusterID = model.AssignedAdjusterID,
                    ClaimantFirstName = model.ClaimantFirstName,
                    ClaimantLastName = model.ClaimantLastName,
                    ClaimNumber = model.ClaimNumber,
                    LossDate = model.LossDate,
                    LossInfo = Parse(model.LossInfo), 
                    Vehicles = Parse(model.Vehicles),                   
                    Status = (StatusCode)Enum.Parse(typeof(StatusCode), model.Status)
                };                
                return entity;
            }
            catch
            {
                return null;
            }
        }
       
        #endregion

    }
}