using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(
            reference,
            "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him and he shall direct thy paths."
        );

        string userInput = "";

        while (userInput != "quit" && !scripture.IsCompletelyHidden())
        {
            ClearConsole();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            userInput = Console.ReadLine().ToLower();

            if (userInput == "")
            {
                scripture.HideRandomWords(3);
            }
        }

        if (scripture.IsCompletelyHidden())
        {
            ClearConsole();
            Console.WriteLine(scripture.GetDisplayText());
        }
    }

    static void ClearConsole()
    {
        try
        {
            Console.Clear();
        }
        catch (System.IO.IOException)
        {
        }
    }
}
