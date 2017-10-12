using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_Group
{
    public class Person
    {
        private string name;
        private string surname;
        private int age;
        private string phone;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }


        public Person() : this("Sasha", "Buzhenko", 18, "+380678010145") { }
        public Person(string name, string surname, int age, string phone)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Phone = phone;
        }
        public void Print()
        {
            Console.WriteLine("1.Name: {0}", Name);
            Console.WriteLine("2.Surname: {0}", Surname);
            Console.WriteLine("3.Age: {0}", Age);
            Console.WriteLine("4.Phone number: {0}", Phone);
        }
    }
}
