using System;
using RandomPasswordGenerator;

namespace TestingRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating instance of RandomPassGen class with 2 libraries
            RandomPassGen NewPass = new RandomPassGen(Library.numbers, Library.alphabetUper);

            // Generating password with length 9
            string password = NewPass.NewPassword(9);
            // Generating Hexpassword
            string Hexpassword = RandomPassGen.HexPassword();
            // Generating pincode
            string Pincode = RandomPassGen.PinCode();
            // the output is
            Console.WriteLine("Password----->\t{0}\nHexpassword-->\t{1}\nPincode------>\t{2}", password, Hexpassword, Pincode);

            // using NewPassword override method to change Libraries and generate new password
            password = NewPass.NewPassword(14, Library.numbers, Library.alphabetUper, Library.symbols);


            Console.ReadKey();
        }
    }
}
