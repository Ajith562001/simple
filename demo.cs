using System;

class Program {
    static void Main(string[] args) {
        string str, rev;
        Console.WriteLine("Enter a string: ");
        str = Console.ReadLine();
        char[] ch = str.ToCharArray();
        Array.Reverse(ch);
        rev = new string(ch);
        if (str == rev)
            Console.WriteLine(str + " is a palindrome.");
        else
            Console.WriteLine(str + " is not a palindrome.");
        Console.ReadLine();
    }
}
