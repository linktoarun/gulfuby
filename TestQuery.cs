//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace TestQuery
//{

//    public class Class1
//    {
//        int i;                                                                //No Access specifier means private
//        public int j;                                                 // Public
//        protected int k;                                         //Protected data
//        internal int m;                                        // Internal means visible inside assembly
//        protected internal int n;                  //inside assembly as well as to derived classes outside assembly
//        static int x;                                          // This is also private
//        public static int y;                           //Static means shared across objects
//        [DllImport("MyDll.dll")]
//        public static extern int MyFoo();       //extern means declared in this assembly defined in some other assembly
//        public void myFoo2()
//        {
//            //Within a class if you create an object of same class then you can access all data members through object reference even private data too
//            Class1 obj = new Class1();
//            obj.i = 10; //Error can’t access private data through object.But here it is accessible.:)
//            obj.j = 10;
//            obj.k = 10;
//            obj.m = 10;
//            obj.n = 10;
//            //     obj.s =10;  //Errror Static data can be accessed by class names only
//            Class1.x = 10;
//            //   obj.y = 10; //Errror Static data can be accessed by class names only
//            Class1.y = 10;
//        }
//    }

//}