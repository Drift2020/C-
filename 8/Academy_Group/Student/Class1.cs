using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Academy_Group
{
    public class Student : Person, IComparable
    {
        public int CompareTo(object obj)
        {
            if(obj is Student)
            return Name.CompareTo((obj as Student).Name);

            throw new NotImplementedException();
        }

        private int average;
        private string number_of_group;

        public class SortByName : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return (obj1 as Student).Name.CompareTo((obj2 as Student).Name);

                throw new NotImplementedException();
            }
        }

        public class SortBySurname : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return (obj1 as Student).Surname.CompareTo((obj2 as Student).Surname);

                throw new NotImplementedException();
            }
        }

        public class SortByAge : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return (obj1 as Student).Age.CompareTo((obj2 as Student).Age);

                throw new NotImplementedException();
            }
        }

        public class SortByPhone : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return (obj1 as Student).Phone.CompareTo((obj2 as Student).Phone);

                throw new NotImplementedException();
            }
        }

        public class SortByAverage : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return (obj1 as Student).Average.CompareTo((obj2 as Student).Average);

                throw new NotImplementedException();
            }
        }
        public class SortByNumber_of_group : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Student && obj2 is Student)
                    return (obj1 as Student).Number_of_group.CompareTo((obj2 as Student).Number_of_group);

                throw new NotImplementedException();
            }
        }
        public int Average
        {
            get { return average; }
            set { average = value; }
        }
        public string Number_of_group
        {
            get { return number_of_group; }
            set { number_of_group = value; }
        }


        public Student() : this("Sasha", "Buzhenko", 18, "+380678010145", 11, "EKO-16-P3") { }
        public Student(string name, string surname, int age, string phone, int average, string number_of_group) : base(name, surname, age, phone)
        {
            Average = average;
            Number_of_group = number_of_group;
        }
       
        public new void Print()
        {
            base.Print();
            Console.WriteLine("5.Average: {0}", average);
            Console.WriteLine("6.Number of group: {0}", number_of_group);
        }
    }
}
