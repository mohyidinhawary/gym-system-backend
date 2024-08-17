using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace GymSystemAPI.Services.QRCode
{
    public interface IQRCodeService
    {
        
        FileContentResult CreateQRCode();
    }
}
