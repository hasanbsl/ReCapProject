using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Business;
using Business.Constants;
using System.Linq;

namespace Business.Concrete
{
   public class CarImageManager : ICarImageService
    {
      ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>> (_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
           
            
                var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
                if (!result)
                {
                    List<CarImage> carimage = new List<CarImage>();
                    carimage.Add(new CarImage { CarId = carId, ImagePath = @"\Images\default.jpg" });
                    return new SuccessDataResult<List<CarImage>>(carimage);
                }
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId));
            


        }

        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));
            if (!result.Success)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);

        }

        public IResult Delete(CarImage carImage)
        {
            
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IResult Update(CarImage carImage)
        {
            
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result >5)
            {
                return new ErrorResult(Messages.FailedCarImageLimit);
            }

            return new SuccessResult();
        }

        


    }
}
