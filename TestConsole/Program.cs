using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrandAdd();

            //ColorAdd();

            // CarManager carManager = CarAdd();

            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            

           
        }

        //private static CarManager CarAdd()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice = 800, ModelYear = 2012, Description = "Dizel,Düz vites" });
        //    carManager.Add(new Car { BrandId = 2, ColorId = 2, DailyPrice = 500, ModelYear = 2015, Description = "Dizel , Otomatik" });
        //    carManager.Add(new Car { BrandId = 2, ColorId = 2, DailyPrice = 600, ModelYear = 2017, Description = "Benzinli,Düz vites" });
        //    return carManager;

          //  Console.WriteLine("Brand Id'si 1 olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            //foreach (var car in carManager.GetCarsByBrandId(1).Data)
           // {
           //     Console.WriteLine($"{car.CarId}\t\t\t\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
           // }

            ////  foreach (var car in carManager.GetAll())
            //  {
            //      Console.WriteLine("{0}  {1}   ",car.CarId,car.Description);
            //  }
        }

        //private static void ColorAdd()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    colorManager.Add(new Color { ColorName = "Sarı" });
        //    colorManager.Add(new Color { ColorName = "kırmızı" });
        //    colorManager.Add(new Color { ColorName = "yeşil" });
        //}

        //private static void BrandAdd()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    brandManager.Add(new Brand { BrandName = "Toyota" });
        //    brandManager.Add(new Brand { BrandName = "Subaru" });
        //    brandManager.Add(new Brand { BrandName = "Fort" });
        //}
    
}
