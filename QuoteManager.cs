using System;
using System.Collections.Generic;

/// <summary>
/// Manages a collection of quotes.
/// </summary>
public class QuoteManager
{
    private List<Quote> quotes;
    private Random random = new Random();

    public Quote GetRandomQuote()
    {
        if (quotes.Count == 0)
            return null;
        
        return quotes[random.Next(quotes.Count)];
    }

    /// <summary>
    /// Initializes a new instance of the QuoteManager class.
    /// </summary>
    public QuoteManager()
    {
        quotes = new List<Quote>();
    }

    /// <summary>
    /// Adds a new quote to the collection.
    /// </summary>
    /// <param name="quote">The quote to add.</param>
    public void AddQuote(Quote quote)
    {
        quotes.Add(quote);
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