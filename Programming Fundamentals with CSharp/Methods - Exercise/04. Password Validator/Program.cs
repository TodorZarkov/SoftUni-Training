using System;

public class Program
{
    public static void Main()
    {
        string password = Console.ReadLine();
        bool a = IsLengthValid(password);
        bool b = AreSymbolsValid(password);
        bool c = HasEnoughDigits(password);
        if (a && b && c)
        {
            System.Console.WriteLine("Password is valid");
        }
    }
    //valid length- 6 – 10 characters (inclusive)
    public static bool IsLengthValid(string password)
    {
        if (password.Length >= 6 && password.Length <= 10)
        {
            return true;
        }
        else
        {
            System.Console.WriteLine("Password must be between 6 and 10 characters");
            return false;
        }
    }

    //must have only letters and digits
    public static bool AreSymbolsValid(string password)
    {
        //ASCII Letters and digits are between 48-57, 65-90, 97-122.
        foreach (char symb in password)
        {
            if (!(symb >= '0' && symb <= '9' ||
                    symb >= 'a' && symb <= 'z' ||
                    symb >= 'A' && symb <= 'Z')
                )
            {
                System.Console.WriteLine("Password must consist only of letters and digits");
                return false;
            }
        }
        return true;
    }

    //must contain at least two digits
    public static bool HasEnoughDigits(string password)
    {
        int numberOfDigits = 0;
        foreach (char symbol in password)
        {
            if (symbol >= '0' && symbol <= '9')
            {
                numberOfDigits++;
            }
        }
        if (numberOfDigits >= 2)
        {
            return true;
        }
        System.Console.WriteLine("Password must have at least 2 digits");
        return false;
    }
}