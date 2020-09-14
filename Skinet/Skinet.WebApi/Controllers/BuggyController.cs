using System;

using Microsoft.AspNetCore.Mvc;

using Skinet.Storage.SQLite.EF.Context;
using Skinet.Storage.SQLite.EF.Entities;
using Skinet.WebApi.Errors;

namespace Skinet.WebApi.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StorageContext _context;

        public BuggyController(StorageContext context, IApiStatusMessageDictionary statusMessageDictionary)
            : base(statusMessageDictionary)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult<ProductDto> GetNotFoundRequest()
        {
            var thing = _context.Products.Find(42);

            if (thing == null)
            {
                return NotFound(new ApiResponse(ApiStatusCode.NotFound, _statusMessageDictionary));
            }

            return Ok(thing);
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(ApiStatusCode.BadRequest, _statusMessageDictionary));
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult<ProductDto> GetServerError()
        {
            var thing = _context.Products.Find(42);
            var thingToReturn = thing.ToString();
            return Ok(thingToReturn);
        }

        [HttpGet("maths/{i}")]
        public ActionResult<int> GetMathsError(int i)
        {
            int j = 10 / i;
            return Ok(j);
        }
    }
}
