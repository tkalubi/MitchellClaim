using MitchellClaimDomain.DataModel;
using MitchellClaimWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MitchellClaimWebApi.Controllers
{
    [RoutePrefix("api/vehicle")]
    public class VehicleController : BaseApiController
    {
        public VehicleController(IMitchellClaimRepository repo)
            : base(repo)
        {

        }
             
         [Route("{claimnumber:regex(^[a-zA-Z0-9_]*$)}/{vin:regex(^[a-zA-Z0-9_]*$)}")]
        public HttpResponseMessage GetVehicleForClaim(string claimnumber, string vin)
        {
            var vit = ClaimRepository.GetMitchellClaimVehicle(claimnumber, vin);
            
            VehicleModel v = MitchellModelFactory.Create(vit);

            if (v == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, v);
            }
        }
       
    }
}
