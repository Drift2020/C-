using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    abstract class B { public virtual void Print() { Console.WriteLine("This is B"); } }
    class A : B { private new void Print() { Console.WriteLine("This is A"); } }
    class Program { private static void Main(string[] args) { var a = new A(); a.Print(); } }
}
