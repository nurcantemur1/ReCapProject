using Core.DataAccess;
using Core.Entities;
using Core.EntityFramework;
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
    public class EFCarImageDal : EFRepositoryBase<CarImage,RentACarContext>,ICarImageDal
    {
     
    }
}
