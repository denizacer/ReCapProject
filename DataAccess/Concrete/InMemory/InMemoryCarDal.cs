using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Concrete.InMemory
{
     
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        List<Color> _color;
        public InMemoryCarDal()
        {
            _color = new List<Color>
            {
                new Color{ ColorId = 1, ColorName = "Beyaz" } ,
                new Color{ ColorId = 2, ColorName = "Gümüş" } ,
                new Color{ ColorId = 3, ColorName = "Siyah" } ,
            };
            _brands = new List<Brand> 
            { new Brand { BrandId = 1, BrandName = "Mercedes" } ,
              new Brand { BrandId = 2, BrandName = "Skoda" } ,
              new Brand { BrandId = 3, BrandName = "Audi" } ,
            };

            _cars = new List<Car>
            { 
                //Id, BrandId, ColorId, ModelYear, DailyPrice, Description
                new Car{CarId=1,BrandId=1,ColorId=1,ModelYear=2021,DailyPrice=20000,Description="Arac1" },
                new Car{CarId=2,BrandId=2,ColorId=1,ModelYear=2020,DailyPrice=16000,Description="Arac2" },
                new Car{CarId=3,BrandId=3,ColorId=1,ModelYear=2019,DailyPrice=12000,Description="Arac3" },
                new Car{CarId=4,BrandId=1,ColorId=1,ModelYear=2018,DailyPrice=18000,Description="Arac4" },
                new Car{CarId=5,BrandId=2,ColorId=1,ModelYear=2017,DailyPrice=14000,Description="Arac5" },
                new Car{CarId=6,BrandId=3,ColorId=1,ModelYear=2016,DailyPrice=10000,Description="Arac6" }

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

       /* List<Car> ICarDal.GetByIdy(int CarId)
        {
            return _cars.Where(c => c.CarId == CarId).ToList();
        }*/

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId); ;
        }

        public List<Car> GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        Car IEntityRepository<Car>.Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
