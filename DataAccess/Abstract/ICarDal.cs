﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        //GetById, GetAll, 
        // IEntityRepository<Car> den miras aldı


    }
}
