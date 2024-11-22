using System;

/// <summary>
/// Represents a motivational quote with text and author.
/// </summary>
public class Quote
{
    /// <summary>
    /// The text of the quote.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// The author of the quote.
    /// </summary>
    public string Author { get; set; }

    // date property to track when this quote was last selected
    public DateTime? LastSelectedDate { get; set; }

    /// <summary>
    /// Creates a new Quote instance.
    /// </summary>
    /// <param name="text">The quote's text</param>
    /// <param name="author">The quote's author</param>
    public Quote(string text, string author)
    {
        Text = text;
        Author = author;
        LastSelectedDate = null;
    }

    public Quote GetDailyQuote()
    {
        // Find a quote that hasn't been used today
        Quote todayQuote = quotes.FirstOrDefault(q => 
            q.LastSelectedDate == null || 
            q.LastSelectedDate.Value.Date != DateTime.Today);

        if (todayQuote != null)
        {
            // Update the last selected date
            todayQuote.LastSelectedDate = DateTime.Today;
            SaveQuotes(); // Persist the change
            return todayQuote;
        }

        // If all quotes have been used today, reset and start over
        quotes.ForEach(q => q.LastSelectedDate = null);
        SaveQuotes();
        return GetDailyQuote(); // Recursive call to get a fresh quote
    }
}