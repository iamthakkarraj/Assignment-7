using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services {

    public static class CryptoServices {

        public static String DecryptString(String cipherText) {            
            try {
                return System
                        .Text
                        .ASCIIEncoding
                        .ASCII
                        .GetString(
                            Convert
                            .FromBase64String(cipherText));
            } catch {
                return "";
            }            
        }

        public static String EnryptString(String normalText) {                        
            return Convert
                    .ToBase64String(
                        System
                        .Text
                        .ASCIIEncoding
                        .ASCII
                        .GetBytes(normalText));
        }

    }

}