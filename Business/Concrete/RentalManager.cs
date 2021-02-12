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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.RentDate != null)
            {
                _rentalDal.Add(rental);
                return new SuccesResult((Messages.RentCar));
            }

            return new ErrorResult(Messages.CarNameInvalid);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);

            return new SuccesResult((Messages.RentDeleted));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);//bakım zamanı

                //ampülden generatefielt
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentListed);

        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            //return new SuccessDataResult<Car>(_carDal.Get(c=>c.CarId==carId));
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentalId==rentalId));
        }

        public IResult Update(Rental rental)
        {
            
            _rentalDal.Update(rental);
            return new SuccesResult((Messages.RentUptaded));
        }
    }

   
    }
