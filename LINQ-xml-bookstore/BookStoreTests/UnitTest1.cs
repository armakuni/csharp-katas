using System;
using System.Xml.Linq;
using BookStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreTests;

[TestClass]
public class BookstoreTests
{

    [TestMethod]
    public void TestCalculateAveragePriceOfBooks()
    {
        // Arrange
        string xml = "..."; // Replace with the XML data containing book information.
        Bookstore bookstore = new Bookstore(xml);

        // Act
        double averagePrice = bookstore.CalculateAveragePriceOfBooks();

        // Assert
        Assert.AreEqual(16.09, Math.Round(averagePrice, 2));
    }

    [TestMethod]
    public void TestCountBooksPublishedAfterYear()
    {
        // Arrange
        string xml = "..."; // Replace with the XML data containing book information.
        Bookstore bookstore = new Bookstore(xml);

        // Act
        int count = bookstore.CountBooksPublishedAfterYear(2010);

        // Assert
        Assert.AreEqual(14, count);
    }

    [TestMethod]
    public void TestIncreasePriceByPercentage()
    {
        // Arrange
        string xml = "..."; // Replace with the XML data containing book information.
        Bookstore bookstore = new Bookstore(xml);

        // Act
        bookstore.IncreasePriceByPercentage(10);

        // Assert
        // Check if the prices of specific books have been updated as expected
        Assert.AreEqual(14.29, Math.Round((double)bookstore.xmlData.Elements("book").First(b => (string)b.Element("title") == "Book 1").Element("price"), 2));
        Assert.AreEqual(21.99, Math.Round((double)bookstore.xmlData.Elements("book").First(b => (string)b.Element("title") == "Book 2").Element("price"), 2));
    }

    [TestMethod]
    public void TestGetAuthorsWithBooks()
    {
        // Arrange
        string xml = "..."; // Replace with the XML data containing book information.
        Bookstore bookstore = new Bookstore(xml);

        // Act
        string authors = bookstore.GetAuthorsWithBooks();

        // Assert
        Assert.AreEqual("Author A, Author B, Author C, Author D, Author E", authors);
    }

    [TestMethod]
    public void TestAddBook()
    {
        // Arrange
        string xml = "..."; // Replace with the XML data containing book information.
        Bookstore bookstore = new Bookstore(xml);

        // Act
        bookstore.AddBook("New Book", "New Author", 25.99, 2022);

        // Assert
        XElement addedBook = bookstore.xmlData.Elements("book").Last();
        Assert.AreEqual("New Book", (string)addedBook.Element("title"));
        Assert.AreEqual("New Author", (string)addedBook.Element("author"));
        Assert.AreEqual(25.99, (double)addedBook.Element("price"));
        Assert.AreEqual(2022, (int)addedBook.Element("publish_date"));
    }
}