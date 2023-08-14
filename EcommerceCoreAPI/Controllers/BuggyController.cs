using EcommerceCoreAPI.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCoreAPI.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly AppDbContext _context;
        public BuggyController(AppDbContext appDbContext) { _context = appDbContext; }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(55);
            if(thing == null)
            {
                return NotFound(new ApiResponse(404));

            };
            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GeServerError()
        {
            var thing = _context.Products.Find(55);
            var thingToReturn = thing.ToString();
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GeBaddRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GeBaddRequestById(int id)
        {
            return Ok();
        }
    }
}
