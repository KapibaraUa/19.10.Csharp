using System;

namespace Module5Homework;

public class Shop
{
    private string _name = String.Empty;
    private string _address = String.Empty;
    private string _profileDescription = String.Empty;
    private string _contactPhone = String.Empty;
    private string _email = String.Empty;
    private double _area;

    public string Name
    {
        get { return _name; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Название магазина не может быть пустым.");
            _name = value;
        }
    }

    public string Address
    {
        get { return _address; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Адрес магазина не может быть пустым.");
            _address = value;
        }
    }

    public string ProfileDescription
    {
        get { return _profileDescription; }
        set { _profileDescription = value ?? String.Empty; }
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

    public double Area
    {
        get { return _area; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Площадь магазина должна быть больше нуля.");
            _area = value;
        }
    }

    public Shop()
    {
        Name = "Без названия";
        Address = "Не указан";
        ProfileDescription = String.Empty;
        ContactPhone = "Не указан";
        Email = "none@mail.com";
        Area = 10.0;
    }

    public Shop(string name, string address, string profileDescription, string contactPhone, string email, double area)
    {
        Name = name;
        Address = address;
        ProfileDescription = profileDescription;
        ContactPhone = contactPhone;
        Email = email;
        Area = area;
    }

    public static Shop operator +(Shop shop, double value)
    {
        if (value < 0)
            throw new ArgumentException("Значение для увеличения площади должно быть неотрицательным.");

        return new Shop(
            shop.Name,
            shop.Address,
            shop.ProfileDescription,
            shop.ContactPhone,
            shop.Email,
            shop.Area + value
        );
    }

    public static Shop operator +(double value, Shop shop)
    {
        return shop + value;
    }

    public static Shop operator -(Shop shop, double value)
    {
        if (value < 0)
            throw new ArgumentException("Значение для уменьшения площади должно быть неотрицательным.");

        if (shop.Area - value <= 0)
            throw new ArgumentException("Площадь магазина после уменьшения должна быть больше нуля.");

        return new Shop(
            shop.Name,
            shop.Address,
            shop.ProfileDescription,
            shop.ContactPhone,
            shop.Email,
            shop.Area - value
        );
    }

    public static bool operator ==(Shop? s1, Shop? s2)
    {
        if (ReferenceEquals(s1, s2))
            return true;
        if (s1 is null || s2 is null)
            return false;

        return s1.Area == s2.Area;
    }

    public static bool operator !=(Shop? s1, Shop? s2)
    {
        return !(s1 == s2);
    }

    public static bool operator <(Shop s1, Shop s2)
    {
        return s1.Area < s2.Area;
    }

    public static bool operator >(Shop s1, Shop s2)
    {
        return s1.Area > s2.Area;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Shop other)
            return Area == other.Area;
        return false;
    }

    public override int GetHashCode()
    {
        return Area.GetHashCode();
    }

    public void ShowData()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Магазин: {Name} | Адрес: {Address} | Площадь: {Area} кв.м | Email: {Email}";
    }
}