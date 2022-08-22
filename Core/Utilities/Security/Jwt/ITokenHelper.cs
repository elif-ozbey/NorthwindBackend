using Core.Entities.Concrete;
using Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        //Token uretmek icin
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims); //User gonderecegim user bilgisine gore token uretecek
    }
}
