using GymSystemAPI.Models.Domain;
using GymSystemAPI.Models.Dto;
using GymSystemAPI.Services;
using GymSystemAPI.Services.QRCode;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymSystemAPI.Controllers.API.Trainee
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IQRCodeService _qrCodeService;
       public PaymentController(ApplicationDbContext context,IQRCodeService qRCodeService) {
            _context = context;
            _qrCodeService = qRCodeService;
        }
        [Authorize(Roles = "Trainee")]
        [HttpPost("payment")]
        public async Task < IActionResult > MakePayment(int id,PaymentDto paymentDto)
        {
            var p = new Payment
            {
                Amount = paymentDto.Amount,
                CardNumber = paymentDto.CardNumber,
                ExpirationDate = paymentDto.ExpirationDate,
                CVV = paymentDto.CVV,
               UserId=id
            };

            _context.Payments.Add(p);
            await _context.SaveChangesAsync();
           

            return Ok(p);
           


        }

        [HttpGet("{id}")]
        public IActionResult GetUserAccountStatement(int id)
        {
            var user = _context.Payments.Where(c => c.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }
    }
}
