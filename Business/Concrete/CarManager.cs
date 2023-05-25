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
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if(car.Id==6 && car.DailyPrice>0)
            { 
                _carDal.Add(car);
                Console.WriteLine("eklendi");
            }
            else 
            { 
                Console.WriteLine("eklenemedi");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public List<Car> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return _carDal.GetAll();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return _carDal.Get(filter);
        }

    }
}
