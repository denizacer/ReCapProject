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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccesResult((Messages.UserAdded));
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);

            return new SuccesResult((Messages.UserDeleted));
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);//bakım zamanı

                //ampülden generatefielt
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
        }

        public IResult Update(User user)
        {
            //  
            _userDal.Update(user);
            return new SuccesResult((Messages.UserUptaded));
        }
    }
}
