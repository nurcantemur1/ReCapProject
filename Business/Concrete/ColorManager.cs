using Business.Abstract;
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

        public void Add(Color color)
        {
            throw new NotImplementedException();
        }

        public void Delete(Color color)
        {
            throw new NotImplementedException();
        }


        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return _colorDal.GetAll(filter);
        }

        public void Update(Color color)
        {
            throw new NotImplementedException();
        }
    }
}
