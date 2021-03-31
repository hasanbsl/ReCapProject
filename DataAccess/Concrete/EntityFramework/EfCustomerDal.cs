using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentacarDbContexts>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (var context = new RentacarDbContexts())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.UserId
                             select new CustomerDetailDto
                             {
                                 Id = c.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 Status = u.Status,
                                 CompanyName = c.CompanyName
                             };

                return result.ToList();
            }
        }
    }
}
