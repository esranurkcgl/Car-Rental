using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IDataResult<Customer> GetbyId(int customerId);
        IDataResult<List<Customer>> GetAll();
        IResult Delete(Customer customer);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
    }
}
