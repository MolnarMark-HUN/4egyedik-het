using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp2;

internal class Program
{
    static List<int> list = new List<int>();
    static Random random = new Random();
    static void Main(string[] args)
    {
        InitializeList(10);
        while (true)
        {
            int num = 0;
            try
            {
                num = WriteMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

            for (int i = 0; i < 10; i++)
            {
                list.Add(random.Next(1, 10));
            }
            Console.WriteLine($"A {num}. számot választottad");
            MenuSwitch(num);
            Console.ReadKey();

        }

    }
    static void InitializeList(int num, int min = 1, int max = 10)
    {
        for (int i = 0; i < num; i++)
        {
            list.Add(random.Next(min, max + 1));
        }
    }
    static void MenuSwitch(int num)
    {
        switch (num)
        {
            case 1: Console.WriteLine(String.Join(' ', list)); break;
            case 2:
                Console.WriteLine("Add meg a számiot amit hozzá akarsz adni"); Console.Write("Szám: "); int valueToAdd = CheckNum(); list.Add(valueToAdd);
                break;
            case 3: Console.WriteLine("A legnagyobb szám: " + list.Max()); break;
            case 4: Console.WriteLine("A legkisebb szám: " + list.Min()); break;
            case 5: int numbertodelete = CheckNum(); list.Remove(numbertodelete); break;
            case 6: Environment.Exit(0); break;
            default: Console.WriteLine("A szánmnakl whfujagf"); break;
        }
    }
    static int CheckNum()
    {
        int choosenNumber = 0;
        if (int.TryParse(Console.ReadLine(), out choosenNumber))
        {
            return choosenNumber;
        }
        else
        {
            Console.WriteLine("Hibás szám megadás");
            return default;

        }
    }
    static int WriteMenu()
    {
        Console.Clear();
        Console.WriteLine("1. adatok listázása");
        Console.WriteLine("2. adatok létrehozása");
        Console.WriteLine("3. legnagyobb adat");
        Console.WriteLine("4. legkisebb adat");
        Console.WriteLine("5. adat törlése");
        Console.WriteLine("6. Exit");
        int choosenNumber = CheckNum();
        if (choosenNumber < 1 || choosenNumber > 6)
        {
            throw new Exception("Helytelen szám");
        }
        return choosenNumber;
    }
}
