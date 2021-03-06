using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;
        IFindeksService _findeksService;

        public RentalManager(IRentalDal rentalDal,ICarService carService,IFindeksService findeksService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _findeksService = findeksService;

        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(AddControl(rental.CarId, rental.RentDate),IfCheckFindeksScore(rental));
            if(result !=null)
            {
                return result;
            }
            _rentalDal.Add(rental);

            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalGetall);
        }

        public IDataResult<List<RentalDetailDto>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(p=>p.CarId==carId));
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.RentalId == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private IResult AddControl(int carId,DateTime rentDate  )
        {
            var result = _rentalDal.GetAll(p => p.CarId == carId && p.ReturnDate > rentDate).Any();
            if(result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
            
        }

        private IResult IfCheckFindeksScore(Rental rental)
        {
            var car = _carService.GetById(rental.CarId);
            var findeks = _findeksService.GetFindeksScore(rental.CustomerId);

            if (car.Success && findeks.Success)
            {
                if (car.Data.FindeksScore < findeks.Data)
                {
                    return new SuccessResult(Messages.FindeksPointsSufficient);
                }
                return new ErrorResult(Messages.FindeksPointsInsufficient);
            }
            return new ErrorResult(Messages.GetErrorRentalMessage);
        }

    }
}
