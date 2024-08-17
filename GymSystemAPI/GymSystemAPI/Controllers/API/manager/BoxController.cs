using GymSystemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymSystemAPI.Controllers.API.manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BoxController(ApplicationDbContext context) {
            _context = context;
        }
        [HttpGet("box")]
        public IActionResult GetTotalAmount()
        {
            var totalamount = _context.Payments.Sum(p=>p.Amount);
            return Ok(totalamount);
        }
    }
}
