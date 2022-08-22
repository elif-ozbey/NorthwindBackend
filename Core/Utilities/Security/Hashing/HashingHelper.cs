using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //olusturma
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //kendisi bir salt vasitasiyla computerhash i olusturdu bizde onu alip password key e atadik' password hash e de olusan passwordu vermis olduk

            }
        }
        //dogrulama
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        //verify yapacagimiz icin outta ihtiyac yok' byte in onundeki outlari kaldirdik
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //iki hash degerini karsilastirma
                for (int i=0; i < computedHash.Length; i++)
                {
                    //olusturdugum hashin herbir karakterini db deki herbir eleman ile karsilastiriyorum
                    //farklilik varsa false donuyorum
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
        
            return true;
        }
    }
}
