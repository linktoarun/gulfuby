using System;
using System.Collections.Generic;
using System.Linq;

namespace TestQuery
{
   abstract internal class Base : IDisposable
    {
        private int x = 10;
        public int y = 20;

        public virtual void Method()

        {
            Console.WriteLine("Base Method" + x);
        }
        public abstract void absMethod();

        public virtual void NewMethod()
        {
            Console.WriteLine("Base Method" + x);
        }

        private string name;
        private DateTime? dt = null;

        public Base()
        {
            // base.Base("dfdf", null);
            // this("adfsd", null);
            string s = "Abc";
        }

        public void TestJoins()
        {
            var firstNames = new[]
                {
                    new { ID = 1, Name = "John" },
                    new { ID = 2, Name = "Sue" },
                };
            var lastNames = new[]
                    {
                        new { ID = 1, Name = "Doe" },
                        new { ID = 3, Name = "Smith" },
                    };
            var leftOuterJoin = from first in firstNames
                                join last in lastNames
                                on first.ID equals last.ID
                                into temp
                                from last in temp.DefaultIfEmpty(new { first.ID, Name = default(string) })
                                select new
                                {
                                    first.ID,
                                    FirstName = first.Name,
                                    LastName = last.Name,
                                };
            var rightOuterJoin = from last in lastNames
                                 join first in firstNames
                                 on last.ID equals first.ID
                                 into temp
                                 from first in temp.DefaultIfEmpty(new { last.ID, Name = default(string) })
                                 select new
                                 {
                                     last.ID,
                                     FirstName = first.Name,
                                     LastName = last.Name,
                                 };
            var fullOuterJoin = leftOuterJoin.Union(rightOuterJoin);
        }

        public Base(string name, DateTime? dt)
        {
            this.name = name;
            this.dt = dt;
        }

        public void Dispose()
        {
            string fail = "true";
        }
    }

    internal class Derived : Base
    {
        public int z = 30;

        public override  void absMethod()
        {
        }
        public override void Method()
        {
            Console.WriteLine("Drived Method");
        }

        private void Method2()
        {
            Console.WriteLine("Drived Method");
        }

        public Derived()
        {
            string z = "XYZ";
        }
    }

    public class Employee
    {
        public string Id;
    }

    internal interface I1
    {
        string test();
    }

    internal class Drived2 : Derived, I1
    {
        public virtual  void Method() { }

        // or
        // public new void Method() { }

         string I1.test()
        {
            throw new NotImplementedException();
        }
    }

    public class class1
    {
        public int x1;
        public int y1;
    }

    public class Form : class1
    {
        public int x1;
        public int y1;
    }

    public class Person
    {
        public int Age;
    }

    public struct Point
    {
        public int x1;
        public int y1;
    }

    internal class MyClient
    {
        public delegate double  CAreaPointer(int r);
        private enum Module
        {
            sun = 0, Mon, tues, wednes
        }

        public static void Main()
        {
            // Delegate with Anonymous
             CAreaPointer area = r => 3.14 * r * r;
             double Area = area(2);

            // Func Delegate 
             Func<double,int,double> area2  = (r,p) => 3.14 * r * r + p;
             double Area2 = area2(2,1);

            //Action Delegate does not return anything
             
             Action<string> mystring = y7 => Console.WriteLine(y7);
             mystring("Hello");

             //Predicate Delegate is an extension of Func delegate and return always bool value

             Predicate<string> mystring2 = y8 => y8.Length > 2;
             mystring2("Hello");

            Nullable<DateTime> dateSample2;
            int? test = null;
            Dictionary<int, string> st = new Dictionary<int, string>();

            //     st.Add(23, 23);
            st.Add(25, "stete");

            string returnenum = Enum.Parse((typeof(Module)), "sun").ToString();

            Form mynewform = new Form();
            class1 cne = mynewform;

            Console.WriteLine(cne.GetType());

            int x23 = 10;
            Action<int> addToX = new Action<int>(delegate(int y23)
                {
                    x23 = x23 + y23;
                }
            );
            addToX(10);
            Console.WriteLine(x23);

            Console.WriteLine("abcd" + 5.ToString());

            //var x = 5;
            //if(x==='5')
            //{
            //     Console.WriteLine("abcd" );

            //}
            try
            {
                Console.WriteLine("before exception");
                throw new Exception("new expresion");
                throw new Exception("after exception");
            }
            catch
            {
                Console.WriteLine("catch");
            }
            finally
            {
                Console.WriteLine("fianllly");
            }

            Console.WriteLine("After finally");

            List<Person> people = new List<Person>() { new Person { Age = 12 }, new Person { Age = 22 }, new Person {Age =10} };

           // people.Sort(x5, y5) => x5.Age.CompareTo(y5.Age)); 

            List<int> nums = new List<int>() { 5, 2, 3, 1, 4 };

            nums.Sort(); 
            foreach (var item in nums)
            {
                if (item == 3)
                    nums.Remove(item);
            }
            var person = from peoples in people
                         where peoples.Age > 18
                         select peoples;

            //people.Where(x1 => x1.Age > 18).FirstOrDefault();

            //  IQueryable<Person> people2 = people.ToList<Person>();
            // Person person2 = people2.Where(x => x.Age > 18).FirstOrDefault();
            //I1 newint = new Drived2();
            //newint.test();

            Base base2 = new Derived();
            base2.TestJoins();

            //   int vars = null;
            Derived derived2 = new Drived2();
            derived2.Method();
            base2.NewMethod();// displays 'base Method'
            Point myPoint = new Point();        // a new value-type variable
            Form myForm = new Form();              // a new reference-type variable
            MyClient myclient = new MyClient();
            myclient.Test(myPoint, myForm);                // Test is a method defined below

            myclient.Test2(ref myPoint, ref myForm);                // Test is a method defined below

            class1 c1, c2;

            c1 = new class1();

            c1.x1 = 30;
            c2 = c1;
            c2.x1 = 40;
            c2 = null;
            Console.WriteLine(c1.x1);

            int x, y;
            object a, b;

            x = 22;
            y = x;
            y = 12;
            Console.WriteLine(x);

            // a = 11;
            // b = a;
            // b = 33; // No idea why a is not changing its value
            //  b = null;
            // a = b;

            // Console.WriteLine(a);

            string str = "foofoo";
            str.Replace("foo", "FOO");

            str = str.Replace("foo", "FOO");

            a = (object)x;
            b = a;
            b = 33; // No idea why a is not changing its value
            a = b;

            Console.WriteLine(a);

            a = (object)x;
            b = a;
            b = null;

            // a = b;

            Console.WriteLine(a);

            string s1, s2;
            s1 = "test";
            s2 = s1;
            s2 = "Test2";
            Console.WriteLine(s1);

            //DateTime? dateval = null;
            //using (Base c = new Base())
            //{
            //    int var1=2, var2, var3 = 0;
            //    throw new Exception();
            //    var2 = var1 / var3;
            //}

            //Console.WriteLine(12.2 + 34 + "A");
            //Console.WriteLine("A"+ 12.2 + 34);
            //List<int> t = new List<int> { 9, 5, 6, 7 };

            // Derived d1 = new Derived();
            // d1.Method();// displays 'drived Method'

            // //Base b = new Derived();
            // //b.Method();// displays 'base Method'

            //// Derived d2;
            //// d2 = new Base(); // Compile time Error
            ////((Base) d2).Method();

            // Base b1 = new Base();
            // b1.Method();// displays 'base Method' if base method is not virtaul
        }

        public void Test(Point p, Form f)
        {
            p.x1 = 100;                       // No effect on MyPoint since p is a copy
            f.x1 = 200;        // This will change myForm’s caption since

            // myForm and f point to the same object
            f = null;                        // No effect on myForm
        }

        public void Test2(ref Point p, ref Form f)
        {
            p.x1 = 100;
            f.x1 = 200;        // This will change myForm’s caption since

            // myForm and f point to the same object
            f = null;                        // effect on myForm
        }
    }
}