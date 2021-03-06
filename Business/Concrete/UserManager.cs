using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
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

        //public IDataResult<List<User>> GetAll()
        //{
        //    return new SuccessDataResult<List<User>>(_userDal.GetAll());
        //}

        //public IDataResult<User> GetById(int Id)
        //{
        //    return new SuccessDataResult<User>(_userDal.Get(p => p.Id == Id));
        //}

        //[ValidationAspect(typeof(UserValidator))]
        //public IResult Add(User user)
        //{
        //    _userDal.Add(user);
        //    return new SuccessResult(Messages.UserAdded + user.FirstName + " " + user.LastName + "\n");
        //}

        //[ValidationAspect(typeof(UserValidator))]
        //public IResult Update(User user)
        //{
        //    _userDal.Update(user);
        //    return new SuccessResult(Messages.UserUpdated);
        //}

        //[ValidationAspect(typeof(UserValidator))]
        //public IResult Delete(User user)
        //{
        //    _userDal.Update(user);
        //    return new SuccessResult(Messages.UserDeleted);
        //}

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}