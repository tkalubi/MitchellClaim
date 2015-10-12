using MitchellClaimDomain.Classes.Entities;
using MitchellClaimDomain.DataModel;
using MitchellClaimWebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Xml.Serialization;

namespace MitchellClaimWebApi.Controllers
{
    [RoutePrefix("api/claim")]
    public class ClaimController : BaseApiController
    {

        public ClaimController(IMitchellClaimRepository repo)
            : base(repo)
        {

        }

        [Route("")]
        public object Get()
        {
            return MitchellModelFactory.Create(new MitchellClaimType());
        }
        [Route("{claimnumber:regex(^[a-zA-Z0-9_]*$)}")]
        public HttpResponseMessage GetByClaimnumber(string claimnumber)
        {
            MitchellClaim cm = MitchellModelFactory.Create(ClaimRepository.GetMitchellClaimByClaimNumber(claimnumber));
           
            if (cm == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, cm);
            }
        }

        [Route("{d1:datetime}/{d2:datetime}")]
        public HttpResponseMessage GetClaimsByLossDateRange(DateTime d1, DateTime d2)
        {
            IEnumerable<MitchellClaim> cm = MitchellModelFactory.Create(ClaimRepository.GetMitchellClaimsByLossDateRange(d1,d2));

            if (cm == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, cm);
            }
        }

        // POST api/values
        [Route("")]
        public HttpResponseMessage Post([FromBody] MitchellClaim model)
        {
            try
            {
                var entity = MitchellModelFactory.Parse(model);
              
                if (entity == null) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read Claim entry in body");

                var claim = ClaimRepository.GetMitchellClaimByClaimNumber(entity.ClaimNumber);

                if (claim != null) return Request.CreateErrorResponse(HttpStatusCode.Conflict,string.Format("The claim number {0} already exist",claim.ClaimNumber));

               
                // Save the new Entry
                if (ClaimRepository.AddMitchellClaim(entity) > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
                }                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        // PUT 
         [Route("")]
        public HttpResponseMessage Put([FromBody] MitchellClaim model)
        {
            try
            {
                var claim = ClaimRepository.GetMitchellClaimByClaimNumber(model.ClaimNumber);

                if (claim == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("The claim number {0} does not exist", claim.ClaimNumber));

                var entity = MitchellModelFactory.Parse(model);

                if (entity == null) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read Claim entry in body");
                
                if (ClaimRepository.UpdateMitchellClaim(entity))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE 
        [Route("{claimnumber:regex(^[a-zA-Z0-9_]*$)}")]
        public HttpResponseMessage Delete(string claimnumber)
        {
            try
            {
                MitchellClaim cm = MitchellModelFactory.Create(ClaimRepository.GetMitchellClaimByClaimNumber(claimnumber));

                if (cm == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    if (ClaimRepository.DeleteMitchellClaim(claimnumber))
                        return Request.CreateResponse(HttpStatusCode.OK, cm);
                    else
                        return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            catch 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }            
        }
    }
}