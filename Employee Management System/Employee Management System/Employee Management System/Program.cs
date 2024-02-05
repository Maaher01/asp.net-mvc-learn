using Employee_Management_System.Models;
using System;

namespace Employee_Management_System
{
    internal class Program
    {
        static void Main()
        {
            Employee emp1 = new Employee() { Name="John Doe", DateOfBirth=new DateTime(1999, 11, 7), Id=1, Position=Position.Staff, JoinDate=new DateTime(2022,12,12)};
            Employee emp2 = new Employee("J. Walker", new DateTime(2000,12,12), 2, Position.Officer, new DateTime(2023,7,11));

            Console.WriteLine(emp1.Details());
            Console.WriteLine(emp2.Age());

            Console.WriteLine(emp2.Details());
            Console.WriteLine(emp1.Age());

            Console.ReadLine();
        }
    }
}
