using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Linq;
using System.Linq.Expressions;

namespace Yunly.Learning
{
    public class MyLinq
    {
        internal class Person
        {
            public int id { get; set; }
            public string name { get; set; }
            public int departId { get; set; }
            public int salary { get; set; }
            public int workingYears { get; set; }
            public int age { get; set; }

            public override string ToString()
            {
                return name;
            }
        }

        internal class Department
        {
            public string name { get; set; }
            public int id { get; set; }
        }

        static List<Person> people = new List<Person> {
            new Person{id=10, name="Mike", departId=1, salary=5200, workingYears=10, age=35},
            new Person{id=20, name="Jack", departId=2, salary=3000, workingYears=8, age=26},
            new Person{id=30, name="Mary", departId=3, salary=4000, workingYears=12, age=52 },
            new Person{id=11, name="Tom", departId=1, salary=4500,workingYears=3, age=25},
            new Person{id=21, name="Heny", departId=2, salary=5200,workingYears=4, age=31},
            new Person{id=31, name="Frank", departId=3, salary=5100,workingYears=16, age=58},
            new Person{id=40, name="Jary", departId=4,salary=3000,workingYears=21, age=65},
            new Person{id=41, name="Peter", departId=4, salary=4000,workingYears=12, age=48}
        };

        static List<Department> company = new List<Department>
        {
            new Department{ id=1, name="HR"},
            new Department{ id=2, name="Admin"},
            new Department{ id=3, name="Market"},
            new Department{ id=4, name="Finance"},
        };

        internal class Hr
        {
            static int vacationDays(int workingYears)
            {
                if (workingYears < 5)
                    return 5;
                if (workingYears < 10)
                    return 10;
                if (workingYears < 15)
                    return 15;

                return 20;
            }

            public static int getVacationDays(Person employee)
            {
                return vacationDays(employee.workingYears);
            }
        }

        private string LocalValue = "";

        public static void listSelect()
        {
            var export = people.ToDictionary(p => p.name, p=>p);


            foreach (var kvp in export)
            {
                Console.WriteLine($"{kvp.Key}, age:{kvp.Value.age}, saolar:{kvp.Value.salary}");
            }


        }

        public static void listEmployeeBySalary()
        {
            var result = company.GroupJoin(
               people,
               d => d.id,
               p => p.departId,
               (dept, ps) => new { department = dept.name, collections = ps }
           ).SelectMany(g => g.collections, (d, n) => new { dept = d.department, name = n });
           
           
           
            foreach (var p in result)
                Console.WriteLine(p);


        }


        public static void printNameByDept()
        {
            var result = company.GroupJoin(
                people,
                d => d.id,
                p => p.departId,
                (dept, ps) => new { department = dept.name, collections = ps }
            );


            foreach (var d in result)
            {
                Console.WriteLine($"Department:{d.department}");
                foreach (var p in d.collections)
                    Console.WriteLine($"\t{p.name}\t{p.departId}");
            }
        }

        public static void printByNameGroup()
        {


            var result = people.GroupBy(
                keySelector,
                (key, p) => new
                {
                    firstLetter = key,
                    count = p.Count(),
                    peoples = p
                }
               
                );

            foreach (var p in result)
            {
                Console.WriteLine($"Numbers of name begin with '{p.firstLetter}' is {p.count}");
                foreach (var name in p.peoples)
                {
                    Console.WriteLine($"\tname:{name.name},age:{name.age}");
                }
            }
        }

        static Func<Person, string> keySelector=>
            p => p.name.Substring(0, 1).ToLower();
        
         

        public static void printByAge()
        {
            var result = people.GroupBy(
                p => p.age / 10,
                (baseAge, p) => new
                {
                    ageGroup = baseAge * 10,
                    count = p.Count(),
                    peoples = p
                }
                ).OrderBy(p => p.ageGroup);

            foreach (var p in result)
            {
                Console.WriteLine($"Numbers of age group {p.ageGroup} is {p.count}");
                foreach (var name in p.peoples)
                {
                    Console.WriteLine($"\tname:{name.name},age:{name.age}");
                }
            }
        }

        

        public static List<int> distinctDeptByEmployee()
        {
            return people.Distinct(new EmployeeDeptIdComparer()).Select(p => p.departId).ToList();
        }

        public static List<string> supportDeptEmployeeNames()
        {
            return people.Where(p => p.departId == 1).
                Concat(people.Where(p => p.departId == 2)).
                Join(company, p => p.departId, d => d.id, (p, d) => d.name + "|" + p.name).ToList();
        }


        public static List<string> employeeNames()
        {
            return people.Cast<String>().ToList();

        }

        public static bool isAllEmployeelegal()
        {
            return people.All(p => p.age - p.workingYears >= 18);
        }

        public static int totalVacationDays()
        {
            return people.Aggregate(0, (day, emp) => day + Hr.getVacationDays(emp));

           // return people.Sum(p => Hr.getVacationDays(p));                
        }


        class EmpolyeeComparer : IEqualityComparer<Person>
        {
            public virtual bool Equals(Person x, Person y)
            {
                return x.id == y.id;
            }

            public int GetHashCode(Person product)
            {
                //Check whether the object is null
                if (Object.ReferenceEquals(product, null)) return 0;

                //Get hash code for the Name field if it is not null.
                int hashProductName = product.name == null ? 0 : product.name.GetHashCode();

                //Get hash code for the Code field.
                int hashProductCode = product.departId.GetHashCode();

                //Calculate the hash code for the product.
                return hashProductName ^ hashProductCode;
            }
        }

        class EmployeeDeptIdComparer : EmpolyeeComparer
        {
            public override bool Equals(Person x, Person y)
            {
                return x.departId == y.departId;
            }          
        }

        class EmployeeNameComparer : IEqualityComparer<string>
        {
   

            public bool Equals(string x, string y)
            {
                return x.Substring(0, 1).Equals(y.Substring(0, 1), StringComparison.CurrentCultureIgnoreCase);
            }

            public int GetHashCode(string product)
            {
                //Check whether the object is null
                if (Object.ReferenceEquals(product, null)) return 0;

                //Get hash code for the Name field if it is not null.
                int hashProductName = product == null ? 0 : product.GetHashCode();

                //Get hash code for the Code field.
                int hashProductCode = product.GetHashCode();

                //Calculate the hash code for the product.
                return hashProductName ^ hashProductCode;
            }
        }

        class CompareEmployeeBySalary : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                if (x.salary == y.salary) return 0;

                if (x.salary > y.salary) return 1;

                return -1;
            }
        }




    }

   

    ///////////////////////////////////////////////////////////////////////////////////////////////
    ///








}
