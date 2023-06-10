using Core.DataAccess;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
      /*  public void AddDto(Rental rental)
        {
            using (RentACarContext context =new RentACarContext)
            {
                from g in context.Users 
                join u in context.Rentals
                on  g.Id equals u.
                
                }
        }*/
    }
}
