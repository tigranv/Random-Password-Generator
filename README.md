# Random Password Generator Library.    
### Simple library for generating strong cryptographically secure random passwords.   
The Class Library Random-Password-Generator provides an opportunity to generate passwords of following types

* Random cryptography in various lengths and symbols 
* Generation HexPasswords
* Generation pinCodes

```C#
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
```

### Installation
To see how to add class library to your project visit: [Add or Remove References] (https://msdn.microsoft.com/en-us/library/hh708954.aspx)
### Simple Usage
Instead of instantiating individual Random objects, I recommend that you create a single Random instance to generate all the random numbers needed by your app.

> This class library written on C# 2015 .NET Framework 4.6
