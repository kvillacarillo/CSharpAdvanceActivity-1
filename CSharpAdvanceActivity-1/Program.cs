using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
    public string Genre { get; set; }
    public string Publisher { get; set; }
    public string ISBN { get; set; }

    public Book(string title, string author, int pages, string genre, string publisher, string isbn)
    {
        Title = title;
        Author = author;
        Pages = pages;
        Genre = genre;
        Publisher = publisher;
        ISBN = isbn;
    }

    public static bool ValidateISBN(string isbn)
    {
        // Regular expression for ISBN validation
        string pattern = @"^(97(8|9))?\d{9}(\d|X)$";
        return Regex.IsMatch(isbn, pattern);
    }

    public static void WriteBookToFile(Book book, string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"Title: {book.Title}");
            writer.WriteLine($"Author: {book.Author}");
            writer.WriteLine($"Pages: {book.Pages}");
            writer.WriteLine($"Genre: {book.Genre}");
            writer.WriteLine($"Publisher: {book.Publisher}");
            writer.WriteLine($"ISBN: {book.ISBN}");
        }
    }
}

class Program
{
    static List<string> ExtractEmails(string text)
    {
        // Regular expression for extracting email addresses
        string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
        List<string> emails = new List<string>();
        MatchCollection matches = Regex.Matches(text, pattern);
        foreach (Match match in matches)
        {
            emails.Add(match.Value);
        }
        return emails;
    }

    static void Main(string[] args)
    {
        // Extract email addresses from a given text string
        string text = "Contact us at info@example.com or support@example.org for assistance.";
        List<string> extractedEmails = ExtractEmails(text);
        Console.WriteLine("Extracted Email Addresses:");
        foreach (string email in extractedEmails)
        {
            Console.WriteLine(email);
        }

        // Create a generic Dictionary<TKey, TValue> named studentData
        Dictionary<string, Student> studentData = new Dictionary<string, Student>();

        // Add two student entries to the studentData dictionary
        studentData.Add("A001", new Student("Alice", 85));
        studentData.Add("B002", new Student("Bob", 92));
    }
}

class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }

    public Student(string name, int grade)
    {
        Name = name;
        Grade = grade;
    }
}
