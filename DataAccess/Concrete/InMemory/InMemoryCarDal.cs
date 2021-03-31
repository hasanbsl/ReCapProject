using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal :ICarDal
    {
        //Brand marka ismi ve aydiside eklenecek

        List<Car> _cars;

        //public InMemoryCarDal()
        //{
        //    _cars = new List<Car>()
        //    {
        //        new Car{CarId=1,BrandId=1,ColorId=1,ModelYear=1994,DailyPrice=100,Description="Çok Yakar Az Kaçar"},
        //        new Car{CarId=2,BrandId=1,ColorId=2,ModelYear=2000,DailyPrice=120,Description="Orta Yakar"},
        //        new Car{CarId=3,BrandId=2,ColorId=1,ModelYear=2015,DailyPrice=200,Description="Orta Yakar"},
        //        new Car{CarId=4,BrandId=2,ColorId=2,ModelYear=2020,DailyPrice=300,Description="Az Yakar Çok Kaçar"},
        //        new Car{CarId=5,BrandId=1,ColorId=3,ModelYear=2021,DailyPrice=350,Description="Az Yakar Çok Kaçar"},
        //    };
        //}

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByld(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
