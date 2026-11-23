using System;

namespace Module5Homework;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("=== Задание 1: Журнал ===");
            Journal j1 = new Journal("IT News", 2015, "Технологии", "+380501112233", "it@news.ua", 25);
            Journal j2 = new Journal("Science Today", 2010, "Наука", "+380671112233", "info@science.ua", 30);

            j1 = j1 + 5;
            j2 = j2 - 5;

            j1.ShowData();
            j2.ShowData();

            Console.WriteLine($"j1 == j2: {j1 == j2}");
            Console.WriteLine($"j1 != j2: {j1 != j2}");
            Console.WriteLine($"j1.Equals(j2): {j1.Equals(j2)}");

            j1 = 10 + j1;
            Console.WriteLine($"После добавления 10 сотрудников: j1 > j2 = {j1 > j2}, j1 < j2 = {j1 < j2}\n");

            Console.WriteLine("=== Задание 2: Магазин ===");
            Shop s1 = new Shop("TechStore", "ул. Садовая, 3", "Электроника", "+380509998877", "sales@tech.ua", 120.5);
            Shop s2 = new Shop("GadgetHub", "ул. Дерибасовская, 10", "Гаджеты", "+380679998877", "info@gadget.ua", 150.0);

            s1 = s1 + 29.5;
            s1.ShowData();
            s2.ShowData();

            Console.WriteLine($"s1 == s2: {s1 == s2}");
            Console.WriteLine($"s1.Equals(s2): {s1.Equals(s2)}");

            s2 = s2 - 40.0;
            Console.WriteLine($"После уменьшения площади s2: s1 > s2 = {s1 > s2}, s1 < s2 = {s1 < s2}, s1 != s2 = {s1 != s2}\n");

            Console.WriteLine("=== Задание 3: Список книг к прочтению ===");
            ReadingList list = new ReadingList();
            Book b1 = new Book("CLR via C#", "Джеффри Рихтер", 2012);
            Book b2 = new Book("Чистый код", "Роберт Мартин", 2008);
            Book b3 = new Book("Паттерны проектирования", "Эрик Фримен", 2004);

            list = list + b1;
            list = list + b2;
            list = list + b3;
            list.ShowBooks();

            Console.WriteLine($"Есть ли книга \"{b2.Title}\" в списке: {list.Contains(b2)}");
            Console.WriteLine($"Первая книга через индексатор: {list[0]}");

            list[1] = new Book("Совершенный код", "Стив Макконнелл", 2004);
            list = list - b3;
            Console.WriteLine("\nПосле замены 2-й книги и удаления 3-й:");
            list.ShowBooks();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка данных: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}