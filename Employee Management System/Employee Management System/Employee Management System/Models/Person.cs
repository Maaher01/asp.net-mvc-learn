using System;

namespace Employee_Management_System.Models
{
    internal abstract class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Person() { }
        public Person(string name, DateTime dateOfBirth) 
        { 
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
        }

        public abstract int Age();

        public virtual string Details()
        {
            return $"Name: {Name}, Date of birth: {DateOfBirth}";
        }
    }
}
