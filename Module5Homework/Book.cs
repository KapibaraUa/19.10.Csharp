using System;

namespace Module5Homework;

public class Book
{
    private string _title = String.Empty;
    private string _author = String.Empty;
    private ushort _year;

    public string Title
    {
        get { return _title; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Название книги не может быть пустым.");
            _title = value;
        }
    }

    public string Author
    {
        get { return _author; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Автор книги не может быть пустым.");
            _author = value;
        }
    }

    public ushort Year
    {
        get { return _year; }
        set
        {
            if (value == 0 || value > DateTime.Now.Year)
                throw new ArgumentException("Некорректный год издания.");
            _year = value;
        }
    }

    public Book()
    {
        Title = "Без названия";
        Author = "Неизвестен";
        Year = 2000;
    }

    public Book(string title, string author, ushort year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public static bool operator ==(Book? b1, Book? b2)
    {
        if (ReferenceEquals(b1, b2))
            return true;
        if (b1 is null || b2 is null)
            return false;

        return b1.Title.Equals(b2.Title, StringComparison.OrdinalIgnoreCase) &&
               b1.Author.Equals(b2.Author, StringComparison.OrdinalIgnoreCase);
    }

    public static bool operator !=(Book? b1, Book? b2)
    {
        return !(b1 == b2);
    }

    public override bool Equals(object? obj)
    {
        if (obj is Book other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Title.ToLower(), Author.ToLower());
    }

    public override string ToString()
    {
        return $"\"{Title}\" — {Author} ({Year})";
    }
}