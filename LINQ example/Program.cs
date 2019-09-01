using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_example
{

    public class Employee
    {
        public int _id { get; set; }
        public string _name { get; set; }
        public decimal _salary { get; set; }

    }

    class Program
    {

        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee() {_id = 1000, _name = "MH", _salary = 10000m },
                new Employee() {_id = 1001, _name = "TMH", _salary = 20000m },
                new Employee() {_id = 1002, _name = "MHT", _salary = 30000m },
                new Employee() {_id = 1003, _name = "MHH", _salary = 40000m },
                new Employee() {_id = 1004, _name = "MHM", _salary = 50000m },
            };

            // LINQ query
            var emp = from Employee in employees
                      where Employee._id > 1001 && Employee._salary > 20000
                      orderby Employee._salary descending
                      select Employee;

            var emp1 = from Employee in employees
                       where Employee._id > 1002
                       orderby Employee._salary ascending
                       select new { Employee._name, Employee._id };

            var emp3 = from Employee in employees
                       where Employee._salary >= 20000
                       select Employee;


            foreach (var e in emp1)
            {
                Console.WriteLine("Annonymous LINQ quey: {0}, {1}", e._name, e._id);
            }

            // LINQ method
            var emp2 = employees.Where(c => c._id > 1002 && c._salary >= 40000m).OrderByDescending(c => c._salary);

            Console.WriteLine("LINQ Query: ");
            //employees.ForEach(p => Console.WriteLine("{0} {1} {2}", p._id, p._name, p._salary));
            //Console.WriteLine("Sum of the Salary = {0}", employees.Sum(p => p._salary));
            Console.WriteLine("Sum of emp2 is : {0}", emp2.Sum(p => p._salary));

            /*
            foreach (Employee e in emp)
            {
                Console.WriteLine("{0} {1} {2}", e._id, e._name, e._salary);
            }
            */
            Console.WriteLine();
            Console.WriteLine("LINQ Method: ");
            /*
            foreach (Employee e in emp2)
            {
                Console.WriteLine("{0} {1} {2}", e._id, e._name, e._salary);
            }
            */

            var firstEmp = employees.OrderByDescending(p => p._salary).First(p => p._id < 1003);
            Console.WriteLine($"{firstEmp._name} {firstEmp._salary}");

            Console.WriteLine(employees.TrueForAll(p => p._salary > 9000));

            Console.WriteLine(emp.GetType());

            int[] array = new int[] { 1, 2, 3 };

            var enumerator = array.GetEnumerator();
            Console.WriteLine("Array Enumerable");
            while (enumerator.MoveNext())
            {
                Console.WriteLine($"{enumerator.Current}");
            }
            Console.ReadKey();


        }
    }
}
