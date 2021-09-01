//#define XML

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary; 

public class Test
{
    public static void Main()
    {

        #region MyRegion
        //Creates a new TestSimpleObject object.
        TestSimpleObject obj = new TestSimpleObject();

        Console.WriteLine("Before serialization the object contains: ");
        obj.Print();

        //Opens a file and serializes the object into it in binary format.
        Stream stream = File.Open("data.xml", FileMode.Create);
        
        #endregion
#if (XML)
        IFormatter formatter = new SoapFormatter();
#else
        IFormatter formatter = new BinaryFormatter();
#endif

        #region MyRegion
        formatter.Serialize(stream, obj);
        stream.Close();

        //Empties obj.
        obj = null;

        //Opens file "data.xml" and deserializes the object from it.
        stream = File.Open("data.xml", FileMode.Open);


        obj = (TestSimpleObject)formatter.Deserialize(stream);
        stream.Close();
        
        #endregion
        Console.WriteLine("");
        Console.WriteLine("After deserialization the object contains: ");
        obj.Print();
        Console.ReadLine();
    }
}


// A test object that needs to be serialized.
[Serializable]
public class TestSimpleObject
{

    private int member1;
    private string member2;
    private DateTimeOffset member3;
    private double member4;

    // A field that is not serialized.
    [NonSerialized()]
    private string member5;
    public Person member6 { get; set; }
    public Person member7 { get; set; }

    public TestSimpleObject() {
        member1 = 11;
        member2 = "hello";
        member3 = DateTimeOffset.Now;
        member4 = 3.14159265;
        member5 = "secret message";
        member6 = new Person("Beatrix");
        member7 = new Person("Willem Alexander", member6);
    }


    public void Print() {
        Console.WriteLine("member1 = '{0}'", member1);
        Console.WriteLine("member2 = '{0}'", member2);
        Console.WriteLine("member3 = '{0}'", member3);
        Console.WriteLine("member4 = '{0}'", member4);
        Console.WriteLine("member5 = '{0}'", member5);
        Console.WriteLine("member6 = '{0}'", member6);
        Console.WriteLine("member7 = '{0}'", member7);
    }
}

[Serializable]
public class Person {
    public string name { get; set; }
    public Person mother { get; set; }

    public Person (string name) {
        this.name = name;
        this.mother = null;
    }

    public Person(string name, Person mother) {
        this.name = name;
        this.mother = mother;
    }

    public override string ToString() {
        return mother == null ? name : $"name: {name} (mother: {mother})";
    }
}