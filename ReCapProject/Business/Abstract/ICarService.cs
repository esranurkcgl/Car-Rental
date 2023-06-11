using Core;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<Car> Get(int carId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult AddTransactionalTest(Car car);

    }
}
