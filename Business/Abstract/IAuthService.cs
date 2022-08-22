using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        //login ve register islemleri buradan yapilacak
        //login olmak demek kullanicinin varligini db konrol etmek demek.
        //register olmak demek sisteme kullanicini kayit olmasi. 
        //bu durumda kullanica bir result veriyoruz
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);

        //Kullanicinin varligini kontrol etme:

        IResult UserExists(string email);
        //Access token uretmek istiyoruz
        IDataResult<AccessToken> CreateAccessToken(User user);
        
    }
}
