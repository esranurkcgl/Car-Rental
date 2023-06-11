using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal: EfEntityRepositoryBase<Customer, CarRentalSystemDBContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (CarRentalSystemDBContext context = new CarRentalSystemDBContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 Id = c.Id,
                                 UserFirstName = u.FirstName,
                                 UserLastName = u.LastName,
                                 UserEmail = u.Email,
                                 CompanyName = c.CompanyName
                             };
                return result.ToList();

            }
        }
    }
}
