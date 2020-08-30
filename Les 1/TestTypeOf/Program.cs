using System;

namespace TestTypeOf {

    public class ExampleClass {
        public int sampleMember;
        public void SampleMethod() { }

        static void Main() {

            Type t = typeof(int); //typeof(ExampleClass);
            // Alternatively, you could use 
            // ExampleClass obj = new ExampleClass(); 
            // Type t = obj.GetType();
            Console.WriteLine($"Today is: {DateTime.Today}");

            Console.WriteLine($"\nMethods of {t.Name}:");
            System.Reflection.MethodInfo[] methodInfo = t.GetMethods();

            foreach (System.Reflection.MethodInfo mInfo in methodInfo)
                Console.WriteLine(mInfo.ToString());

            Console.WriteLine($"\nMembers of {t.Name}:");
            System.Reflection.MemberInfo[] memberInfo = t.GetMembers();

            foreach (System.Reflection.MemberInfo mInfo in memberInfo)
                Console.WriteLine(mInfo.ToString());
            Console.ReadKey();
        }
    }
}

