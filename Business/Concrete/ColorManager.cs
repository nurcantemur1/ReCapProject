using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using Core.Utilities.Results.DataResults;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {

            _colorDal.Add(color);
            return new SuccessResult(Messagess.ColorAdded, true);
        }

        public IResult Delete(Color color)
        {

            _colorDal.Delete(color);
            return new SuccessResult(Messagess.ColorDeleted, true);
        }

        public IDataResult<Color> Get(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(p=>p.Id==colorId));
        }

        public IDataResult<List<Color>> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(filter));

        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messagess.ColorUpdated,true);
        }
    }
}
