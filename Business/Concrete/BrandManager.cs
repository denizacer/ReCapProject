using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);

            return new SuccesResult((Messages.CarAdded));
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Add(brand);

            return new SuccesResult((Messages.CarDeleted));
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);//bakım zamanı

                //ampülden generatefielt
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId ==brandId));
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Add(brand);

            return new SuccesResult((Messages.CarUptaded));
        }
    }
}
