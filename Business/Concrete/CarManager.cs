using Business.Abstract;
using Business.Constans;
using Core.Business;
using Core.Utilities.Results;
using Core.Utilities.Results.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            IResult result = CarRules.Run(ModelYearCheckTheCar(car.ModelYear));
            if (!result.Success)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messagess.CarAdded, true);
        }

        public IDataResult<List<CarDetailsDto>> carDetailsDto()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.carDetailsDtos(), true);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messagess.CarDeleted, true);
        }

        public IDataResult<Car> Get(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == carId), true);

        }

        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), true);

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId), true);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId), true);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messagess.CarUpdated, true);
        }

        private IResult ModelYearCheckTheCar(int modelYear)
        {
            if (modelYear > 1950 && modelYear < 2024)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messagess.ModelYearCheckTheCar, false);
        }

    }
}
