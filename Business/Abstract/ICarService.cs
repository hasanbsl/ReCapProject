using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);

        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);

        IDataResult<Car> GetById(int carId);

        IResult Add(Car car);

        IResult Delete(Car car);

        IResult Update(Car car);

        IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null);

        IResult AddTranssactionnalTest(Car car);

        IDataResult<List<CarDetailDto>> GetCarsByCarId(int carId);

        IDataResult<List<CarDetailDto>> GetCarsDetailByBrandIdAndColorId(int brandId, int colorId);





    }
}
