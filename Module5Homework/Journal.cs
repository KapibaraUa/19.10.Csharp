using System;

namespace Module5Homework;

public class Journal
{
    private string _name = String.Empty;
    private ushort _foundationYear;
    private string _description = String.Empty;
    private string _contactPhone = String.Empty;
    private string _email = String.Empty;
    private int _employeesCount;

    public string Name
    {
        get { return _name; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Название журнала не может быть пустым.");
            _name = value;
        }
    }

    public ushort FoundationYear
    {
        get { return _foundationYear; }
        set
        {
            if (value < 1600 || value > DateTime.Now.Year)
                throw new ArgumentException("Некорректный год основания журнала.");
            _foundationYear = value;
        }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value ?? String.Empty; }
    }

    public string ContactPhone
    {
        get { return _contactPhone; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Контактный телефон не может быть пустым.");
            _contactPhone = value;
        }
    }

    public string Email
    {
        get { return _email; }
        set
        {
            if (String.IsNullOrWhiteSpace(value) || !value.Contains('@'))
                throw new ArgumentException("Некорректный email.");
            _email = value;
        }
    }

    public int EmployeesCount
    {
        get { return _employeesCount; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Количество сотрудников не может быть отрицательным.");
            _employeesCount = value;
        }
    }

    public Journal()
    {
        Name = "Без названия";
        FoundationYear = 2000;
        Description = String.Empty;
        ContactPhone = "Не указан";
        Email = "none@mail.com";
        EmployeesCount = 0;
    }

    public Journal(string name, ushort foundationYear, string description, string contactPhone, string email, int employeesCount)
    {
        Name = name;
        FoundationYear = foundationYear;
        Description = description;
        ContactPhone = contactPhone;
        Email = email;
        EmployeesCount = employeesCount;
    }

    public static Journal operator +(Journal journal, int count)
    {
        if (count < 0)
            throw new ArgumentException("Значение для увеличения должно быть неотрицательным.");

        return new Journal(
            journal.Name,
            journal.FoundationYear,
            journal.Description,
            journal.ContactPhone,
            journal.Email,
            journal.EmployeesCount + count
        );
    }

    public static Journal operator +(int count, Journal journal)
    {
        return journal + count;
    }

    public static Journal operator -(Journal journal, int count)
    {
        if (count < 0)
            throw new ArgumentException("Значение для уменьшения должно быть неотрицательным.");

        if (journal.EmployeesCount - count < 0)
            throw new ArgumentException("Количество сотрудников не может стать меньше нуля.");

        return new Journal(
            journal.Name,
            journal.FoundationYear,
            journal.Description,
            journal.ContactPhone,
            journal.Email,
            journal.EmployeesCount - count
        );
    }

    public static bool operator ==(Journal? j1, Journal? j2)
    {
        if (ReferenceEquals(j1, j2))
            return true;
        if (j1 is null || j2 is null)
            return false;

        return j1.EmployeesCount == j2.EmployeesCount;
    }

    public static bool operator !=(Journal? j1, Journal? j2)
    {
        return !(j1 == j2);
    }

    public static bool operator <(Journal j1, Journal j2)
    {
        return j1.EmployeesCount < j2.EmployeesCount;
    }

    public static bool operator >(Journal j1, Journal j2)
    {
        return j1.EmployeesCount > j2.EmployeesCount;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Journal other)
            return EmployeesCount == other.EmployeesCount;
        return false;
    }

    public override int GetHashCode()
    {
        return EmployeesCount.GetHashCode();
    }

    public void ShowData()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Журнал: {Name} ({FoundationYear} г.) | Сотрудников: {EmployeesCount} | Тел: {ContactPhone} | Email: {Email}";
    }
}