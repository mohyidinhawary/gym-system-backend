using System.Drawing;
using System.Drawing.Imaging;

namespace GymSystemAPI.Services
{
    public class ImageConvertor
    {
        public byte[] ImageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}
