using MitchellClaimDomain.DataModel;
using MitchellClaimWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MitchellClaimWebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        IMitchellClaimRepository _repo;
        ModelFactory _modelFactory;

        public BaseApiController(IMitchellClaimRepository repo)
        {
            _repo = repo;
        }

        protected IMitchellClaimRepository ClaimRepository
        {
            get
            {
                return _repo;
            }
        }

        protected ModelFactory MitchellModelFactory
        {
            get
            {
                if (_modelFactory==null)
                {
                    _modelFactory = new ModelFactory(this.Request, ClaimRepository);
                }
                return _modelFactory;
            }
        }

    }
}
