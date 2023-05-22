using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars=new List<Car> {
            new Car {Id=1,BrandId=1,ColorId=2,DailyPrice=46,ModelYear=1998,Description="a"},
            new Car {Id=2,BrandId=2,ColorId=1,DailyPrice=5,ModelYear=2000,Description="b"},
            new Car {Id=3,BrandId=1,ColorId=2,DailyPrice=11,ModelYear=2009,Description="c"},
                        };
        }

        public void Add(Car car)
        {
             _cars.Add(car);
        }

        public void Delete(Car car)
        {
            _cars.Remove(_cars.SingleOrDefault(p => p.Id == car.Id));
            
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void GetById(int carId)
        {
            _cars.Find(p=>p.Id==carId);
        }

        public void Update(Car car)
        {
            Car up =_cars.SingleOrDefault(p=>p.Id==car.Id);
            up.DailyPrice= car.DailyPrice;
            up.ModelYear= car.ModelYear;
            up.BrandId= car.BrandId;
            up.ColorId= car.ColorId;
            up.Description= car.Description;
        }
    }
}
