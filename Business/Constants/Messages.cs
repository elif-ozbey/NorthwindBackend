using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Urun basari ile eklendi";
        public static string ProductDeleted = "Urun basari ile silindi";
        public static string ProductUpdated = "Urun basari ile guncellendi";

        public static string UserNotFound = "Kullanici bulunamadi";
        public static string PasswordError = "Password Hatali";
        public static string SuccessfulLogin = "Sisteme Giris Basarili";
public static string UserAlreadyExists = "Bu kullanici mevcut";
        public static string UserRegistered="Kullanici basariyla kaydedildi";
        internal static string AccessTokenCreated="Token basari ile olusturuldu";
    }

    }
