using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Areas.Employee.Modes
{
    public class MailRequet
    {
        public string SenderName { get; set; } //Gönderici
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; } //alıcı
        public string EmailSubject { get; set; }
        public string  EmailContet { get; set; }
    }
}
