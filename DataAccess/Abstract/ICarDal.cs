using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
      /*  void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAll(Expression<Func<Car, bool>> filter = null);
        Car GetById(int carId);

        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);*/
    }
}