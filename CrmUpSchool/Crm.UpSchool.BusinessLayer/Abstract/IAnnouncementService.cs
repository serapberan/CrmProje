using Crm.UpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.BusinessLayer.Abstract
{
   public interface IAnnouncementService : IGenericService<Announcement>
    {
        public List<Announcement> TContainA();
    }
}
