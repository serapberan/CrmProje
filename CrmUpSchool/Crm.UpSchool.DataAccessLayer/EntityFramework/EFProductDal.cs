using Crm.UpSchool.DataAccessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Repository;
using Crm.UpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.DataAccessLayer.EntityFramework
{
    public class EFProductDal : GenericRepository<Product>, IProductDal
    {
        // sadece ilgili entity özgü metot tanımlamak istediğimizde bu EF sınıflarını kullanacağız 
        public void GetProductByCategory()
        {
            throw new NotImplementedException();
        }
    }
}
