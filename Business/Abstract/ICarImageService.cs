﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();

        IDataResult<List<CarImage>> GetAllByCarId(int carId);



        IResult Add(CarImage carImage);

        IResult Delete(CarImage carImage);

        IResult Update(CarImage carImage);

    }
}
