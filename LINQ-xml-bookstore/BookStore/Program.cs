// See https://aka.ms/new-console-template for more information
using BookStore;

Console.WriteLine("Welcome to the bookstore!");


// TODO: Parse XML from the Books.xml file;
string xml = "...";

Bookstore bookstore = new Bookstore(xml);

Console.WriteLine("Average Price of Books: " + bookstore.CalculateAveragePriceOfBooks());
Console.WriteLine("Number of Books Published After 2007: " + bookstore.CountBooksPublishedAfterYear(2007));
Console.WriteLine("Authors with Books: " + bookstore.GetAuthorsWithBooks());

bookstore.IncreasePriceByPercentage(10);
Console.WriteLine("Updated XML after price increase:\n" + bookstore.xmlData);

bookstore.AddBook("Book 3", "Author C", 14.99, 2020);
Console.WriteLine("Updated XML after adding a new book:\n" + bookstore.xmlData);
