using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
       
        public UserManager(IUserDal userDal)
        {
            _userDal=userDal;
        }
    
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(filter:u => u.Email== email);
            //Tek kullanici donecegi icin get ile yazdik. GetList te liste doner get listte kullanilabilirde ancak tek kullanici icinde liste donerdi
        }

        public List<OperationClaim> GetClaims(User user)
        {
           return _userDal.GetClaims(user);
        }
    }
    }

