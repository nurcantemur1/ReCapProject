using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using Core.Utilities.Results.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        public IResult Add(IFormFile fromFile, int carId)
        {
            var result = _carService.Get(carId).Data;
            if (ImageOperation(fromFile).Success && result != null && ImageCount(carId).Success)
            {
                string newFile = ImageOperation(fromFile).Data;
                CarImage image = new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = newFile };
                _carImageDal.Add(image); 
                return new SuccessResult(Messagess.CarImageAdded, true);
            }
            return new ErrorResult();
        }
        public IResult UpdateImages(IFormFile fromFile, int Id)
        {
            var result = _carImageDal.Get(p => p.Id == Id);
            if (ImageOperation(fromFile).Success)
            {
                string newFile = ImageOperation(fromFile).Data; 
                CarImage image = new CarImage { Id = Id, CarId = result.CarId, Date = DateTime.Now, ImagePath = newFile };
                _carImageDal.Update(image);
                return new SuccessResult(Messagess.CarImageUpdated, true);
            }
            return new ErrorResult();
        }
        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messagess.CarImageDeleted, true);
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(filter));
        }


        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messagess.CarImageUpdated, true);
        }

        private IResult ImageCount(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IDataResult<string> ImageOperation(IFormFile fromFile)
        {
            var expression = Path.GetExtension(fromFile.FileName);
            if (expression == null || !(new[] { "jpg", "jpeg", "png" }.Contains(expression.Trim('.'))))
            {
                return new ErrorDataResult<string>("dosya seçilmedi yada yanlış formatta", false);
            }
            var newFileName = Guid.NewGuid() + expression;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "C:\\Users\\ASUS\\source\\repos\\ReCapProject\\DataAccess\\Concrete\\Images\\", newFileName);
            var stream = new FileStream(path, FileMode.Create);
            fromFile.CopyTo(stream);
            return new SuccessDataResult<string>(newFileName,true);
        }
    }
}
