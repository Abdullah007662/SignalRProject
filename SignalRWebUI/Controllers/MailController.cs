using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.DTO.MailDTO;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDTO createMailDto)
        {
            var mimeMessage = new MimeMessage();

            mimeMessage.From.Add(new MailboxAddress("SignalR Rezervasyon", "kcdmirapo96@gmail.com"));
            mimeMessage.To.Add(new MailboxAddress("User", createMailDto.ReceiverMail));

            var bodyBuilder = new BodyBuilder
            {
                TextBody = createMailDto.Body
            };

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = createMailDto.Subject;

            using var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("kcdmirapo96@gmail.com", "oauifwpqhjjgrzgn");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("Index", "Mail");
        }
    }
}
