using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;//salt değeri oluşturuyor
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //hash oluştu.Encoding kısmı ile stringi çevirdi
                //pass.un haslendiği yer
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //password hash doğrulama // out olmamalı burdaki değerleri biz vericez//password tekrardan  girdiği parola
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))//key anahtarı
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//bi tane hash oluştu salt kullanılarak yapıldı
                for (int i = 0; i < computedHash.Length; i++)//iki arrayin değerleri aynımı
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }


        }
    }
}
