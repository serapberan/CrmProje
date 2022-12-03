using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Concrete;
using Crm.UpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Areas.Employee.Modes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

using System.Security.Cryptography.X509Certificates;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Empolyee")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser>  _userManager;
        Context db = new Context();

        public MessageController(IMessageService messageService, UserManager<AppUser> userManager = null)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

      
        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message m)
        {
          
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            m.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            m.SenderEmail = user.Email;  //Göndericinin maili
            m.SenderName = user.Name + " " + user.Surname;
            //  m.ReceiverName = _userManager.FindByEmailAsync()  bu login olan kişinin bilgileriniverir 

            //bu şart ile alıcının mailinden ad soy adını alıyoruz.
            m.ReceiverName = db.Users.Where(x => x.Email == m.ReceiverEmail).Select(x => x.Name + " " + x.Surname).FirstOrDefault();

            _messageService.TInsert(m);
            return RedirectToAction("SendMessage");
        }

        [HttpGet]
        public async Task<IActionResult> SendEMail()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SendEmail(MailRequet m)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin","srpberan@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User",m.ReceiverEmail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = m.EmailContet;

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = m.EmailSubject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("srpberan@gmail.com", "kumxbkzucgqaqlnf");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();

        }
    }
}
