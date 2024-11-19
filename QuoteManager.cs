using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

/// <summary>
/// Manages a collection of quotes with JSON file persistence.
/// </summary>
public class QuoteManager
{
    private List<Quote> quotes;
    private Random random = new Random();
    private string quotesFilePath;

    /// <summary>
    /// Initializes a new instance of the QuoteManager class.
    /// </summary>
    public QuoteManager()
    {
        // Create quotes directory if it doesn't exist
        string quotesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "quotes");
        Directory.CreateDirectory(quotesDirectory);

        // Set the file path
        quotesFilePath = Path.Combine(quotesDirectory, "quotes.json");

        // Load existing quotes or initialize empty list
        quotes = LoadQuotes();
    }

    /// <summary>
    /// Loads quotes from the JSON file.
    /// </summary>
    /// <returns>List of quotes</returns>
    private List<Quote> LoadQuotes()
    {
        if (!File.Exists(quotesFilePath))
        {
            // Create an empty file if it doesn't exist
            File.WriteAllText(quotesFilePath, "[]");
            return new List<Quote>();
        }

        try
        {
            string jsonString = File.ReadAllText(quotesFilePath);
            return JsonSerializer.Deserialize<List<Quote>>(jsonString) ?? new List<Quote>();
        }
        catch
        {
            // If there's an error reading the file, return an empty list
            return new List<Quote>();
        }
    }

    /// <summary>
    /// Saves quotes to the JSON file.
    /// </summary>
    private void SaveQuotes()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(quotes, options);
        File.WriteAllText(quotesFilePath, jsonString);
    }

    /// <summary>
    /// Adds a new quote to the collection and saves to file.
    /// </summary>
    /// <param name="quote">The quote to add.</param>
    public void AddQuote(Quote quote)
    {
        quotes.Add(quote);
        SaveQuotes();
    }

    /// <summary>
    /// Retrieves a random quote from the collection.
    /// </summary>
    /// <returns>A random quote or null if no quotes exist.</returns>
    public Quote GetRandomQuote()
    {
        if (quotes.Count == 0)
            return null;
        
        return quotes[random.Next(quotes.Count)];
    }

    /// <summary>
    /// Retrieves all quotes in the collection.
    /// </summary>
    /// <returns>A list of quotes.</returns>
    public List<Quote> GetAllQuotes()
    {
        return quotes;
    }
}