using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class EFCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext context=new RentACarContext())
            {
                return context.Set<Car>().Find(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
        public List<Car> GetCarsByBrandId(int brandId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Car>().Where(p => p.BrandId == brandId).ToList();
            }
        }
        public List<Car> GetCarsByColorId(int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Car>().Where(p => p.ColorId == colorId).ToList();
            }
        }
    }
}

