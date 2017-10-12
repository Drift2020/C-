using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Academy_Group
{
    public class Academy_Group : ICloneable, IEnumerable, IEnumerator
    {
        protected Student[] Human;
        protected int count;
        public Academy_Group()
        {
            Human = new Student[1] { new Student() };
            count = 1;

        }
        public void Add()
        {
            try
            {


                Console.Write("Name of student: ");
                string name = Console.ReadLine();
                Console.Write("Surname of the student: ");
                string surname = Console.ReadLine();
                Console.Write("Age of the student: ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Student phone number: ");
                string phons;
                do
                {
                    try
                    {
                        phons = Convert.ToString(Convert.ToInt64(Console.ReadLine())); ;

                        if (phons.Length > 12)
                            throw new InvalidCastException("Your phone number is more than 12 characters, \"+\" is not needed");
                        if (phons.Length < 10)
                        {
                            throw new InvalidCastException("Your phone number is less than 10 characters., \"+\" is not needed");
                        }
                        phons = "+" + phons;
                        break;
                    }
                    catch (InvalidCastException ex)
                    {

                        Console.WriteLine(ex);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("You entered an incorrect phone number, \"+\" is not needed");

                    }
                } while (true);

                Console.Write("Average student score: ");
                int average = Convert.ToInt32(Console.ReadLine());
                Console.Write("Number of group: ");
                string number_of_group = Console.ReadLine();

                Student Temp = new Student(name, surname, age, phons, average, number_of_group);
                count++;
                Student[] Temp1 = new Student[count];

                for (int i = 0; i < count - 1; i++)
                {
                    Temp1[i] = Human[i];
                }
                Temp1[count - 1] = Temp;
                Human = Temp1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void Print()
        {

            foreach (Student P in Human)
            {
                P.Print();
                Console.WriteLine();
            }

        }
        public void Remove()
        {
            Console.Write("Please enter student name to delete from group: ");
            string SurnameStudentRemove = Console.ReadLine();

            for (int i = 0; i < Human.Length; i++)
            {

                if (String.Compare(Human[i].Surname, SurnameStudentRemove) == 0)
                {
                    Student[] T = new Student[Human.Length - 1];
                    Array.Copy(Human, T, i);
                    Array.Copy(Human, i + 1, T, i, Human.Length - 1 - i);
                    count--;

                    Human = T;
                    break;
                }
            }


        }
        public void Edit()
        {
            Console.Write("Please enter the surname of the student to edit his data:");
            string StudentEdit = Console.ReadLine();

            for (int i = 0; i < Human.Length; i++)
            {

                if (String.Compare(Human[i].Surname, StudentEdit) == 0)
                {
                    Student T = Human[i];
                    bool works = true;
                    Console.Clear();
                    do
                    {
                        try
                        {
                            Console.WriteLine("1.Name of student: {0}", T.Name);
                            Console.WriteLine("2.Surname of student: {0}", T.Surname);
                            Console.WriteLine("3.Age of student: {0}", T.Age);
                            Console.WriteLine("4.Number phone of student: {0}", T.Phone);
                            Console.WriteLine("5.Average ball of student: {0}", T.Average);
                            Console.WriteLine("6.Number the group: {0}", T.Number_of_group);
                            Console.WriteLine("7.Exit");
                            Console.Write("Please enter variants: ");

                            int number = Convert.ToInt32(Console.ReadLine());
                            string t;
                            switch (number)
                            {
                                case 1:
                                    Console.Clear();
                                    do
                                    {

                                        Console.WriteLine("Name of student: {0}", T.Name);
                                        Console.WriteLine("Edit of the name?");
                                        Console.WriteLine("Yes/No");

                                        t = Console.ReadLine();
                                        if (String.Compare(t, "Yes") == 0 ||
                                            String.Compare(t, "yes") == 0 ||
                                            String.Compare(t, "Y") == 0)
                                        {
                                            Console.Clear();
                                            Console.Write("Please enter new name of student and accept edits: ");
                                            T.Name = Console.ReadLine();
                                            Console.Clear();
                                            break;
                                        }
                                        else if (String.Compare(t, "No") == 0 ||
                                            String.Compare(t, "no") == 0 ||
                                            String.Compare(t, "N") == 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("ERORR: incorrect vallu.");
                                        }
                                    } while (true);
                                    break;
                                case 2:
                                    Console.Clear();
                                    do
                                    {
                                        Console.WriteLine("Surname of student: {0}", T.Surname);
                                        Console.WriteLine("Edit of the surname?");
                                        Console.WriteLine("Yes/No");
                                        t = Console.ReadLine();
                                        if (String.Compare(t, "Yes") == 0 ||
                                            String.Compare(t, "yes") == 0 ||
                                            String.Compare(t, "Y") == 0)
                                        {
                                            Console.Clear();
                                            Console.Write("Please enter new surname of student and accept edits: ");
                                            T.Surname = Console.ReadLine();
                                            Console.Clear();
                                            break;
                                        }
                                        else if (String.Compare(t, "No") == 0 ||
                                      String.Compare(t, "no") == 0 ||
                                      String.Compare(t, "N") == 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("ERORR: incorrect vallu.");
                                        }

                                    } while (true);
                                    break;

                                case 3:
                                    Console.Clear();
                                    do
                                    {
                                        Console.WriteLine("Age of student: {0}", T.Age);
                                        Console.WriteLine("Edit of the age?");
                                        Console.WriteLine("Yes/No");
                                        t = Console.ReadLine();
                                        if (String.Compare(t, "Yes") == 0 ||
                                            String.Compare(t, "yes") == 0 ||
                                            String.Compare(t, "Y") == 0)
                                        {
                                            Console.Clear();
                                            Console.Write("Please enter new age of student and accept edits: ");
                                            T.Age = Convert.ToInt32(Console.ReadLine());
                                            Console.Clear();
                                            break;
                                        }
                                        else if (String.Compare(t, "No") == 0 ||
                                         String.Compare(t, "no") == 0 ||
                                         String.Compare(t, "N") == 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("ERORR: incorrect vallu.");
                                        }
                                    } while (true);
                                    break;
                                case 4:
                                    Console.Clear();
                                    do
                                    {
                                        Console.WriteLine("Number phone of student: {0}", T.Phone);
                                        Console.WriteLine("Edit of the number phone?");
                                        Console.WriteLine("Yes/No");
                                        t = Console.ReadLine();
                                        if (String.Compare(t, "Yes") == 0 ||
                                            String.Compare(t, "yes") == 0 ||
                                            String.Compare(t, "Y") == 0)
                                        {

                                            Console.Clear();
                                            Console.Write("Please enter new number phone of student and accept edits: ");
                                            try
                                            {
                                                T.Phone = Convert.ToString(Convert.ToInt64(Console.ReadLine()));
                                                if (T.Phone.Length > 12)
                                                    throw new InvalidCastException("Your phone number is more than 12 characters, \"+\" is not needed");
                                                if (T.Phone.Length < 10)
                                                {
                                                    throw new InvalidCastException("Your phone number is less than 10 characters., \"+\" is not needed");
                                                }
                                                T.Phone = "+" + T.Phone;
                                                Console.Clear();
                                                break;
                                            }
                                            catch (InvalidCastException ex)
                                            {
                                                Console.Clear();
                                                Console.WriteLine(ex);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You entered an incorrect phone number, \"+\" is not needed");

                                            }

                                        }
                                        else if (String.Compare(t, "No") == 0 ||
                                            String.Compare(t, "no") == 0 ||
                                            String.Compare(t, "N") == 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("ERORR: incorrect vallu.");
                                        }
                                    } while (true);
                                    break;
                                case 5:
                                    Console.Clear();
                                    do
                                    {
                                        Console.WriteLine("Average ball of student: {0}", T.Average);
                                        Console.WriteLine("Edit of the average ball?");
                                        Console.WriteLine("Yes/No");
                                        t = Console.ReadLine();
                                        if (String.Compare(t, "Yes") == 0 ||
                                            String.Compare(t, "yes") == 0 ||
                                            String.Compare(t, "Y") == 0)
                                        {
                                            Console.Clear();
                                            Console.Write("Please enter new average ball of student and accept edits: ");
                                            T.Average = Convert.ToInt32(Console.ReadLine());
                                            Console.Clear();
                                            break;
                                        }
                                        else if (String.Compare(t, "No") == 0 ||
                                         String.Compare(t, "no") == 0 ||
                                         String.Compare(t, "N") == 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("ERORR: incorrect vallu.");
                                        }
                                    } while (true);
                                    break;
                                case 6:
                                    Console.Clear();
                                    do
                                    {
                                        Console.WriteLine("Number the group of student: {0}", T.Number_of_group);
                                        Console.WriteLine("Edit of the number the group?");
                                        Console.WriteLine("Yes/No");
                                        t = Console.ReadLine();
                                        if (String.Compare(t, "Yes") == 0 ||
                                            String.Compare(t, "yes") == 0 ||
                                            String.Compare(t, "Y") == 0)
                                        {
                                            Console.Clear();
                                            Console.Write("Please enter new number the group of student and accept edits: ");
                                            T.Number_of_group = Console.ReadLine();
                                            Console.Clear();
                                            break;
                                        }
                                        else if (String.Compare(t, "No") == 0 ||
                                         String.Compare(t, "no") == 0 ||
                                         String.Compare(t, "N") == 0)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("ERORR: incorrect vallu.");
                                        }
                                    } while (true);
                                    break;
                                case 7:
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Save edits?", T);

                                        Console.WriteLine("Yes/No");
                                        t = Console.ReadLine();
                                        if (String.Compare(t, "Yes") == 0 ||
                                            String.Compare(t, "yes") == 0 ||
                                            String.Compare(t, "Y") == 0)
                                        {
                                            Console.Clear();
                                            Human[i] = T;
                                            Console.Clear();
                                            works = false;
                                            break;
                                        }
                                        else if (String.Compare(t, "No") == 0 ||
                                         String.Compare(t, "no") == 0 ||
                                         String.Compare(t, "N") == 0)
                                        {
                                            Console.Clear();
                                            works = false;
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("ERORR: incorrect vallu.");
                                        }
                                    } while (true);
                                    break;
                            }

                        }
                        catch (Exception ex) { Console.Clear(); Console.WriteLine(ex); }
                    } while (works);
                    break;
                }
            }
        }
        public  void Save()
        {
            FileStream file = new FileStream("1.txt", FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);
           
            
            writer.Write(Human.Length);
            foreach (Student P in Human)
            {
                writer.Write(P.Name);
                writer.Write(P.Surname);
                writer.Write(P.Age);
                writer.Write(P.Phone);
                writer.Write(P.Average);
                writer.Write(P.Number_of_group);
            }
            writer.Close();
            file.Close();
           
        }
        public  void Load()
        {
            FileStream file = new FileStream("1.txt", FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(file);
            
            count = reader.ReadInt32();
            Human = new Student[count];
            for (int i = 0; i < count;i++ )
            {
                Human[i] = new Student();
            }
                foreach (Student P in Human)
                {

                    P.Name = reader.ReadString();
                    P.Surname = reader.ReadString();
                    P.Age = reader.ReadInt32();
                    P.Phone = reader.ReadString();
                    P.Average = reader.ReadInt32();
                    P.Number_of_group = reader.ReadString();
                }
           
           
            reader.Close();
            file.Close();
            
        }

        public void Search()
        {
            do {
                try {
                    Console.WriteLine("1. Student search by name.");
                    Console.WriteLine("2. Student search by surname.");
                    Console.WriteLine("3. Student search by age.");
                    Console.WriteLine("4. Student search by number phone.");
                    Console.WriteLine("5. Student search by average ball.");
                    Console.WriteLine("6. Student search by number the group.");
                    Console.WriteLine("7. Exit");
                    Console.Write("Please enter variants: ");
                    int number = Convert.ToInt32(Console.ReadLine());
                    string TempVariant;
                    int TempVariant1;
                    Console.Clear();
                    switch(number)
                    {
                        case 1:
                            Console.Write("Please enter name of student/s:");
                            TempVariant = Console.ReadLine();
                            foreach(Student P in Human)
                            {
                                if (String.Compare(P.Name, TempVariant) == 0)
                                {
                                    P.Print();
                                    Console.WriteLine();
                                }
                            }
                            break;
                        case 2:
                            Console.Write("Please enter surname of student/s:");
                            TempVariant = Console.ReadLine();
                            foreach(Student P in Human)
                            {
                                if (String.Compare(P.Surname, TempVariant) == 0)
                                {
                                    P.Print();
                                    Console.WriteLine();
                                }
                            }
                            break;
                        case 3:
                             Console.Write("Please enter age of student/s:");
                            TempVariant1 = Convert.ToInt32(Console.ReadLine());
                            foreach(Student P in Human)
                            {
                                if (P.Age== TempVariant1)
                                {
                                    P.Print();
                                    Console.WriteLine();
                                }
                            }
                            break;
                        case 4:
                             Console.Write("Please enter phone number of student/s:");
                        
                            try
                            {
                            
                                TempVariant = Convert.ToString(Convert.ToInt64(Console.ReadLine()));
                                if (TempVariant.Length > 12)
                                    throw new InvalidCastException("Your phone number is more than 12 characters, \"+\" is not needed");
                                if (TempVariant.Length < 10)
                                {
                                    throw new InvalidCastException("Your phone number is less than 10 characters., \"+\" is not needed");
                                }
                                TempVariant = "+" + TempVariant;
                                foreach (Student P in Human)
                                {
                                    if (String.Compare(P.Phone, TempVariant) == 0)
                                    {
                                        P.Print();
                                        Console.WriteLine();
                                    }
                                }
                            }
                            catch (InvalidCastException ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex);
                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                Console.WriteLine("You entered an incorrect phone number, \"+\" is not needed");

                            }
                            
                            break;
                        case 5:
                            Console.Write("Please enter average ball of student/s:");
                            TempVariant1 = Convert.ToInt32(Console.ReadLine());
                            foreach(Student P in Human)
                            {
                                if (P.Average == TempVariant1)
                                {
                                    P.Print();
                                    Console.WriteLine();
                                }
                            }
                            break;
                        case 6:
                            Console.Write("Please enter  number the group of student/s:");
                            TempVariant = Console.ReadLine();
                            foreach(Student P in Human)
                            {
                                if (String.Compare(P.Number_of_group, TempVariant) == 0)
                                {
                                    P.Print();
                                    Console.WriteLine();
                                }
                            }
                            break;
                        case 7:
                            goto stop;
                           
                    };
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex);
                }
                
            } while (true);
        stop:;
        }

        public void Sort()
        {
            int number = 0;
            Console.WriteLine("Parameters of sort");
            Console.WriteLine("1.Defalt");
            Console.WriteLine("2.Name");
            Console.WriteLine("3.Surname");
            Console.WriteLine("4.Age");
            Console.WriteLine("5.Phone");
            Console.WriteLine("6.Average");
            Console.WriteLine("7.Number the group");
            Console.Write("Please, enter value:");
            switch(number){
                case 1:
                    Array.Sort(Human);
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:

                    break;
            }
            Array.Sort(Human);
        }

        object Clone()
        {
            Student[] Human1= new Student[Human.Length];
            for(int i=0;i<Human1.Length;i++)
            {
                Human1[i] = new Student(Human[i].Name, Human[i].Surname, Human[i].Age, Human[i].Phone, Human[i].Average, Human[i].Number_of_group);
            }
            return Human1;
        }

        public void Copy()
        {
             
        }

        public IEnumerator GetEnumerator()
        {
            
            for (int i = 0; i < Human.Length; i++)
                yield return Human[i];        
        }

        #region enumerator
        int curpos = -1;
  
        public void Reset()
        {
          
            curpos = -1;
        }

        public object Current
        {
            get
            {
                return Human[curpos];
            }
        }

        public bool MoveNext()
        {
            if (curpos < Human.Length - 1)
            {
                curpos++;
                return true;
            }
            else
            {
                this.Reset();
                return false;
            }

        }
        #endregion enumerator
    }
}