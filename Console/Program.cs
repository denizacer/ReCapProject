using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using Entities.Concrete;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("CarId" + " " + "BrandId" + " "+"ColorId" + " "+ "ModelYear" + " "+ "DailyPrice" + " "+ "Description");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                System.Console.WriteLine(car.CarId +"       "+ car.BrandId+ "        " + car.ColorId + "     " +car.ModelYear + "      " +car.DailyPrice + "       " +car.Description);

            }
        }
    }
}
