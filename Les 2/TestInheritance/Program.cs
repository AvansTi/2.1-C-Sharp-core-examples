using System;

namespace TestInheritance
{
    class Program
    {
        static void Main(string[] args) {
            A a = new A();
            a = new B();	// dynamic type of a is B
            a = new C();	// dynamic type of a is C
            //B b = a;	// forbidden; compilation error

            a = new C();
            Console.WriteLine("a is an instance of C: {0}", a is C);   // true, if dynamic type of a is C or a subclass; otherwise false
            Console.WriteLine("a is an instance of B {0}", a is B);    // true
            Console.WriteLine("a is an instance of A {0}", a is A); 	// true

            a = null;
           Console.WriteLine("a is an instance of C: {0}", a is C); 	            // false: if a== null, a is T always returns false
           Console.WriteLine("a is an instance of String: {0}", a is String); 	// false: but warning, (always returns false)


            A c = new C(42);
            c.Print();

            C newC = new C(42);
            newC.Print();

            Console.ReadLine();
        }
    }

    class A {
        public int a { get; set; }

        public virtual void Print()
        {
            Console.WriteLine("this is an A");
        }

    }

    class B : A {
        public int b { get; set; }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("this is a B");
        }
    }

    class C : B {

        public int c { get; set; }
        public int? MaybeInt { get; set; }

        public C()
        {
        }

        public C(int v) {
            this.MaybeInt = v;
        }

        public override void Print() {
            base.Print();
            Console.WriteLine("this is a C. It has a property maybeInt with value: {0}",
                MaybeInt ?? -1);
        }

    }
}
