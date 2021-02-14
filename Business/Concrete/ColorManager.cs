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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            
            _colorDal.Add(color);

            return new SuccesResult((Messages.CarAdded));
            // Console.WriteLine("Araba Eklenemedi. Kontrol ediniz.");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);

            return new SuccesResult((Messages.CarDeleted));
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);//bakım zamanı

                //ampülden generatefielt
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccesResult((Messages.CarUptaded));
        }
    }
}
