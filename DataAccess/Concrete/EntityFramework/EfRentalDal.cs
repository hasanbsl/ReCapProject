using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentacarDbContexts>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
           using(RentacarDbContexts context=new RentacarDbContexts())
            {
                var result = from r in filter== null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars on r.CarId equals c.CarId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             join cu in context.Customers on r.CustomerId equals cu.CustomerId
                             join u in context.Users on cu.UserId equals u.UserId
                           
                           
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarId=c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName=co.ColorName,
                                 CompanyName = cu.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate =(DateTime)r.ReturnDate,
                                 DailyPrice=c.DailyPrice,
                                 DateNow=DateTime.Now
                                 

                             };
                return result.ToList();
            }
          
        }
    }
}
