using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Abstract;
using Crm.UpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.BusinessLayer.Concrete
{
    public class SupplierManager : ISupplierService
    {
        private readonly ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        public void TDelete(Supplier t)
        {
            _supplierDal.Delete(t);
        }

        public Supplier TGetByID(int id)
        {
          return  _supplierDal.GetByID(id);
        }

        public List<Supplier> TGetList()
        {
            return _supplierDal.GetList();
        }

        public void TInsert(Supplier t)
        {
            _supplierDal.Insert(t);
        }

        public void TUpdate(Supplier t)
        {
            throw new NotImplementedException();
        }
    }
}
