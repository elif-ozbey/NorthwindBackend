using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        //Kullanicinin claimlerinin getirlimesi.Sahip oldugu yetkilerin getirilmesi
        List<OperationClaim> GetClaims(User user);
        //Kullanici ekleme
        void Add(User user);
        //mail ile kullaniciyi bulmak icin
        User GetByMail(string email);
    }
}
