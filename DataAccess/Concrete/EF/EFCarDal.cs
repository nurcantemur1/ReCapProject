using Core.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class EFCarDal : EFRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailsDto> carDetailsDtos() //CarName, BrandName, ColorName, DailyPrice
        {
            using (RentACarContext context=new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join f in context.Colors
                             on c.ColorId equals f.Id
                             select new CarDetailsDto {CarId=c.Id, BrandName=b.Name,ColorName=f.Name,DailyPrice=c.DailyPrice};
                return result.ToList();
            }
        }
    }
}

