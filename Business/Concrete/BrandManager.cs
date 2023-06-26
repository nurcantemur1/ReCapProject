using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.ValidationAspect;
using Core.Utilities;
using Core.Utilities.Results;
using Core.Utilities.Results.DataResults;
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

        [ValidationAspect (typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _branddal.Add(brand);
            return new SuccessResult(Messagess.BrandAdded,true);
        }

        public IResult Delete(Brand brand)
        {
           _branddal.Delete(brand);
            return new SuccessResult(Messagess.BrandDeleted,true);
            
        }

        public IDataResult<Brand> Get(int id)
        {
            return new SuccessDataResult<Brand>(_branddal.Get(p=>p.Id==id));
        }

        public IDataResult<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return new SuccessDataResult<List<Brand>>(_branddal.GetAll(filter));
        }

        public IResult Update(Brand brand)
        {
            _branddal.Update(brand);
            return new SuccessResult(Messagess.BrandUpdated,true);
        }
    }
}
