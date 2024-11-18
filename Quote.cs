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

    /// <summary>
    /// Creates a new Quote instance.
    /// </summary>
    /// <param name="text">The quote's text</param>
    /// <param name="author">The quote's author</param>
    public Quote(string text, string author)
    {
        Text = text;
        Author = author;
    }
}