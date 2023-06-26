using Core.Utilities.Results;
using Core.Utilities.Results.DataResults;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile fromFile, int Id);
        IResult Delete(CarImage carImage);
        IResult UpdateImages(IFormFile fromFile, int Id);
        IDataResult<CarImage> Get(int id);
        IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null);

    }
}
