using Business.Concrete;

using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            Crud();

        }

        private static void Crud()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //GetAll, GetById, Insert, Update, Delete.
            Car newCar = new Car
            {
                CarId = 7,
                BrandId = 1,
                ColorId = 2,
                ModelYear = 2019,
                DailyPrice = 5000,
                Description = "Arac7"
            };
            carManager.Add(newCar);

            Car update = new Car
            {
                CarId = 7,
                BrandId = 2,
                ColorId = 3,
                ModelYear = 2017,
                DailyPrice = 8000,
                Description = "Arac7"
            };
            carManager.Update(update);
            Car delete = new Car
            {
                CarId = 7,
                BrandId = 2,
                ColorId = 3,
                ModelYear = 2017,
                DailyPrice = 8000,
                Description = "Arac7"
            };
            carManager.Update(delete);
            System.Console.WriteLine(delete);
        }

        private static void CarTest()
        {
            System.Console.WriteLine("CarId" + " " + "BrandId" + " " + "ColorId" + " " + "ModelYear" + " " + "DailyPrice" + " " + "Description");
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                System.Console.WriteLine(car.CarId + "       " + car.BrandId + "        " + car.ColorId + "     " + car.ModelYear + "      " + car.DailyPrice + "       " + car.Description);
              
            }
        }
    }
}
