using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Concrete;
using Crm.UpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
    [Area("Employee")]
    public class MessageController : Controller
    {
       private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;
        public MessageController(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message m)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            m.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            m.SenderName = user.Name + " " + user.Surname;
            m.SenderEmail = user.Email;
            using (var context = new Context())
            {
                m.ReceiverName = context.Users.Where(x => x.Email == m.ReceiverEmail).Select(x => x.Name + " " + x.Surname).FirstOrDefault();
            }
            _messageService.TInsert(m);
            return View("SendMessage");
        }

        MimeMessage mimeMessage = new MimeMessage();

        MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "tubatastan24@gmail.com");
        //mimeMessage.From.Add(mailboxAddressFrom);

        //    MailboxAddress mailboxAddressTo = new MailboxAddress("User", p.ReceiverEmail);
        //mimeMessage.To.Add(mailboxAddressTo);

        //    var bodyBuilder = new BodyBuilder();
        //bodyBuilder.TextBody = p.EmailContent;
        //    mimeMessage.Body = bodyBuilder.ToMessageBody();

        //    MimeMessage.Subject = p.EmailSubject;

        //    SmtpClient client = new SmtpClient();
        //client.Connect("smtp.gmail.com", 587, false);
        //    client.Authenticate("tubatastan24@gmail.com", "ccvxrhibagsunsmm");
        //    client.Send(mimeMessage);
        //    client.Disconnect(true);
    }
}
