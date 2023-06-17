using Business.Abstract;
using Business.Constans;
using Core.Utilities;
using Core.Utilities.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messagess.CarAdded,true);
        }

        public IDataResult<List<CarDetailsDto>> carDetailsDto()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.carDetailsDtos(),true);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messagess.CarDeleted,true);
        }

        public IDataResult<Car> Get(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == carId), true);

        }

        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),true);

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId),true);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.ColorId==colorId),true);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messagess.CarUpdated,true);
        }
    }
}
