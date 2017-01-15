using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace RandomPasswordGenerator
{
    public class RandomPassGen
    {
        public RandomPassGen(params Library[] lib)
        {
            switch (lib.Length)
            {
                case 1:
                    library += "0123456789";
                    break;
                case 2:
                    library += "0123456789" + "?!/-_.$#@&^()+*=`~";
                    break;
                case 3:
                    library += "0123456789" + "?!/-_.$#@&^()+*=`~" + "abcdefghijklmnopqrstuvwxyz";
                    break;
                case 4:
                    library += "0123456789" + "?!/-_.$#@&^()+*=`~" + "abcdefghijklmnopqrstuvwxyz" + "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("conditions must be equal 0,1,2 or3");      
            }    
        }

        private char[] password;
        private string library = String.Empty;
        private string[] librarr = { "0123456789", "abcdefghijklmnopqrstuvwxyz", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "~!@#$%^&*()_+/?-*-`" };

        public string NewPassword(int length)
        {
            if (length >= 4 && length <= 12)
                password = new char[length];
            else
                throw new ArgumentOutOfRangeException("password's length must be more than 3 and less than 13 symbols");

            byte[] data = new byte[password.Length];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(data);
            var seed = BitConverter.ToInt32(data, 0);
            var rnd = new Random(seed);
            for (int i = 0; i < password.Length; i++)
            {
                password[i] = (char)library[rnd.Next(0, library.Length - 1)];
            }
            return RandomPassGen.ToString(password);
        }

        //public static string HexPasswordGen()
        //{

        //    char[] pin = new char[19];
        //    string hex = "0123456789abcdefABCDEF";
        //    byte[] data = new byte[pin.Length];
        //    var rng = new RNGCryptoServiceProvider();
        //    rng.GetBytes(data);
        //    var seed = BitConverter.ToInt32(data, 0);
        //    var rnd = new Random(seed);
        //    for (int i = 0; i < 19; i++)
        //    {
        //        if (i != 4 && i != 9 && i != 14)
        //            pin[i] = (char)hex[rnd.Next(0, hex.Length - 1)];
        //        else
        //            pin[i] = '-';
        //    }
        //    return RandomPassGen.ToString(pin);


        //}

        public static string PinCodeGen()
        {
            char[] pin = new char[4];
            string pincode = "0123456789";
            byte[] data = new byte[pin.Length];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(data);
            var seed = BitConverter.ToInt32(data, 0);
            var rnd = new Random(seed);
            for (int i = 0; i < pin.Length; i++)
            {
                pin[i] = (char)pincode[rnd.Next(0, pincode.Length - 1)];
            }
            return RandomPassGen.ToString(pin);
        }

        public static string ToString(char[] pin)
        {
            string s = String.Empty; ;
            foreach (var x in pin)
                s = s + x;
            return s;
        }

    }
}
