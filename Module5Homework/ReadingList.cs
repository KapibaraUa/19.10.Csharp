using System;

namespace Module5Homework;

public class ReadingList
{
    private Book[] _books;

    public int Count
    {
        get { return _books.Length; }
    }

    public ReadingList()
    {
        _books = new Book[0];
    }

    public Book this[int index]
    {
        get
        {
            if (index >= 0 && index < _books.Length)
                return _books[index];
            else
                throw new Exception("Некорректный индекс! " + index);
        }
        set
        {
            if (value == null)
                throw new ArgumentException("Книга не может быть null.");

            if (index >= 0 && index < _books.Length)
                _books[index] = value;
            else
                throw new Exception("Некорректный индекс! " + index);
        }
    }

    public bool Contains(Book book)
    {
        if (book == null)
            return false;

        for (int i = 0; i < _books.Length; i++)
        {
            if (_books[i] == book)
                return true;
        }
        return false;
    }

    public void AddBook(Book book)
    {
        if (book == null)
            throw new ArgumentException("Книга не может быть null.");

        if (Contains(book))
            throw new ArgumentException($"Книга {book} уже есть в списке.");

        Array.Resize(ref _books, _books.Length + 1);
        _books[_books.Length - 1] = book;
    }

    public void RemoveBook(Book book)
    {
        if (book == null)
            throw new ArgumentException("Книга не может быть null.");

        int index = -1;
        for (int i = 0; i < _books.Length; i++)
        {
            if (_books[i] == book)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
            return;

        for (int i = index; i < _books.Length - 1; i++)
        {
            _books[i] = _books[i + 1];
        }

        Array.Resize(ref _books, _books.Length - 1);
    }

    public static ReadingList operator +(ReadingList list, Book book)
    {
        list.AddBook(book);
        return list;
    }

    public static ReadingList operator -(ReadingList list, Book book)
    {
        list.RemoveBook(book);
        return list;
    }

    public void ShowBooks()
    {
        Console.WriteLine($"Список книг к прочтению (всего: {Count}):");
        if (Count == 0)
        {
            Console.WriteLine("  Список пуст.");
            return;
        }

        for (int i = 0; i < _books.Length; i++)
        {
            Console.WriteLine($"  {i + 1}. {_books[i]}");
        }
    }
}