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

    public Club() : this("������", "����") { }

    public void Show()
    {
        Console.WriteLine("\n{0}   {1}", Name, City);
    }

    public void Input()
    {
        Console.WriteLine("\n������� �������� �����: ");
        this.Name = Console.ReadLine();
        Console.WriteLine("\n������� �������� ������: ");
        this.City = Console.ReadLine();
    }
}

// IEnumerable ������������� �������������, ������� ������������ ������� ������� ��������� ������������ ���������
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

    //�������� ������������ �����, � ������� ������������ �������� ����� yield ��� �������� �� ��������� ��� ������� 
    public IEnumerator GetEnumerator()
    {
        Console.WriteLine("\n����������� ����� GetEnumerator");
        for (int i = 0; i < ar.Length; i++)
            yield return ar[i];
        // ��� ��������� � ��������� yield return ����� ����������� ������� ��������������.
        // � ����� foreach �������� � ��������� �������� ��� ��������� ������ �������, 
        // �������� ������ ���������� � ����� ��������������.
    }
}

class MainClass
{
    public static void Main()
    {
        Club[] c = new Club[6];
        c[0] = new Club("������", "����");
        c[1] = new Club("�������", "������");
        c[2] = new Club("�����", "�����");
        c[3] = new Club("����", "������");
        c[4] = new Club("�����", "������");
        c[5] = new Club("�������", "������");
        foreach (Club temp in c)
            temp.Show();
        League lg = new League(c);
        foreach (Club temp in lg)
            temp.Show();
        foreach (Club temp in lg)
            temp.Show();
    }
}

