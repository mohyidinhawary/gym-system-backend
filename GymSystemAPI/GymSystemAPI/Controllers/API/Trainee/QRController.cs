using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.IO;

using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

using System.Drawing.Imaging;
using Microsoft.EntityFrameworkCore;
using GymSystemAPI.Services;
using GymSystemAPI.Models.Domain;

namespace GymSystemAPI.Controllers.API.Trainee
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public QRController(ApplicationDbContext context) {
            _context = context;
        }
        private byte[] ImageToByteArray(Image image)
        {
            MemoryStream ms=new MemoryStream();
            image.Save(ms,ImageFormat.Jpeg);
            return ms.ToArray();
        }

        [HttpPost("QR")]
        public async    Task< IActionResult> CreateQRCode(int userId)
        {
            string dateTimeNow = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string dataToEncode = $"{dateTimeNow}";

            QRCodeGenerator QRCodeGenerator = new QRCodeGenerator();
                QRCodeData QRCodeData = QRCodeGenerator.CreateQrCode(dataToEncode,  QRCodeGenerator.ECCLevel.Q);
                QRCode QR = new QRCode(QRCodeData);
            Image QRCodeImage = QR.GetGraphic(20);

        

            var bytes=ImageToByteArray(QRCodeImage);
            await SaveQRCodeToDatabase(bytes, userId);
            return File(bytes, "image/bmp");
        
        }

        private async Task SaveQRCodeToDatabase(byte[] imageData, int userId)
        {
            var qrCode = new QR
            {
                UserId = userId,
                QRCodeImage = imageData,
                CreatedAt = DateTime.UtcNow
            };
            _context.QRs.Add(qrCode);
           await _context.SaveChangesAsync();
           
        }
        [HttpGet("GetQR")]

        public IActionResult GetQRCode(int userId)
        {
            var qr = _context.QRs.FirstOrDefault(c => c.UserId == userId );
            if (qr == null)
            {
                return NotFound();
            }
            return Ok(qr);
        }

        







        }
     
    }

