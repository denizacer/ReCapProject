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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal )
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccesResult((Messages.UserAdded));
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);

            return new SuccesResult((Messages.UserDeleted));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccesResult((Messages.UserUptaded));
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);//bakım zamanı

                //ampülden generatefielt
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == customerId));
        }

       
    }
}
