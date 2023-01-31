using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        const string CommandLookOverdue = "1";
        const string CommandGoHome = "2";
        bool isExit = false;

        StewSet stewSet = new StewSet();

        Console.WriteLine("Доброго дня, сотрудник");

        while (isExit == false)
        {
            Console.WriteLine("Проверить просрочку по тушенке - " + CommandLookOverdue + ", пойти домой - " + CommandGoHome);
            string userChoice = Console.ReadLine();

            if (userChoice == CommandLookOverdue)
                stewSet.ShowOverdue();
            else if (userChoice == CommandGoHome)
                isExit = true;
        }
    }
}

class StewSet
{
    private DateTime _today = DateTime.Today;
    private List<Stew> _stew = new List<Stew>();

    public StewSet()
    {
        Add();
    }

    public void ShowOverdue()
    {
        var overdueStew = _stew.Where(stew => stew.ProductionYear + stew.ShelfLife < _today.Year);

        foreach (Stew stew in overdueStew)
        {
            Console.WriteLine(stew.Name);
        }
    }

    private void Add()
    {
        _stew.Add(new Stew("Гродфуд", 2019));
        _stew.Add(new Stew("Барс", 2021));
        _stew.Add(new Stew("Совок", 2023));
        _stew.Add(new Stew("Йошкар-Олинский мясокомбинат", 2020));
        _stew.Add(new Stew("Вкусвилл", 2016));
        _stew.Add(new Stew("Микоян", 2020));
        _stew.Add(new Stew("Гродфуд", 2021));
        _stew.Add(new Stew("Барс", 2022));
        _stew.Add(new Stew("Микоян", 2017));
        _stew.Add(new Stew("Совок", 2021));
        _stew.Add(new Stew("Вкусвилл", 2022));
        _stew.Add(new Stew("Йошкар-Олинский мясокомбинат", 2018));
    }
}

class Stew
{
    public Stew(string name, int productionYear)
    {
        Name = name;
        ProductionYear = productionYear;
        ShelfLife = 5;
    }

    public string Name { get; private set; }
    public int ProductionYear { get; private set; }
    public int ShelfLife { get; private set; }
}
