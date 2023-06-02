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
            using (RentACarContext context=new RentACarContext())
            {
                context.Set<Car>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                context.Set<Car>().Remove(context.Set<Car>().SingleOrDefault(p=>p.Id==entity.Id));
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext context=new RentACarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
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
            using (RentACarContext context = new RentACarContext())
            {
                var up = context.Set<Car>().SingleOrDefault(p=>p.Id==entity.Id);
                up.DailyPrice=entity.DailyPrice;
                up.ModelYear=entity.ModelYear;
                up.ColorId=entity.ColorId;
                up.BrandId=entity.BrandId;
                context.SaveChanges();
            }
        }
    
    }
}

