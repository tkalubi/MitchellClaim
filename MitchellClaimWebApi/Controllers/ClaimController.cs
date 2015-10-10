using MitchellClaimDomain.Classes.Entities;
using MitchellClaimDomain.DataModel;
using MitchellClaimWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

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
        [Route("{claimnumber:regex(^[a-zA-Z]+[a-zA-Z0-9,_ -]*$)}")]
        public HttpResponseMessage GetByClaimnumber(string claimnumber)
        {
            ClaimModel cm = MitchellModelFactory.Create(ClaimRepository.GetMitchellClaimByClaimNumber(claimnumber));
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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}