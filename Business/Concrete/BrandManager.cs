using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _branddal;

        public BrandManager(IBrandDal branddal)
        {
            _branddal = branddal;
        }

        public void Add(Brand brand)
        {
            throw new NotImplementedException();
        }

        public void Delete(Brand brand)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            return _branddal.GetAll();
        }

        public void Update(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
