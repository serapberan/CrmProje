using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.EntityLayer.Concrete
{
    public class Announcement   // duyuru kısmı 
    {
        public int ID { get; set; }
        public string  Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

    }
}
