using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IColorService _colorService;
        IBrandService _brandService;

        public CarManager(ICarDal carDal, IColorService colorService, IBrandService brandService)
        {
            _carDal = carDal;
            _colorService = colorService;
            _brandService = brandService;
        }

      


        [SecuredOperation("car.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        [LogAspect(typeof(FileLogger))]
        public IResult Add(Car car)
        {
            

            _carDal.Add(car);

            return new SuccesResult((Messages.CarAdded));
            
            
        }


        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccesResult((Messages.CarDeleted));
        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccesResult((Messages.CarUptaded));
        }


        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);//bakım zamanı

            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
            
        }


        [CacheAspect]
        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
            
        }


        [CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<Car> GetById(int carId)
        {
          
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.CarId==carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()

        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
        //[TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
            //Add(product);
            //if (product.UnitPrice < 10)
            //{
            //    throw new Exception("");
            //}

            //Add(product);

            //return null;
        }
        private IResult CheckIfCarExists(int id)
        {
            var result = _carDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            //return new SuccessResult((Messages.control));
            return new SuccesResult((Messages.control));
        }

        private IResult CheckIfBrandExists(int brandId)
        {    
            var result = _brandService.GetById(brandId);
            if (result.Data == null)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            return new SuccesResult((Messages.control));
        }

        private IResult CheckIfColorExists(int colorId)
        {
            var result = _colorService.GetById(colorId);
            if (result.Data == null)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            return new SuccesResult((Messages.control));
        }
    }
}
