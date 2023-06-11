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
    public class EfRentalDal: EfEntityRepositoryBase<Rental, CarRentalSystemDBContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentalSystemDBContext context = new CarRentalSystemDBContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join customer in context.Customers
                             on rental.CustomerId equals customer.Id
                             join user in context.Users
                             on customer.UserId equals user.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.BrandId equals color.Id
                             select new RentalDetailDto
                             {
                                 CarId = rental.CarId,
                                 ModelYear = car.ModelYear,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 CustomerFirstName = user.FirstName,
                                 CustomerLastName = user.LastName,
                                 CarRentDate = rental.RentDate,
                                 CarReturnDate = rental.ReturnDate,
                             };
                return result.ToList();
            }
        }
    }
}
