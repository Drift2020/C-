using System;
using System.Collections;
class Club
{
    public string Name { get; set; }

    public string City { get; set; }

    public Club(string name, string city)
    {
        this.Name = name;
        this.City = city;
    }

    public Club() : this("Динамо", "Киев") { }

    public void Show()
    {
        Console.WriteLine("\n{0}   {1}", Name, City);
    }

    public void Input()
    {
        Console.WriteLine("\nВведите название клуба: ");
        this.Name = Console.ReadLine();
        Console.WriteLine("\nВведите название города: ");
        this.City = Console.ReadLine();
    }
}

// IEnumerable предоставляет перечислитель, который поддерживает простой перебор элементов необобщенной коллекции
class League : IEnumerable
{
    Club[] ar;
    public League(int len)
    {
        ar = new Club[len];
        for (int i = 0; i < len; i++)
        {
            ar[i] = new Club();
        }
    }

    public League() : this(1) { }

    public League(Club[] clubs)
    {
        ar = new Club[clubs.Length];
        for (int i = 0; i < clubs.Length; i++)
        {
            ar[i] = new Club(clubs[i].Name, clubs[i].City);
        }
    }

    public void InputClub()
    {
        for (int i = 0; i < ar.Length; i++)
            ar[i].Input();
    }

    public void ShowClubs()
    {
        for (int i = 0; i < ar.Length; i++)
            ar[i].Show();
    }

    //Итератор представляет метод, в котором используется ключевое слово yield для перебора по коллекции или массиву 
    public IEnumerator GetEnumerator()
    {
        Console.WriteLine("\nВыполняется метод GetEnumerator");
        for (int i = 0; i < ar.Length; i++)
            yield return ar[i];
        // При обращении к оператору yield return будет сохраняться текущее местоположение.
        // И когда foreach перейдет к следующей итерации для получения нового объекта, 
        // итератор начнет выполнение с этого местоположения.
    }
}

class MainClass
{
    public static void Main()
    {
        Club[] c = new Club[6];
        c[0] = new Club("Динамо", "Киев");
        c[1] = new Club("Бавария", "Мюнхен");
        c[2] = new Club("Интер", "Милан");
        c[3] = new Club("Реал", "Мадрид");
        c[4] = new Club("Челси", "Лондон");
        c[5] = new Club("Арсенал", "Лондон");
        foreach (Club temp in c)
            temp.Show();
        League lg = new League(c);
        foreach (Club temp in lg)
            temp.Show();
        foreach (Club temp in lg)
            temp.Show();
    }
}

