using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class EFColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                context.Set<Color>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                context.Set<Color>().Remove(context.Set<Color>().SingleOrDefault(p => p.Id == entity.Id));
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (RentACarContext context =new RentACarContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (RentACarContext context=new RentACarContext())
            {
                return filter == null
                    ? context.Set<Color>().ToList()
                    : context.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var up = context.Set<Color>().SingleOrDefault(p => p.Id == entity.Id);
                up.Name=entity.Name;
                context.SaveChanges();
            }
        }
    }
}
