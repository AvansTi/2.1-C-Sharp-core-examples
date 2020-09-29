using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQBasics
{
    class Program
    {

        private List<Customer> customers = new List<Customer>()
            {
                new Customer {Name = "Hans", City = "Breda"},
                new Customer {Name = "Sjaak", City = "London"},
                new Customer {Name = "Andrew", City = "London"},
                new Customer {Name = "Etienne", City = "Geertruidenberg"},

            };


        public void Init()
        {
           
        }


        public void CustomersWithoutLinq()
        {

            Console.WriteLine("Customers without LINQ");
            List<string> londoners = new List<string>();

            foreach (Customer c in customers)
            {
                if (c.City == "London")
                {
                    londoners.Add(c.Name);
                }
            }

            Console.WriteLine("Living in London");
            londoners.ForEach(n => { Console.WriteLine(n); });
            Console.WriteLine();
        }

        public void CustomersWithLinq()
        {

            Console.WriteLine("Customers with LINQ");
            var londoners =
            from c in customers
            where c.City == "London"
            select c.Name;

            Console.WriteLine("Living in London");
            londoners.ToList().ForEach(n => { Console.WriteLine(n); });
            Console.WriteLine();
        }

        public void CustomersWithLinqAnomiem()
        {

            Console.WriteLine("Customers with LINQ");
            var londoners =
            from c in customers
            where c.City == "London"
            select new { naam = c.Name, stad = c.City };

            //var res = londoners.FirstOrDefault();
            //Console.WriteLine(res);

            Console.WriteLine("Living in London");
            londoners.ToList().ForEach(n => { Console.WriteLine(n); });
            Console.WriteLine();
        }



        static void Main(string[] args)
        {
            Program p = new Program();

            p.CustomersWithoutLinq();
            p.CustomersWithLinq();
            p.CustomersWithLinqAnomiem();
        }
    }
}
