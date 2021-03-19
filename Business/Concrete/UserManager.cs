using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
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

        //[CacheAspect]
        //public IDataResult<List<User>> GetAll()
        //{
        //    return new SuccessDataResult<List<User>>(_userDal.GetAll());
        //}

        //[CacheAspect]
        //public IDataResult<User> GetById(int Id)
        //{
        //    return new SuccessDataResult<User>(_userDal.Get(p => p.Id == Id));
        //}

        //[CacheRemoveAspect("IUserService.Get")]
        //[ValidationAspect(typeof(UserValidator))]
        //public IResult Add(User user)
        //{
        //    _userDal.Add(user);
        //    return new SuccessResult(Messages.UserAdded + user.FirstName + " " + user.LastName + "\n");
        //}

        //[CacheRemoveAspect("IUserService.Get")]
        //[ValidationAspect(typeof(UserValidator))]
        //public IResult Update(User user)
        //{
        //    _userDal.Update(user);
        //    return new SuccessResult(Messages.UserUpdated);
        //}

        //[CacheRemoveAspect("IUserService.Get")]
        //[ValidationAspect(typeof(UserValidator))]
        //public IResult Delete(User user)
        //{
        //    _userDal.Delete(user);
        //    return new SuccessResult(Messages.UserDeleted);
        //}

        [CacheAspect]
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        //[CacheRemoveAspect("IUserService.Get")]
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        [CacheAspect]
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}