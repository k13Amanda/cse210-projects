using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        
        string userName = PromptUserName();
        int favNumber = PromptUserNumber();
        int sqNumber = SquareNumber(favNumber);
        DisplayResult(userName, favNumber, sqNumber);
    }    

    static void DisplayWelcome() 
    {
    Console.WriteLine ("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("What is your Name? ");
        return Console.ReadLine ();
    }

    static int PromptUserNumber()
    { 
    Console.Write("What is your favorite number? ");
    return int.Parse(Console.ReadLine());
    }

    
    static int SquareNumber(int number)
    {
        int sqNumber = number * number;
        return sqNumber;
    }
    
    static void DisplayResult(string userName, int favNumber, int sqNumber)
    {
        Console.WriteLine($"Your name is {userName} your favorite number is {favNumber} the square of your number is {sqNumber}");
    }
}