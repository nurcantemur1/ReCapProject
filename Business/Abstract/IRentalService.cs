using Core.Utilities;
using Core.Utilities.DataResults;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<Rental>> GetAll(Expression<Func<Rental,bool>> filter=null);
        IDataResult<Rental> GetbyId(int id);

        IResult Kirala(Rental rental);
        IResult TeslimEt(Rental rental);

    }
}
