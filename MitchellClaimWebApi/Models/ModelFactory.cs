using MitchellClaimDomain.Classes.Entities;
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

        public ClaimModel Create(MitchellClaimType mitchellClaimType)
        {
            if (mitchellClaimType == null) return null;

            return new ClaimModel()
            {
                AssignedAdjusterID = mitchellClaimType.AssignedAdjusterID,
                ClaimFirstName = mitchellClaimType.ClaimantFirstName,
                ClaimLastName = mitchellClaimType.ClaimantLastName,
                ClaimNumber = mitchellClaimType.ClaimNumber,
                LossDate = mitchellClaimType.LossDate,
                LossInfo = Create(mitchellClaimType.LossInfo),
                Status = mitchellClaimType.Status.ToString(),
                Vehicles = mitchellClaimType.Vehicles.Select(m => Create(m))
            };
        }
    }
}