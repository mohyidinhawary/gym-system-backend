using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;

namespace GymSystemAPI.Services.QRCode
{
    public class QrCode : IQRCodeService
    {
       

        private byte[] ImageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public FileContentResult CreateQRCode()
        {
            string dateTimeNow = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string dataToEncode = $" Scanned at: {dateTimeNow}";

            QRCodeGenerator QRCodeGenerator = new QRCodeGenerator();
            QRCodeData QRCodeData = QRCodeGenerator.CreateQrCode(dataToEncode, QRCodeGenerator.ECCLevel.Q);
            QRCoder.QRCode QR = new QRCoder.QRCode(QRCodeData);
            Image QRCodeImage = QR.GetGraphic(20);


            var bytes = ImageToByteArray(QRCodeImage);
            return new FileContentResult(bytes, "image/png");
        }
    }
    }

