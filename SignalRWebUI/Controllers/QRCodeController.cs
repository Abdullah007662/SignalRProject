using Microsoft.AspNetCore.Mvc;
using QRCoder; // Bu satır ÖNEMLİ!
using System.Drawing;
using System.Drawing.Imaging;

namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                ViewBag.Error = "Lütfen bir metin girin.";
                return View();
            }

            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeImage = qrCode.GetGraphic(20);

            ViewBag.QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(qrCodeImage);

            return View();
        }

    }
}
