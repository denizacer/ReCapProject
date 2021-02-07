﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDemoContext>, ICarDal
    {

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDemoContext context=new ReCapDemoContext())
            {
                var result = from ca in context.Cars
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 Description = ca.Description,
                                 BrandName=b.BrandName,
                                 ColorName=co.ColorName,
                                 DailyPrice=ca.DailyPrice

    };
                return result.ToList();
            }
        }
    }
}
