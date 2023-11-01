using System;
using System.Linq;
using System.Xml.Linq;

namespace BookStore;
public class Bookstore
{
    public XElement xmlData { get; private set; }

    public Bookstore(string xml)
    {
        xmlData = XElement.Parse(xml);
    }

    public double CalculateAveragePriceOfBooks()
    {
        // Calculate the average price of all books in the XML document.
        // Return the result as a double with two decimal places.
        return 0;
    }

    public int CountBooksPublishedAfterYear(int year)
    {
        // Count the number of books in the XML document that were published after the specified year.
        return 0;
    }

    public void IncreasePriceByPercentage(double percentage)
    {
        // Increase the price of all books in the XML document by the specified percentage.
        // Update the XML in place.
    }

    public string GetAuthorsWithBooks()
    {
        // Get a comma-separated string of unique author names who have written books in the XML document.
        return string.Empty;
    }

    public void AddBook(string title, string author, double price, int publishYear)
    {
        // Add a new book to the XML document with the given information.
        // The new book should be appended to the end of the list of books.
    }
}