using System.Reflection;
using Cities.Models;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var members = typeof(City).GetTypeInfo().GetDefaultMembers();

            foreach (var member in members)
            {
                Console.WriteLine($"{member.Name}, {member.DeclaringType}");
            }


            Console.ReadKey();
        }
    }
}
