// This is the main program that runs our Daily Quote App
using System;

class Program
{
    // This is our quote manager that helps us work with quotes
    // Think of it like a special helper that knows how to handle quotes
    static QuoteManager quoteManager = new QuoteManager();

    // The main method - this is where our program starts running
    static void Main(string[] args)
    {
        // We use a 'running' variable to control when the program should stop
        bool running = true;

        // This is our main program loop - it keeps the program running until we choose to exit
        while (running)
        {
            // Show the menu of options to the user
            DisplayMenu();

            // Ask the user to choose an option
            string choice = Console.ReadLine();

            // Do different things based on what the user chooses
            switch (choice)
            {
                // If user chooses 1, show a random quote
                case "1":
                    DisplayRandomQuote();
                    break;

                // If user chooses 2, let them add a new quote
                case "2":
                    AddNewQuote();
                    break;

                // If user chooses 3, show all quotes
                case "3":
                    ListAllQuotes();
                    break;

                // If user chooses 4, stop the program
                case "4":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                // If user enters something weird, tell them it's not valid
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            // Wait for user to press a key (so they can read the output)
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            // Clear the screen to make it look neat
            Console.Clear();
        }
    }

    // This method shows the menu of options to the user
    static void DisplayMenu()
    {
        // Print out a list of things the user can do
        Console.WriteLine("=== Daily Quote App ===");
        Console.WriteLine("1. Get a Random Quote"); // Option to see a random quote
        Console.WriteLine("2. Add a New Quote"); // Option to add a new quote
        Console.WriteLine("3. List All Quotes"); // Option to see all quotes
        Console.WriteLine("4. Exit"); // Option to leave the program
        Console.Write("Choose an option: "); // Prompt user to make a choice
    }

    // This method shows a random quote to the user
    static void DisplayRandomQuote()
    {
        Quote quote = quoteManager.GetRandomQuote();

        if (quote != null)
        {
            Console.WriteLine("\n--- Random Quote ---");
            Console.WriteLine($"\"{quote.Text ?? ""}\"");
            Console.WriteLine($"- {quote.Author ?? "Unknown"}");
        }
        else
        {
            Console.WriteLine("No quotes available.");
        }
    }

    // This method helps the user add a new quote
    static void AddNewQuote()
    {
        Console.Write("Enter quote text: ");
        string text = Console.ReadLine() ?? "";

        Console.Write("Enter quote author: ");
        string author = Console.ReadLine() ?? "";

        // Only create quote if text is not empty
        if (!string.IsNullOrWhiteSpace(text))
        {
            Quote newQuote = new Quote(text, author);
            quoteManager.AddQuote(newQuote);
            Console.WriteLine("Quote added successfully!");
        }
        else
        {
            Console.WriteLine("Quote text cannot be empty.");
        }
    }

    // This method shows all the quotes we have
    static void ListAllQuotes()
    {
        // Get all quotes from our quote manager
        var quotes = quoteManager.GetAllQuotes();

        // If we don't have any quotes, tell the user
        if (quotes.Count == 0)
        {
            Console.WriteLine("No quotes available.");
            return;
        }

        // If we have quotes, show each one
        Console.WriteLine("\n=== All Quotes ===");
        foreach (var quote in quotes)
        {
            Console.WriteLine($"\"{quote.Text}\" - {quote.Author}");
        }
    }
}
