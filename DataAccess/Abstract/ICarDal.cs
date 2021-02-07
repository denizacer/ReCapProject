using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        //GetById, GetAll, 
        // IEntityRepository<Car> den miras aldı
        List<CarDetailDto> GetCarDetails();

    }
}
