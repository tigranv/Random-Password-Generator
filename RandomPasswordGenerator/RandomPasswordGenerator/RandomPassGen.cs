using System;
using System.Security.Cryptography;


namespace RandomPasswordGenerator
{
    public class RandomPassGen
    {
        // User constructor for library of symbols that will used to create password
        public RandomPassGen(params Library[] lib)
        {
            for (int i = 0; i < lib.Length; i++)
            {
                switch (lib[i])
                {
                    case Library.numbers:
                        library += "0123456789";
                        break;
                    case Library.symbols:
                        library += "?!/-_.$#@&^()+*=`~";
                        break;
                    case Library.alphabetLower:
                        library += "abcdefghijklmnopqrstuvwxyz";
                        break;
                    case Library.alphabetUper:
                        library += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Fields must be from Library");
                } 
            }    
        }


        // private fields
        private char[] password;
        private string library = String.Empty;


        // Method for random password generation
        public string NewPassword(int length)
        {
            if (length >= 4 && length <= 16)
                password = new char[length];
            else
                throw new ArgumentOutOfRangeException("password's must be from 4 to 16 symbols");

            byte[] data = new byte[password.Length];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(data);
            var seed = BitConverter.ToInt32(data, 0);
            var rnd = new Random(seed);
            for (int i = 0; i < password.Length; i++)
            {
                password[i] = (char)library[rnd.Next(0, library.Length - 1)];
            }
            return new string(password);
        }

        public string NewPassword(int length, params Library[] lib)
        {
            for (int i = 0; i < lib.Length; i++)
            {
                switch (lib[i])
                {
                    case Library.numbers:
                        library += "0123456789";
                        break;
                    case Library.symbols:
                        library += "?!/-_.$#@&^()+*=`~";
                        break;
                    case Library.alphabetLower:
                        library += "abcdefghijklmnopqrstuvwxyz";
                        break;
                    case Library.alphabetUper:
                        library += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Fields must be from Library");
                }
            }
            if (length >= 4 && length <= 16)
                password = new char[length];
            else
                throw new ArgumentOutOfRangeException("password's must be from 4 to 16 symbols");

            byte[] data = new byte[password.Length];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(data);
            var seed = BitConverter.ToInt32(data, 0);
            var rnd = new Random(seed);
            for (int i = 0; i < password.Length; i++)
            {
                password[i] = (char)library[rnd.Next(0, library.Length - 1)];
            }
            return new string(password);
        }

        // Method for Hex password generation
        public static string HexPassword()
        {
            char[] hexpassword = new char[19];
            string hex = "0123456789abcdefABCDEF";
            byte[] data = new byte[hexpassword.Length];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(data);
            var seed = BitConverter.ToInt32(data, 0);
            var rnd = new Random(seed);
            for (int i = 0; i < 19; i++)
            {
                if (i != 4 && i != 9 && i != 14)
                    hexpassword[i] = (char)hex[rnd.Next(0, hex.Length - 1)];
                else
                    hexpassword[i] = '-';
            }
            return new string(hexpassword);
        }

        // Method for Pin Code generation
        public static string PinCode()
        {
            char[] pinCode = new char[4];
            string pin = "0123456789";
            byte[] data = new byte[pinCode.Length];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(data);
            var seed = BitConverter.ToInt32(data, 0);
            var rnd = new Random(seed);
            for (int i = 0; i < pinCode.Length; i++)
            {
                pinCode[i] = (char)pin[rnd.Next(0, pin.Length - 1)];
            }
            return new string(pinCode);
        }
    }
}
