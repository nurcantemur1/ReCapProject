using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class EFBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (RentACarContext context =new RentACarContext())
            {
                context.Set<Brand>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                context.Set<Brand>().Remove(context.Set<Brand>().SingleOrDefault(p=>p.Id==entity.Id));
                context.SaveChanges();
            }
        }


        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (RentACarContext context=new RentACarContext())
            {
                return filter==null
                    ? context.Set<Brand>().ToList()
                    : context.Set<Brand>().Where(filter).ToList();
            }
        }
        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }
        public void Update(Brand entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var up = context.Set<Brand>().SingleOrDefault(p=>p.Id==entity.Id);
                up.Name=entity.Name;
                context.SaveChanges();
            }
        }
    }
}
