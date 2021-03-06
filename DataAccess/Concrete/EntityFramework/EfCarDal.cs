using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentacarDbContexts>, ICarDal
    {
      
   

     public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentacarDbContexts context = new RentacarDbContexts())
            {
                var result = from c in filter==null? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                            on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join i in context.CarImages
                             on c.BrandId equals i.CarId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId=b.BrandId,
                                 BrandName = b.BrandName,
                                 ModelYear=c.ModelYear,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description=c.Description,
                                 ImagePath=i.ImagePath,
                                 Status=!context.Rentals.Any(p=>p.ReturnDate==null)
                                 

                             };

                return result.ToList();
            }



        }

       
        
    }
}
