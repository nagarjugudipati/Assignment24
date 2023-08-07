using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Assignment24Lib;

namespace Assignment24
{
    public class Program
    {
        static void Main(string[] args)
        {
            Class1 employee = new Class1();
            Console.WriteLine("Enter Employee's Id");
            employee.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter employee's First Name");
            employee.FirstName = Console.ReadLine();
            Console.WriteLine("Enter employee's last Name");
            employee.LastName = Console.ReadLine();
            Console.WriteLine("Enter employee's salary");
            employee.Salary = double.Parse(Console.ReadLine());
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("D:\\Mphasis\\Day-21\\Assignment24\\employee.bin", FileMode.Create))
            {
                formatter.Serialize(fs, employee);
            }
            Console.WriteLine("Created & Serialized");
            BinaryFormatter formatter1 = new BinaryFormatter();
            using (FileStream fs = new FileStream("D:\\Mphasis\\Day-21\\Assignment24\\employee.bin", FileMode.Open))
            {
               Class1 obj = (Class1)formatter.Deserialize(fs);
                Console.WriteLine($"Serialiae employee id is :  {obj.Id}   firstname : {obj.FirstName} , lastname:  {obj.LastName}, salary : {obj.Salary}");

            }
            Class1 employee1 = new Class1 { Id = 1, FirstName = "Raj", LastName = "Koti", Salary = 25000 };
            //Serialize the object to XML
            XmlSerializer serializer = new XmlSerializer(typeof(Class1));
            using (TextWriter writer = new StreamWriter("D:\\Mphasis\\Day-21\\Assignment24\\employee.xml"))

            {
                serializer.Serialize(writer, employee1);
            }
            Console.WriteLine("Created & Serialized");

            //Deserialized the object to xml
            XmlSerializer serializer1 = new XmlSerializer(typeof(Class1));
            using (TextReader reader = new StreamReader("D:\\Mphasis\\Day-21\\Assignment24\\employee.xml"))
            {
                Class1 deserializedPerson = (Class1)serializer.Deserialize(reader);
                Console.WriteLine($" ID: {deserializedPerson.Id} , FirstName: {deserializedPerson.FirstName}, LastName: {deserializedPerson.LastName}, Salary: {deserializedPerson.Salary}");
            }




            Console.ReadKey();

        }
    }
}
